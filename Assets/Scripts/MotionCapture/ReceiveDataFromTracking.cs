using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class ReceiveDataFromTracking : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client;
    public int port = 5052;
    public bool startReceiving = true;
    public bool printToConsole = false;
    public string data;

    public bool hasPort;
    [SerializeField] private PortControllerCheck PortControllerScript;
    

    // Start is called before the first frame update
    void Start()
    {

        PortControllerScript = GameObject.FindWithTag("DontD").GetComponent<PortControllerCheck>();
        hasPort = PortControllerScript.hasPort;

        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }


    private void ReceiveData()
    {
        if (hasPort == false)
        {
            client = new UdpClient(port);
            PortControllerScript.client = client;
            hasPort = true;
        } else {
            client = PortControllerScript.client;
        }

        while (startReceiving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);

                if (printToConsole)
                    print(data);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }
}