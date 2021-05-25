DROP INDEX public."SensorId_EventDateTime_Idx";

CREATE UNIQUE INDEX "SensorId_EventDateTime_Idx"
    ON public."SensorEvents" USING btree
    ("SensorId" ASC NULLS LAST, "EventDateTime" DESC NULLS LAST)
    TABLESPACE pg_default;

ALTER TABLE public."SensorEvents"
    CLUSTER ON "SensorId_EventDateTime_Idx";