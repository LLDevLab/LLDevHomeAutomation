import { SensorType, UnitType } from "../enums/Enums";

export interface SensorDetails {
  id: number;
  name: string;
  description: string;
  isActive: boolean;
  inverseLogic: boolean;
  sensorType: SensorType;
  unitId: UnitType;
}
