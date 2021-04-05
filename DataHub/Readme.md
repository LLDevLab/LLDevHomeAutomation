# DataHub

This project contains 4 main parts: 2 libraries and 2 executables.

Libraries are:
- DbCommunicationLib - establish communication to the database and is responsible for reading and writing data to the database.
- IoTCommunicationLib - establish communication to MQTT brocker and tracking sensor's published data

Executables are:
- IoTWorkerService - background service. Service is using IoTCommunicationLib library, to receive data from sensors and writing data to the database using IoTCommunicationLib library
- IoTCommunicationGui - graphical user interface. Is reading data from the database and showing it to the user
