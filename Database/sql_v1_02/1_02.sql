CREATE TABLE public."Charts"
(
    "Id" smallint NOT NULL,
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
	
CREATE TABLE public."ChartUnitMapping"
(
    "ChartId" smallint NOT NULL,
    "UnitId" smallint NOT NULL,
    CONSTRAINT "ChartUnitMapping_pkey" PRIMARY KEY ("ChartId", "UnitId"),
    CONSTRAINT "fki_ChartUnitMapping_Charts_fk" FOREIGN KEY ("ChartId")
        REFERENCES public."Charts" ("Id") MATCH SIMPLE
        ON UPDATE RESTRICT
        ON DELETE RESTRICT,
    CONSTRAINT "fki_ChartUnitMapping_MeasurementUnits_fk" FOREIGN KEY ("UnitId")
        REFERENCES public."MeasurementUnits" ("Id") MATCH SIMPLE
        ON UPDATE RESTRICT
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."ChartUnitMapping"
    OWNER to postgres;
-- Index: fki_fki_ChartUnitMapping_Charts_fk

-- DROP INDEX public."fki_fki_ChartUnitMapping_Charts_fk";

CREATE INDEX "fki_fki_ChartUnitMapping_Charts_fk"
    ON public."ChartUnitMapping" USING btree
    ("ChartId" ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: fki_fki_ChartUnitMapping_MeasurementUnits_fk

-- DROP INDEX public."fki_fki_ChartUnitMapping_MeasurementUnits_fk";

CREATE INDEX "fki_fki_ChartUnitMapping_MeasurementUnits_fk"
    ON public."ChartUnitMapping" USING btree
    ("UnitId" ASC NULLS LAST)
    TABLESPACE pg_default;	

ALTER TABLE public."Sensors"
    ALTER COLUMN "IsActive" DROP DEFAULT;
	
DROP INDEX public."SensorId_EventDateTime_Idx";

CREATE UNIQUE INDEX "SensorId_EventDateTime_Idx"
    ON public."SensorEvents" USING btree
    ("SensorId" ASC NULLS LAST, "EventDateTime" DESC NULLS LAST)
    TABLESPACE pg_default;

ALTER TABLE public."SensorEvents"
    CLUSTER ON "SensorId_EventDateTime_Idx";
	
ALTER TABLE public."Sensors" DROP COLUMN "SensorType";
DROP TABLE public."SensorTypes";

-- Adding SensorGroups table

CREATE TABLE public."SensorGroups"
(
    "Id" smallint NOT NULL,
    "Name" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "SensorGroups_pkey" PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."SensorGroups"
    OWNER to postgres;

ALTER TABLE public."Sensors"
    ADD COLUMN "SensorGroupId" smallint;
	
-- set group values of Sensors table before execute next commands

ALTER TABLE public."Sensors" 
    ALTER COLUMN "SensorGroupId" SET NOT NULL;
	
CREATE INDEX "fki_Sensors_SensorGroups_fk"
    ON public."Sensors" USING btree
    ("SensorGroupId" ASC NULLS LAST)
    TABLESPACE pg_default;
	
ALTER TABLE public."Sensors"
    ADD CONSTRAINT "Sensors_SensorGroups_fk" FOREIGN KEY ("SensorGroupId")
    REFERENCES public."SensorGroups" ("Id") MATCH SIMPLE
    ON UPDATE RESTRICT
    ON DELETE RESTRICT;