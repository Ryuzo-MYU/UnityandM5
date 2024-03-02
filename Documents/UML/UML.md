@startuml Serial COM
left to right direction

class M5StickC{
    name : string
    btnATactSwitch : int
    btnBTactSwitch : int
    btnAToggleSwitch : int
    btnBToggleSwitch : int
    accX : float
    accY : float
    accZ : float
    gyroX : float
    gyroX : float
    gyroX : float
    temp : float
}
class M5DataReceiver{
    name : string
    btnATactSwitch : int
    btnBTactSwitch : int
    btnAToggleSwitch : int
    btnBToggleSwitch : int
    accX : float
    accY : float
    accZ : float
    gyroX : float
    gyroX : float
    gyroX : float
    temp : float
}

M5StickC "1" --> "1" M5DataReceiver : シリアル通信をする
@enduml

@startuml
left to right direction

class M5
class TempGetter
class TempInterection
class Shake
class Friction

M5 "1"-->"1" TempGetter : 温度情報を送信
TempGetter "1" --> "1" TempInterection : 温度情報の最大値平均を送信
Shake --|> TempInterection
Friction --|> TempInterection
@enduml