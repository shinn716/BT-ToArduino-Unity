using UnityEngine;
using System.Collections;

public class Bluetooth : AndroidBehaviour<Bluetooth>
{
    protected override string javaClassName
    {
        //要呼叫的class所在的Package名稱.要呼叫的java class名稱
        get { return "com.example.androidbluetooth.MainActivity"; }
    }  

    public static void DevName(string name)
    {
        instance.CallStatic("DevName", name);
    }

    public static void openBT()
    {
        instance.CallStatic("openBluetooth");
    }

    public static void findBT()
    {
        instance.CallStatic("findBT"); 
    }    

    public static void Connect(string address)
    {
        instance.CallStatic("Connect", address);
    }    

    public static void Write(byte[] bytes)
    {
        instance.CallStatic("Write", bytes);
    }

    public static string GetPairAddress()
    {
        return instance.CallStatic<string>("GetPairAddress");
    }

    public static string GetPairName()
    {
        return instance.CallStatic<string>("GetPairName");
    }

    public static void ShowSend()
    {
        instance.CallStatic("ShowSend");
    }

}
