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
            Debug.Log("Brainflow streaming was started");
            staticPorts.statusON = true;
            connect_btn.SetActive(false);
            disconnect_btn.SetActive(true);
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
            int number_of_data_points = sampling_rate * 4;
            double[,] data = board_shim.get_current_board_data(number_of_data_points);
            // check https://brainflow.readthedocs.io/en/stable/index.html for api ref and more code samples
            Debug.Log("Num elements: " + data.GetLength(1));

        }


        
    }

    // you need to call release_session and ensure that all resources correctly released
    public void OnDestroy()
    {
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
            staticPorts.statusON = false;
            connect_btn.SetActive(true);
            disconnect_btn.SetActive(false);
            Debug.Log("Brainflow streaming was stopped");
        }
    }
}