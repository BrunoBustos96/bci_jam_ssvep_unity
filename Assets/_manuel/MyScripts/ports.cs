using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.Threading;

public class ports : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {        // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            // print(ports);
            print("The following serial ports were found:");
            staticPorts.ports_names = ports;

            // Display each port name to the console.
            foreach(string port in ports)
            {
               print(port);
            }

    }

    // Update is called once per frame
    void Update()
    {


   
    }
}
