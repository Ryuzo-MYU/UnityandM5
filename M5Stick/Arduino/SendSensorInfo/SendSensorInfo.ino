#include <M5StickC.h>

float accX = 0;
float accY = 0;
float accZ = 0;

float gyroX = 0;
float gyroY = 0;
float gyroZ = 0;

float temp = 0;

void setup() {
  M5.begin();
  M5.Lcd.fillScreen(BLACK);
  M5.MPU6886.Init();
}

void loop() {
  M5.MPU6886.getAccelData(&accX, &accY, &accZ);
  Serial.printf("%.2f, %.2f, %.2f\n", accX * 100, accY * 100, accZ * 100);

  M5.MPU6886.getGyroData(&gyroX, &gyroY, &gyroZ);
  Serial.printf("%.2f, %.2f, %.2f\n", gyroX, gyroY, gyroZ);
  
  M5.MPU6886.getTempData(&temp);
  Serial.printf("%.2f C\n", temp);

  delay(100);
}