import { SensorType } from "../enums/Enums";

export interface SensorDetails {
  id: number;
  name: string;
  description: string;
  isActive: boolean;
  inverseOnOffLogic: boolean;
  sensorType: SensorType;
}
