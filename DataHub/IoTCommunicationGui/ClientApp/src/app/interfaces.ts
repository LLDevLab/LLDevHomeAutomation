import { UnitType } from "./enums";

export interface INamedTable {
  id: number;
  name: string;
}

export interface ISensorDetails extends INamedTable {
  description: string;
  isActive: boolean;
  inverseLogic: boolean;
  unitId: UnitType;
}

export interface IChartDetails extends INamedTable {
}

export interface ISensorEvents {
  id: number;
  sensorId: number;
  eventDateTime: Date;
  eventDoubleValue: number;
  eventBooleanValue: boolean;
}

export interface ISensorLineChartData<T> {
  name: string;
  series: ISensorLineChartPointData<T>[];
}

export interface ISensorLineChartPointData<T> {
  name: Date;
  value: T;
}

export interface IChartUnitMapping {
  unitId: number;
  unitName: string;
}
