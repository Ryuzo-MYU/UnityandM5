#include <M5StickC.h>

float xAccel;
float yAccel;
float zAccel;

void setup() {
  Serial.begin(9600);
  M5.Lcd.print();
}

void loop() {
  Serial.print(GetXAccel());
  Serial.print(GetYAccel());
  Serial.print(GetYAccel());
}

// x軸の加速度を取得する
float GetXAccel() {
  float xAccel;
  M5.MPU6886.getAccelData(&xAccel, 0, 0);
  return xAccel;
}

// y軸の加速度を取得する
float GetYAccel() {
  float yAccel;
  M5.MPU6886.getAccelData(0, &yAccel, 0);
  return yAccel;
}

// z軸の加速度を取得する
float GetZAccel() {
  float zAccel;
  M5.MPU6886.getAccelData(0, 0, &zAccel);
  return zAccel;
}