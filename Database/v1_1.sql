ALTER TABLE public."SensorEvents"
ADD "EventFloatValue" float null;

-----------------------------------------------------
CREATE SEQUENCE public."MeasurementUnits_Id_seq"
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 32767
    CACHE 1;

ALTER SEQUENCE public."MeasurementUnits_Id_seq"
    OWNER TO postgres;

CREATE TABLE public."MeasurementUnits"
(
    "Id" smallint NOT NULL DEFAULT nextval('"MeasurementUnits_Id_seq"'::regclass),
    "Unit" character varying(10) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "MeasurementUnits_pkey" PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."MeasurementUnits"
    OWNER to postgres;
	
ALTER TABLE public."MeasurementUnits"
    ADD CONSTRAINT "Unit_constraint" UNIQUE ("Unit");
	
--------------------------------------------------------

ALTER TABLE public."SensorEvents"
    ADD COLUMN "UnitId" smallint;
	
--------------------------------------------------------

ALTER TABLE public."SensorEvents"
    ADD CONSTRAINT "SensorEvents_UnitId_fkey" FOREIGN KEY ("UnitId")
    REFERENCES public."MeasurementUnits" ("Id") MATCH SIMPLE
    ON UPDATE RESTRICT
    ON DELETE RESTRICT;