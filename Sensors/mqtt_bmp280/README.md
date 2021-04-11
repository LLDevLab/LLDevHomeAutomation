# MQTT BMP280

This code is receiving data (temperature and pressure) from bmp280 sensor and is publishing it to specified mqtt server.

This project is based on "publish_test" example of esp-idf.

# Usage
- This example is using i2c bus. SDA is connected to pin 16 and SCL to pin 17 of ESP32.