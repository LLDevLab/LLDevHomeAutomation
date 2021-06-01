--
-- PostgreSQL database dump
--

-- Dumped from database version 10.16 (Ubuntu 10.16-0ubuntu0.18.04.1)
-- Dumped by pg_dump version 13.2

-- Started on 2021-06-01 19:49:47

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
-- TOC entry 203 (class 1259 OID 16903)
-- Name: ChartSensorGroupsMapping; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ChartSensorGroupsMapping" (
    "ChartId" smallint NOT NULL,
    "SensorGroupId" smallint NOT NULL
);


ALTER TABLE public."ChartSensorGroupsMapping" OWNER TO postgres;

--
-- TOC entry 201 (class 1259 OID 16759)
-- Name: Charts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Charts" (
    "Id" smallint NOT NULL,
    "Name" character varying(30) NOT NULL
);


ALTER TABLE public."Charts" OWNER TO postgres;

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
-- TOC entry 2936 (class 0 OID 0)
-- Dependencies: 197
-- Name: SensorEvents_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."SensorEvents_Id_seq" OWNED BY public."SensorEvents"."Id";


--
-- TOC entry 202 (class 1259 OID 16881)
-- Name: SensorGroups; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."SensorGroups" (
    "Id" smallint NOT NULL,
    "Name" character varying(20) NOT NULL,
    "UnitId" smallint
);


ALTER TABLE public."SensorGroups" OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 16612)
-- Name: Sensors; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sensors" (
    "Id" integer NOT NULL,
    "Description" text NOT NULL,
    "IsActive" boolean NOT NULL,
    "Name" character varying(25) NOT NULL,
    "InverseLogic" boolean,
    "SensorGroupId" smallint NOT NULL
);


ALTER TABLE public."Sensors" OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 16940)
-- Name: SensorsDataView; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public."SensorsDataView" AS
 SELECT "Sensors"."Id",
    "Sensors"."Description",
    "Sensors"."IsActive",
    "Sensors"."Name",
    "Sensors"."InverseLogic",
    "SensorGroups"."Name" AS "SensorGroupName",
    "SensorGroups"."UnitId"
   FROM (public."Sensors"
     JOIN public."SensorGroups" ON (("Sensors"."SensorGroupId" = "SensorGroups"."Id")));


ALTER TABLE public."SensorsDataView" OWNER TO postgres;

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
-- TOC entry 2937 (class 0 OID 0)
-- Dependencies: 199
-- Name: Sensors_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Sensors_Id_seq" OWNED BY public."Sensors"."Id";


--
-- TOC entry 2777 (class 2604 OID 16621)
-- Name: SensorEvents Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorEvents" ALTER COLUMN "Id" SET DEFAULT nextval('public."SensorEvents_Id_seq"'::regclass);


--
-- TOC entry 2778 (class 2604 OID 16622)
-- Name: Sensors Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors" ALTER COLUMN "Id" SET DEFAULT nextval('public."Sensors_Id_seq"'::regclass);


--
-- TOC entry 2801 (class 2606 OID 16907)
-- Name: ChartSensorGroupsMapping ChartSensorGroupsMapping_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ChartSensorGroupsMapping"
    ADD CONSTRAINT "ChartSensorGroupsMapping_pkey" PRIMARY KEY ("ChartId", "SensorGroupId");


--
-- TOC entry 2793 (class 2606 OID 16766)
-- Name: Charts Charts_Name_constraint; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Charts"
    ADD CONSTRAINT "Charts_Name_constraint" UNIQUE ("Name");


--
-- TOC entry 2795 (class 2606 OID 16764)
-- Name: Charts Charts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Charts"
    ADD CONSTRAINT "Charts_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2789 (class 2606 OID 16659)
-- Name: MeasurementUnits MeasurementUnits_Unit_constraint; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MeasurementUnits"
    ADD CONSTRAINT "MeasurementUnits_Unit_constraint" UNIQUE ("Unit");


--
-- TOC entry 2791 (class 2606 OID 16643)
-- Name: MeasurementUnits MeasurementUnits_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MeasurementUnits"
    ADD CONSTRAINT "MeasurementUnits_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2780 (class 2606 OID 16624)
