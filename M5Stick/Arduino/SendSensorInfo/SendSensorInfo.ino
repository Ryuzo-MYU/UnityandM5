#include <M5StickC.h>
#include "BluetoothSerial.h"

// ボタン
// --------------------------------
int btnATactSwitch = false;  // ボタンA(真ん中のボタン)の押下状態(タクト)
int btnBTactSwitch = false;  // ボタンB(「M5」から見て右側のボタン)の押下状態(タクト)

int btnAToggleSwitch = false;  // ボタンA(真ん中のボタン)の押下状態(トグル)
int btnBToggleSwitch = false;  // ボタンB(「M5」から見て右側のボタン)の押下状態(トグル)

// Bluetooth
// --------------------------------
// Bluetoothデバイスの識別名
String name = "M5-01";

// BluetoothSerialインスタンスを生成
BluetoothSerial SerialBT;

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
  Serial.begin(115200);

  M5.Lcd.fillScreen(BLACK);
  M5.Lcd.setRotation(0);
  M5.Lcd.setTextFont(4);
  M5.Lcd.println(name);  // Bluetoothデバイス名を表示

  SerialBT.begin(name);  // Bluetoothシリアル通信の開始

  M5.MPU6886.Init();  // MPU6886を起動

  pinMode(M5_LED, OUTPUT);
}

void loop() {
  M5.update();  // 本体のボタン状態更新 ※必ず最初に記入が必要

  Serial.printf("%s\t", name);
  SerialBT.printf("%s\t", name);

  // タクトスイッチの状態
  btnATactSwitch = M5.BtnA.isPressed();
  btnBTactSwitch = M5.BtnB.isPressed();
  Serial.printf("%d\t%d\t", btnATactSwitch, btnBTactSwitch);
  SerialBT.printf("%d\t%d\t", btnATactSwitch, btnBTactSwitch);

  // トグルスイッチ(仮想)の状態
  if (M5.BtnA.wasPressed()) {
    btnAToggleSwitch = !btnAToggleSwitch;
  }
  if (M5.BtnB.wasPressed()) {
    btnBToggleSwitch = !btnBToggleSwitch;
  }
  Serial.printf("%d\t%d\t", btnAToggleSwitch, btnBToggleSwitch);
  SerialBT.printf("%d\t%d\t", btnAToggleSwitch, btnBToggleSwitch);

  // Lチカ
  LEDBlink(btnAToggleSwitch);

  // 加速度の取得
  M5.MPU6886.getAccelData(&accX, &accY, &accZ);
  Serial.printf("%.2f\t%.2f\t%.2f\t", accX * 100, accY * 100, accZ * 100);
  SerialBT.printf("%.2f\t%.2f\t%.2f\t", accX * 100, accY * 100, accZ * 100);

  // ジャイロの取得
  M5.MPU6886.getGyroData(&gyroX, &gyroY, &gyroZ);
  Serial.printf("%.2f\t%.2f\t%.2f\t", gyroX, gyroY, gyroZ);
  SerialBT.printf("%.2f\t%.2f\t%.2f\t", gyroX, gyroY, gyroZ);

  // 気温の取得
  M5.MPU6886.getTempData(&temp);
  Serial.printf("%.2f\t", temp);
  SerialBT.printf("%.2f\t", temp);

  Serial.println();
  SerialBT.println();
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