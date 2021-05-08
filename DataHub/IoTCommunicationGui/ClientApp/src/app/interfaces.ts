import { SensorType, UnitType } from "./enums";

export interface SensorDetails {
  id: number;
  name: string;
  description: string;
  isActive: boolean;
  inverseLogic: boolean;
  sensorType: SensorType;
  unitId: UnitType;
}

export interface SensorEvents {
  id: number;
  sensorId: number;
  eventDateTime: Date;
  eventDoubleValue: number;
  eventBooleanValue: boolean;
}

export interface SensorLineChartData<T> {
  name: string;
  series: SensorLineChartPointData<T>[];
}

export interface SensorLineChartPointData<T> {
  name: string;
  value: T;
}
