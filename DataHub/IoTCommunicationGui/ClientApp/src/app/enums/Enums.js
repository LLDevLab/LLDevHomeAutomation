"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UnitType = exports.SensorType = void 0;
var SensorType;
(function (SensorType) {
    SensorType[SensorType["OnOffSensor"] = 0] = "OnOffSensor";
    SensorType[SensorType["Temperature"] = 1] = "Temperature";
    SensorType[SensorType["Pressure"] = 2] = "Pressure";
})(SensorType = exports.SensorType || (exports.SensorType = {}));
var UnitType;
(function (UnitType) {
    UnitType[UnitType["Undefined"] = 0] = "Undefined";
    UnitType[UnitType["DegreeCelsius"] = 1] = "DegreeCelsius";
    UnitType[UnitType["Pascals"] = 2] = "Pascals";
})(UnitType = exports.UnitType || (exports.UnitType = {}));
//# sourceMappingURL=enums.js.map