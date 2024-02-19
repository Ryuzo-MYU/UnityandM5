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
    

@enduml