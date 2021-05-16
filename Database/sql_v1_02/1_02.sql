CREATE SEQUENCE public."Charts_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 32767
    CACHE 1;

ALTER SEQUENCE public."Charts_Id_seq"
    OWNER TO postgres;

CREATE TABLE public."Charts"
(
    "Id" smallint NOT NULL DEFAULT nextval('"Charts_Id_seq"'::regclass),
    "Name" character varying(30) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Charts_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "Charts_Name_constraint" UNIQUE ("Name")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Charts"
    OWNER to postgres;
	
	
CREATE TABLE public."ChartSensorMap"
(
    "ChartId" smallint NOT NULL,
    "SensorId" integer NOT NULL,
    CONSTRAINT "ChartSensorMap_pkey" PRIMARY KEY ("ChartId", "SensorId"),
    CONSTRAINT "fki_ChartSensorMap_Charts_fk" FOREIGN KEY ("ChartId")
        REFERENCES public."Charts" ("Id") MATCH SIMPLE
        ON UPDATE RESTRICT
        ON DELETE RESTRICT,
    CONSTRAINT "fki_ChartSensorMap_Sensors_fk" FOREIGN KEY ("SensorId")
        REFERENCES public."Sensors" ("Id") MATCH SIMPLE
        ON UPDATE RESTRICT
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."ChartSensorMap"
    OWNER to postgres;
-- Index: fki_fki_ChartSensorMap_Charts_fk

-- DROP INDEX public."fki_fki_ChartSensorMap_Charts_fk";

CREATE INDEX "fki_fki_ChartSensorMap_Charts_fk"
    ON public."ChartSensorMap" USING btree
    ("ChartId" ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: fki_fki_ChartSensorMap_Sensors_fk

-- DROP INDEX public."fki_fki_ChartSensorMap_Sensors_fk";

CREATE INDEX "fki_fki_ChartSensorMap_Sensors_fk"
    ON public."ChartSensorMap" USING btree
    ("SensorId" ASC NULLS LAST)
    TABLESPACE pg_default;