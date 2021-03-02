--
-- PostgreSQL database dump
--

-- Dumped from database version 10.15 (Ubuntu 10.15-0ubuntu0.18.04.1)
-- Dumped by pg_dump version 13.2

-- Started on 2021-03-02 21:05:52

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
-- TOC entry 199 (class 1259 OID 16495)
-- Name: SensorEvents; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."SensorEvents" (
    "Id" bigint NOT NULL,
    "SensorId" integer NOT NULL,
    "EventDateTime" timestamp with time zone NOT NULL,
    "EventType" smallint NOT NULL
);


ALTER TABLE public."SensorEvents" OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 16493)
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
-- TOC entry 2895 (class 0 OID 0)
-- Dependencies: 198
-- Name: SensorEvents_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."SensorEvents_Id_seq" OWNED BY public."SensorEvents"."Id";


--
-- TOC entry 197 (class 1259 OID 16484)
-- Name: Sensors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sensors" (
    "Id" integer NOT NULL,
    "Description" text NOT NULL,
    "IsActive" boolean DEFAULT true NOT NULL,
    "Name" character varying(25) NOT NULL,
    "Type" smallint NOT NULL,
    "InverseOnOffLogic" boolean
);


ALTER TABLE public."Sensors" OWNER TO postgres;

--
-- TOC entry 196 (class 1259 OID 16482)
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
-- TOC entry 2896 (class 0 OID 0)
-- Dependencies: 196
-- Name: Sensors_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Sensors_Id_seq" OWNED BY public."Sensors"."Id";


--
-- TOC entry 2759 (class 2604 OID 16498)
-- Name: SensorEvents Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorEvents" ALTER COLUMN "Id" SET DEFAULT nextval('public."SensorEvents_Id_seq"'::regclass);


--
-- TOC entry 2757 (class 2604 OID 16487)
-- Name: Sensors Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors" ALTER COLUMN "Id" SET DEFAULT nextval('public."Sensors_Id_seq"'::regclass);


--
-- TOC entry 2765 (class 2606 OID 16500)
-- Name: SensorEvents SensorEvents_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorEvents"
    ADD CONSTRAINT "SensorEvents_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2761 (class 2606 OID 16518)
-- Name: Sensors SensorName_constraint; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors"
    ADD CONSTRAINT "SensorName_constraint" UNIQUE ("Name");


--
-- TOC entry 2763 (class 2606 OID 16492)
-- Name: Sensors Sensors_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors"
    ADD CONSTRAINT "Sensors_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2766 (class 1259 OID 16508)
-- Name: SensorId_EventDateTime_Idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "SensorId_EventDateTime_Idx" ON public."SensorEvents" USING btree ("SensorId", "EventDateTime" DESC NULLS LAST);

ALTER TABLE public."SensorEvents" CLUSTER ON "SensorId_EventDateTime_Idx";


--
-- TOC entry 2767 (class 1259 OID 16506)
-- Name: fki_SensorEvents_Sensors_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_SensorEvents_Sensors_fk" ON public."SensorEvents" USING btree ("SensorId");


--
-- TOC entry 2768 (class 2606 OID 16501)
-- Name: SensorEvents SensorEvents_Sensors_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorEvents"
    ADD CONSTRAINT "SensorEvents_Sensors_fk" FOREIGN KEY ("SensorId") REFERENCES public."Sensors"("Id") ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2021-03-02 21:05:53

--
-- PostgreSQL database dump complete
--

