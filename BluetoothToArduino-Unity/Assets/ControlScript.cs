using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Bluetooth))]
public class ControlScript : MonoBehaviour
{
    public string WanttoFindDevName = "BluetoothV3";
    public Text text_addr;
    public Text text_name;

    private void Awake()
    {
        Bluetooth.DevName(WanttoFindDevName);
    }

    private void Start()
    {  
        Bluetooth.openBT();
        Init();
    }

    private void Init()
    {
        Bluetooth.findBT();
        StartCoroutine(ShowDevName());
    }

    private IEnumerator ShowDevName()
    {
        yield return new WaitForEndOfFrame();
        string address = Bluetooth.GetPairAddress();
        string name = Bluetooth.GetPairName();
        text_addr.text = address;
        text_name.text = name;
        Bluetooth.Connect(address);
    }

    private void Send(byte[] data, string info)
    {
        Bluetooth.Write(data);
        Bluetooth.ShowSend(info);
    }

    public void Btn01Click()
    {
        byte[] senddata = new byte[] { (int)'q', 2 };
        Send(senddata, "q");
    }

    public void Btn02Click()
    {
        byte[] senddata = new byte[] { (int)'w', 2 };
        Send(senddata, "w");
    }
}
