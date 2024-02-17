#include <M5StickC.h>

float accX = 0;
float accY = 0;
float accZ = 0;

float gyroX = 0;
float gyroY = 0;
float gyroZ = 0;

float temp = 0;

void setup() {
  Serial.begin(9600);

  M5.Lcd.fillScreen(BLACK);

  M5.begin();
  M5.MPU6886.Init();
}

void loop() {
  M5.MPU6886.getAccelData(&accX, &accY, &accZ);
  Serial.printf("%f, %f, %f", accX, accY, accZ);

  M5.MPU6886.getGyroData(&gyroX, &gyroY, &gyroZ);
  Serial.printf("%f, %f, %f", gyroX, gyroY, gyroZ);
  M5.MPU6886.getTempData(&temp);
  Serial.printf("%f", temp);

  delay(100);
}