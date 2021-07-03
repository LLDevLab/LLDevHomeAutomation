# DataHub

This project contains 4 main parts: 2 libraries and 3 executables.

Libraries are:
- DbCommunicationLib - establish communication to the database and is responsible for reading and writing data to the database.
- IoTCommunicationLib - establish communication to MQTT brocker and tracking sensor's published data

Executables are:
- WeatherForecastWorker - backgroung service. Service is reading weather forecast information from OpenWeatherMap API and saving it to the database
- IoTWorkerService - background service. Service is using IoTCommunicationLib library, to receive data from sensors and writing data to the database using IoTCommunicationLib library
- IoTCommunicationGui - graphical user interface. Is reading data from the database and showing it to the user
