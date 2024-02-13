@startuml
    left to right direction

    package M5StickC{}
    package PC{}
    package Unity{}

    M5StickC --> PC : シリアライズされたデータを送信
    PC --> Unity : 受信したデータを送信
@enduml

@startuml
    

@enduml