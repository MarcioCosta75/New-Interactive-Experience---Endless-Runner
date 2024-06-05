using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PortControllerCheck : MonoBehaviour
{
    public bool hasPort = false;

    public UdpClient client;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontD");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
