using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Bluetooth))]
public class ControlScript : MonoBehaviour
{
    public Text text_addr;
    public Text text_name;

    private void Start()
    {
        Bluetooth.openBT();
        init();
    }

    void init()
    {
        Bluetooth.findBT();
        Invoke("ShowDevName", 2);

    }

    void ShowDevName()
    {
        string address = Bluetooth.GetPairAddress();
        string name = Bluetooth.GetPairName();
        text_addr.text = address;
        text_name.text = name;
        Bluetooth.Connect(address);
    }

    private void Send(byte[] data)
    {
        Bluetooth.Write(data);
        Bluetooth.ShowSend();
    }

    public void Btn01Click()
    {
        byte[] senddata = new byte[] { (int)'q', 2 };
        Send(senddata);
    }

    public void Btn02Click()
    {
        byte[] senddata = new byte[] { (int)'w', 2 };
        Send(senddata);
    }
}