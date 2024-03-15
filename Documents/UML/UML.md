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


@startuml ver1.0の依存関係一覧
left to right direction

class シリアルハンドラ{
    シリアルデータ受信時の処理 : SerialDataReceivedEventHandler
    シリアルポート : SerialPort
    読み取りスレッド : Thread
    読み取り中フラグ : bool
    受信したデータ内容 : string
    新規メッセージ受信フラグ : bool

    シリアルデータ受信イベント(string message) : delegate void
    Awake() : void
    Update() : void
    OnDestroy() : void
    使えるポートを探す(string[] allowedPorts, string[] availablePorts) : void
    Open(): void
    Close() : void
    Read() : void
    Write() : void
}
class M5のデータ処理クラス{
    serialHundler : SerialHandler
    センサー情報 : struct
    Start() : void
    データ受信時の処理(string message) : void
}
struct センサー情報{
    デバイス名: string
    ボタンAタクトスイッチ : int
    ボタンBタクトスイッチ : int
    ボタンAトグルスイッチ : int
    ボタンBトグルスイッチ : int
    加速度 : Vector3
    ジャイロ : Vector3
}

class 最大温度計算機{
    m5 : M5Datareciver
    サンプリングするデータの上限 : int
    サンプリングした温度データ一覧 : List<float>
    サンプリングした温度データ中の最大値の一覧 : List<float>
    最大温度データの平均値 : float
    Update() : void
    最大温度の更新() : void
    最大温度を見つける() : float
}
class GameController{
    クリアSE : AudioClip
    失敗SE : AudioClip
    ゲームクリア時に表示するUI : GameObject
    ゲームオーバーUI : GameObject
    ゲーム終了フラグ : bool
    m5 : M5Datareciver

    Start() : void
    Update() : void
    ゲームクリア時の処理() : void
    ゲームオーバー時の処理() : void
    リトライ() : void
    サウンド再生() : void
}
class 最大温度計算機の温度に応じて「モード」を変えるクラス{
    最大温度計算機インスタンス : MaxTempAverageCalucurator
    最大温度平均 : float
    現在のモード : string
    モードのリスト : List<ModeValuePair>
    Update() : void
    ChangeMode() : string
}
struct モードのリスト{
    モード名 : string
    境界値 : float
}

class 火起こし器{
    tempModeChanger : TempModeChanger
    現在のモード : string
    modePowerDamageTable : ModePowerDamageTable

    FixedUpdate() : void
    GetIgnitionPower() : float
    GetTinderDamage() : float
    GetCurrentMode() : string
}

class 火種{
    fireStarter : FireStarter
    hp : float
    現在のHP : float
    火種が点火する温度 : float
    現在の温度 : float
    火種の温度が下がる量 : float
    hpBar : Slider
    temperatureBar : Slider

    Start() : void
    FixedUpdate() : void
    CoolDown() : void
    DecreaseHp() : void
    UpdateTemperature() : void
    UpdateTemperatureBar() : void
}
class 火種監視役{
    tinder : Tinder
    GameController : GameController
    litSound : AudioClip
    monkeyArm : GameObjet
    MonkeyBody : GameObject
}
class サル{
    腕 : MonkeyArmAnimationController
    胴体 : MonkeyBodyAnimationController
}
class MonkeyArmAnimationController
class MonkeyBodyAnimationController

シリアルハンドラ --> M5のデータ処理クラス : シリアルデータを送信
センサー情報 -- M5のデータ処理クラス


@enduml