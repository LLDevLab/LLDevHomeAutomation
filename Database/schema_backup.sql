--
-- PostgreSQL database dump
--

-- Dumped from database version 10.16 (Ubuntu 10.16-0ubuntu0.18.04.1)
-- Dumped by pg_dump version 13.2

-- Started on 2021-04-19 20:46:18

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

--
-- TOC entry 200 (class 1259 OID 16638)
-- Name: MeasurementUnits; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."MeasurementUnits" (
    "Id" smallint NOT NULL,
    "Unit" character varying(10) NOT NULL
);


ALTER TABLE public."MeasurementUnits" OWNER TO postgres;

--
-- TOC entry 196 (class 1259 OID 16607)
-- Name: SensorEvents; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."SensorEvents" (
    "Id" bigint NOT NULL,
    "SensorId" integer NOT NULL,
    "EventDateTime" timestamp with time zone NOT NULL,
    "EventDoubleValue" double precision,
    "EventBooleanValue" boolean
);


ALTER TABLE public."SensorEvents" OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 16610)
-- Name: SensorEvents_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."SensorEvents_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."SensorEvents_Id_seq" OWNER TO postgres;

--
-- TOC entry 2915 (class 0 OID 0)
-- Dependencies: 197
-- Name: SensorEvents_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."SensorEvents_Id_seq" OWNED BY public."SensorEvents"."Id";


--
-- TOC entry 201 (class 1259 OID 16660)
-- Name: SensorTypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."SensorTypes" (
    "Id" smallint NOT NULL,
    "Name" character varying(25) NOT NULL
);


ALTER TABLE public."SensorTypes" OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 16612)
-- Name: Sensors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sensors" (
    "Id" integer NOT NULL,
    "Description" text NOT NULL,
    "IsActive" boolean DEFAULT true NOT NULL,
    "Name" character varying(25) NOT NULL,
    "InverseLogic" boolean,
    "SensorType" smallint NOT NULL,
    "UnitId" smallint
);


ALTER TABLE public."Sensors" OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 16619)
-- Name: Sensors_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Sensors_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Sensors_Id_seq" OWNER TO postgres;

--
-- TOC entry 2916 (class 0 OID 0)
-- Dependencies: 199
-- Name: Sensors_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Sensors_Id_seq" OWNED BY public."Sensors"."Id";


--
-- TOC entry 2765 (class 2604 OID 16621)
-- Name: SensorEvents Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorEvents" ALTER COLUMN "Id" SET DEFAULT nextval('public."SensorEvents_Id_seq"'::regclass);


--
-- TOC entry 2767 (class 2604 OID 16622)
-- Name: Sensors Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors" ALTER COLUMN "Id" SET DEFAULT nextval('public."Sensors_Id_seq"'::regclass);


--
-- TOC entry 2779 (class 2606 OID 16659)
-- Name: MeasurementUnits MeasurementUnits_Unit_constraint; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MeasurementUnits"
    ADD CONSTRAINT "MeasurementUnits_Unit_constraint" UNIQUE ("Unit");


--
-- TOC entry 2781 (class 2606 OID 16643)
-- Name: MeasurementUnits MeasurementUnits_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MeasurementUnits"
    ADD CONSTRAINT "MeasurementUnits_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2769 (class 2606 OID 16624)
-- Name: SensorEvents SensorEvents_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorEvents"
    ADD CONSTRAINT "SensorEvents_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2783 (class 2606 OID 16666)
-- Name: SensorTypes SensorTypes_Name_constraint; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorTypes"
    ADD CONSTRAINT "SensorTypes_Name_constraint" UNIQUE ("Name");


--
-- TOC entry 2785 (class 2606 OID 16664)
-- Name: SensorTypes SensorTypes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorTypes"
    ADD CONSTRAINT "SensorTypes_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2773 (class 2606 OID 16626)
-- Name: Sensors Sensors_Name_constraint; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors"
    ADD CONSTRAINT "Sensors_Name_constraint" UNIQUE ("Name");


--
-- TOC entry 2775 (class 2606 OID 16628)
-- Name: Sensors Sensors_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors"
    ADD CONSTRAINT "Sensors_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2770 (class 1259 OID 16629)
-- Name: SensorId_EventDateTime_Idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "SensorId_EventDateTime_Idx" ON public."SensorEvents" USING btree ("SensorId", "EventDateTime" DESC NULLS LAST);

ALTER TABLE public."SensorEvents" CLUSTER ON "SensorId_EventDateTime_Idx";


--
-- TOC entry 2771 (class 1259 OID 16630)
-- Name: fki_SensorEvents_Sensors_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_SensorEvents_Sensors_fk" ON public."SensorEvents" USING btree ("SensorId");


--
-- TOC entry 2776 (class 1259 OID 16694)
-- Name: fki_Sensors_MeasurementUnits_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_Sensors_MeasurementUnits_fk" ON public."Sensors" USING btree ("UnitId");


--
-- TOC entry 2777 (class 1259 OID 16681)
-- Name: fki_Sensors_SensorTypes_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_Sensors_SensorTypes_fk" ON public."Sensors" USING btree ("SensorType");


--
-- TOC entry 2786 (class 2606 OID 16631)
-- Name: SensorEvents SensorEvents_Sensors_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorEvents"
    ADD CONSTRAINT "SensorEvents_Sensors_fk" FOREIGN KEY ("SensorId") REFERENCES public."Sensors"("Id") ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2788 (class 2606 OID 16689)
-- Name: Sensors Sensors_MeasurementUnits_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors"
    ADD CONSTRAINT "Sensors_MeasurementUnits_fk" FOREIGN KEY ("UnitId") REFERENCES public."MeasurementUnits"("Id") ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2787 (class 2606 OID 16676)
-- Name: Sensors Sensors_SensorTypes_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors"
    ADD CONSTRAINT "Sensors_SensorTypes_fk" FOREIGN KEY ("SensorType") REFERENCES public."SensorTypes"("Id") ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2021-04-19 20:46:19

--
-- PostgreSQL database dump complete
--