-- Name: SensorEvents SensorEvents_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorEvents"
    ADD CONSTRAINT "SensorEvents_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2798 (class 2606 OID 16885)
-- Name: SensorGroups SensorGroups_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorGroups"
    ADD CONSTRAINT "SensorGroups_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2784 (class 2606 OID 16626)
-- Name: Sensors Sensors_Name_constraint; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors"
    ADD CONSTRAINT "Sensors_Name_constraint" UNIQUE ("Name");


--
-- TOC entry 2786 (class 2606 OID 16628)
-- Name: Sensors Sensors_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors"
    ADD CONSTRAINT "Sensors_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2796 (class 1259 OID 16886)
-- Name: SensorGroups_Name_Idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "SensorGroups_Name_Idx" ON public."SensorGroups" USING btree ("Name");


--
-- TOC entry 2781 (class 1259 OID 16873)
-- Name: SensorId_EventDateTime_Idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "SensorId_EventDateTime_Idx" ON public."SensorEvents" USING btree ("SensorId", "EventDateTime" DESC NULLS LAST);

ALTER TABLE public."SensorEvents" CLUSTER ON "SensorId_EventDateTime_Idx";


--
-- TOC entry 2782 (class 1259 OID 16630)
-- Name: fki_SensorEvents_Sensors_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_SensorEvents_Sensors_fk" ON public."SensorEvents" USING btree ("SensorId");


--
-- TOC entry 2799 (class 1259 OID 16931)
-- Name: fki_SensorGroups_MeasumementUnits_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_SensorGroups_MeasumementUnits_fk" ON public."SensorGroups" USING btree ("UnitId");


--
-- TOC entry 2787 (class 1259 OID 16892)
-- Name: fki_Sensors_SensorGroups_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_Sensors_SensorGroups_fk" ON public."Sensors" USING btree ("SensorGroupId");


--
-- TOC entry 2802 (class 1259 OID 16919)
-- Name: fki_fki_ChartSensorGroupsMapping_Charts_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_fki_ChartSensorGroupsMapping_Charts_fk" ON public."ChartSensorGroupsMapping" USING btree ("ChartId");


--
-- TOC entry 2803 (class 1259 OID 16925)
-- Name: fki_fki_ChartSensorGroupsMapping_SensorGroups_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_fki_ChartSensorGroupsMapping_SensorGroups_fk" ON public."ChartSensorGroupsMapping" USING btree ("SensorGroupId");


--
-- TOC entry 2804 (class 2606 OID 16631)
-- Name: SensorEvents SensorEvents_Sensors_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorEvents"
    ADD CONSTRAINT "SensorEvents_Sensors_fk" FOREIGN KEY ("SensorId") REFERENCES public."Sensors"("Id") ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2806 (class 2606 OID 16926)
-- Name: SensorGroups SensorGroups_MeasumementUnits_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."SensorGroups"
    ADD CONSTRAINT "SensorGroups_MeasumementUnits_fk" FOREIGN KEY ("UnitId") REFERENCES public."MeasurementUnits"("Id") ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2805 (class 2606 OID 16887)
-- Name: Sensors Sensors_SensorGroups_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sensors"
    ADD CONSTRAINT "Sensors_SensorGroups_fk" FOREIGN KEY ("SensorGroupId") REFERENCES public."SensorGroups"("Id") ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2807 (class 2606 OID 16914)
-- Name: ChartSensorGroupsMapping fki_ChartSensorGroupsMapping_Charts_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ChartSensorGroupsMapping"
    ADD CONSTRAINT "fki_ChartSensorGroupsMapping_Charts_fk" FOREIGN KEY ("ChartId") REFERENCES public."Charts"("Id") ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2808 (class 2606 OID 16920)
-- Name: ChartSensorGroupsMapping fki_ChartSensorGroupsMapping_SensorGroups_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ChartSensorGroupsMapping"
    ADD CONSTRAINT "fki_ChartSensorGroupsMapping_SensorGroups_fk" FOREIGN KEY ("SensorGroupId") REFERENCES public."SensorGroups"("Id") ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2021-06-01 19:49:48

--
-- PostgreSQL database dump complete
--

