#include <M5StickC.h>
#include "BluetoothSerial.h"

// ボタン
// --------------------------------
bool btnAPressed = false;  // ボタンA(真ん中のボタン)の押下状態
bool btnBPressed = false;  // ボタンB(「M5」から見て右側のボタン)の押下状態

// Bluetooth
// --------------------------------
// Bluetoothデバイスの識別名
String name = "M5-BT-01";

// BluetoothSerialインスタンスを生成
BluetoothSerial BTSerial;

// MPU6886
// --------------------------------
// 加速度
float accX = 0;
float accY = 0;
float accZ = 0;

// ジャイロ
float gyroX = 0;
float gyroY = 0;
float gyroZ = 0;

// 気温
float temp = 0;


void setup() {
  M5.begin();
  Serial.begin(112500);

  M5.Lcd.fillScreen(BLACK);
  M5.Lcd.setRotation(3);
  M5.Lcd.setTextFont(4);
  M5.Lcd.println(name);  // Bluetoothデバイス名を表示

  BTSerial.begin(name);  // Bluetoothシリアル通信の開始

  M5.MPU6886.Init();  // MPU6886を起動

  pinMode(M5_LED, OUTPUT);
}

void loop() {
  M5.update();  // 本体のボタン状態更新 ※必ず最初に記入が必要

  BTSerial.printf("%s\n", name);

  // ボタンAの更新
  // トグル式でデータを送信
  if (M5.BtnA.wasPressed()) {
    btnAPressed = !btnAPressed;
  }

  // ボタンBの更新
  // トグル式でデータを送信
  if (M5.BtnB.wasPressed()) {
    btnBPressed = !btnBPressed;
  }

  BTSerial.printf("%d,%d\n", btnAPressed, btnBPressed);

  // Lチカ
  LEDBlink(btnAPressed);

  // 加速度の取得
  M5.MPU6886.getAccelData(&accX, &accY, &accZ);
  BTSerial.printf("%.2f,%.2f,%.2f\n", accX * 100, accY * 100, accZ * 100);

  // ジャイロの取得
  M5.MPU6886.getGyroData(&gyroX, &gyroY, &gyroZ);
  BTSerial.printf("%.2f,%.2f,%.2f\n", gyroX, gyroY, gyroZ);

  // 気温の取得
  M5.MPU6886.getTempData(&temp);
  BTSerial.printf("%.2fC\n", temp);

  BTSerial.printf("\n");
  delay(100);
}

// Lチカ
void LEDBlink(bool LEDon) {
  if (LEDon) {
    digitalWrite(M5_LED, LOW);
  } else {
    digitalWrite(M5_LED, HIGH);
  }
}