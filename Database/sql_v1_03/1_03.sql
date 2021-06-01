DROP TABLE public."ChartUnitMapping";

CREATE UNIQUE INDEX "SensorGroups_Name_Idx"
    ON public."SensorGroups" USING btree
    ("Name" COLLATE pg_catalog."default" ASC NULLS LAST)
    TABLESPACE pg_default;
	
ALTER TABLE public."SensorGroups"
    ADD COLUMN "UnitId" smallint;

CREATE INDEX "fki_SensorGroups_MeasumementUnits_fk"
    ON public."SensorGroups" USING btree
    ("UnitId" ASC NULLS LAST)
    TABLESPACE pg_default;
	
ALTER TABLE public."SensorGroups"
    ADD CONSTRAINT "SensorGroups_MeasumementUnits_fk" FOREIGN KEY ("UnitId")
    REFERENCES public."MeasurementUnits" ("Id") MATCH SIMPLE
    ON UPDATE RESTRICT
    ON DELETE RESTRICT;
	
ALTER TABLE public."Sensors" DROP COLUMN "UnitId";

CREATE OR REPLACE VIEW public."SensorsDataView"
 AS
 SELECT "Sensors"."Id",
    "Sensors"."Description",
    "Sensors"."IsActive",
    "Sensors"."Name",
    "Sensors"."InverseLogic",
    "SensorGroups"."Name" AS "SensorGroupName",
    "SensorGroups"."UnitId"
   FROM "Sensors"
     JOIN "SensorGroups" ON "Sensors"."SensorGroupId" = "SensorGroups"."Id";

ALTER TABLE public."SensorsDataView"
    OWNER TO postgres;
	
CREATE TABLE public."ChartSensorGroupsMapping"
(
    "ChartId" smallint NOT NULL,
    "SensorGroupId" smallint NOT NULL,
    CONSTRAINT "ChartSensorGroupsMapping_pkey" PRIMARY KEY ("ChartId", "SensorGroupId"),
    CONSTRAINT "fki_ChartSensorGroupsMapping_Charts_fk" FOREIGN KEY ("ChartId")
        REFERENCES public."Charts" ("Id") MATCH SIMPLE
        ON UPDATE RESTRICT
        ON DELETE RESTRICT,
    CONSTRAINT "fki_ChartSensorGroupsMapping_SensorGroups_fk" FOREIGN KEY ("SensorGroupId")
        REFERENCES public."SensorGroups" ("Id") MATCH SIMPLE
        ON UPDATE RESTRICT
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."ChartSensorGroupsMapping"
    OWNER to postgres;

CREATE INDEX "fki_fki_ChartSensorGroupsMapping_Charts_fk"
    ON public."ChartSensorGroupsMapping" USING btree
    ("ChartId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE INDEX "fki_fki_ChartSensorGroupsMapping_SensorGroups_fk"
    ON public."ChartSensorGroupsMapping" USING btree
    ("SensorGroupId" ASC NULLS LAST)
    TABLESPACE pg_default;