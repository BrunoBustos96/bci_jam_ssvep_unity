using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using brainflow;
using brainflow.math;

public class openbciConnection : MonoBehaviour
{
    private BoardShim board_shim = null;
    private int sampling_rate = 0;

    public GameObject connect_btn;
    
    public GameObject disconnect_btn;

    //public static double[,] data;
    // Start is called before the first frame update
    void startBoard()
    {
        try
        {
            BoardShim.set_log_file("brainflow_log.txt");
            BoardShim.enable_dev_board_logger();

            BrainFlowInputParams input_params = new BrainFlowInputParams();
            int board_id = staticPorts.boardIdSelected;
            // input_params.serial_port = "COM3";
            if(staticPorts.synthetic != true){
                input_params.serial_port = staticPorts.selected_port;
            }

            board_shim = new BoardShim(board_id, input_params);
           
            board_shim.prepare_session();
            board_shim.start_stream(450000, "file://brainflow_data.csv:w");
            sampling_rate = BoardShim.get_sampling_rate(board_id);
            print("Sampling rate:"+sampling_rate);
            staticPorts.sampling_rate = BoardShim.get_sampling_rate(board_id);

            Debug.Log("Brainflow streaming was started");
            staticPorts.statusON = true;
            connect_btn.SetActive(false);
            disconnect_btn.SetActive(true);

            staticPorts.eeg_channels =  BoardShim.get_eeg_channels (board_id);

            //DontDestroyOnLoad(connect_btn);
            //DontDestroyOnLoad(disconnect_btn);
            //SetConnectButton();
            DontDestroyOnLoad(this.gameObject);
            
        }
        catch (BrainFlowException e)
        {
            Debug.Log(e);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(staticPorts.connect == true){
            startBoard();
            staticPorts.connect = false;
        }
        //status = ON / OFF

        if(staticPorts.statusON == true){
            if (board_shim == null)
            {
                return;
            }
            int number_of_data_points = sampling_rate * 120;
            //print(number_of_data_points);
            //double [,] data = board_shim.get_current_board_data(number_of_data_points);

            SignalFiltering.unprocessed_data = board_shim.get_current_board_data(number_of_data_points);
            //SignalFiltering.unprocessed_data = board_shim.get_board_data();
            // check https://brainflow.readthedocs.io/en/stable/index.html for api ref and more code samples
            //print(data[31,1]);
            /*
            Debug.Log("Num elements: " + data.GetLength(0));
            for (int i=0;i<data.GetLength(0);i++){
                print(i);
                //dt.Add((int)data[1,i]);    
            }
            */
            /*
            if (connect_btn == null){
                connect_btn = GameObject.FindWithTag("connect_btn");
                connect_btn.SetActive(false);
            }
            if (disconnect_btn == null){
                disconnect_btn = GameObject.FindWithTag("disconnect_btn");
                disconnect_btn.SetActive(true);
            }
            */
            
        }
        /*
        if (connect_btn == null){
            connect_btn = GameObject.FindWithTag("connect_btn");
        }
        if (disconnect_btn == null){
            disconnect_btn = GameObject.FindWithTag("disconnect_btn");
        }
        
        if(staticPorts.statusON){
            connect_btn.SetActive(false);
            disconnect_btn.SetActive(true);
        }
        */
    }
    // you need to call release_session and ensure that all resources correctly released
    public void OnDestroy()
    {
        
        print("DESTROYING BOARD");
        

        if (board_shim != null)
        {
            try
            {
                board_shim.release_session();
            }
            catch (BrainFlowException e)
            {
                Debug.Log(e);
            }
            //staticPorts.connect = false;
            staticPorts.statusON = false;
            //connect_btn.SetActive(true);
            //disconnect_btn.SetActive(false);
            Debug.Log("Brainflow streaming was stopped");
        }
    }
    /*
    public void ToggleConnect(){
        if(PlayerPrefs.GetInt("Connected",0) == 0){
            PlayerPrefs.SetInt("Connected",1);
        }
        else{
            PlayerPrefs.SetInt("Connected", 0);
        }
        SetConnectButton();
    }
    private void SetConnectButton(){
        if(PlayerPrefs.GetInt("Connected", 0) == 0){
            connect_btn.SetActive(false);
            disconnect_btn.SetActive(true);
        }
        else{
            connect_btn.SetActive(true);
            disconnect_btn.SetActive(false);
        }
    }
    */
}