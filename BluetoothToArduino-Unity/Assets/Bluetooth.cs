using UnityEngine;
using System.Collections;

public class Bluetooth : AndroidBehaviour<Bluetooth>
{
    public string PackageName = "com.example.androidbluetooth.MainActivity";

    /// <summary>
    /// 要呼叫的class所在的Package名稱.要呼叫的java class名稱
    /// </summary>
    protected override string javaClassName
    {        
        get { return PackageName; }
    }

    /// <summary>
    /// 設定要抓取藍芽裝置的名稱
    /// </summary>
    public static void SetDevName(string name)
    {
        instance.CallStatic("SetDevName", name);
    }

    /// <summary>
    /// 設定要抓取藍芽裝置的位址
    /// </summary>
    public static void SetDevAddr(string addr)
    {
        instance.CallStatic("SetDevAddr", addr);
    }

    /// <summary>
    /// 強制開啟藍芽
    /// </summary>
    public static void openBT()
    {
        instance.CallStatic("openBluetooth");
    }
    
    /// <summary>
    /// Close
    /// </summary>
    public static void closeBt()
    {
        instance.CallStatic("CloseBt");
    }

    /// <summary>
    /// 搜尋藍芽裝置
    /// </summary>
    public static void findBT()
    {
        instance.CallStatic("findBT"); 
    }    

    /// <summary>
    /// 藍芽連線
    /// </summary>
    public static void Connect(string address)
    {
        instance.CallStatic("Connect", address);
    }

    /// <summary>
    /// 寫入訊號(byte), 專案用於Arduino Serial Read 'q', 'w', 'e'三種訊號, 詳見 https://github.com/shinn716/AndroidBluetoothToArduino-Processing
    /// </summary>
    public static void Write(byte[] bytes)
    {
        instance.CallStatic("Write", bytes);
    }

    /// <summary>
    /// 抓取配對裝置的位址
    /// </summary>
    public static string GetPairAddress()
    {
        return instance.CallStatic<string>("GetPairAddress");
    }

    /// <summary>
    /// 抓取配對裝置的名稱
    /// </summary>
    /// <returns></returns>
    public static string GetPairName()
    {
        return instance.CallStatic<string>("GetPairName");
    }

    /// <summary>
    /// 顯示 Toast, 可傳入自訂的字串
    /// </summary>
    public static void ShowSend(string info)
    {
        instance.CallStatic("ShowSend", info);
    }

}
