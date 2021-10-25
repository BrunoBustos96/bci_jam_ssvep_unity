using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using brainflow;
using brainflow.math;



    public class SignalFiltering: MonoBehaviour
    {
        public static double[,] unprocessed_data;
        public static double[,] empty_data;
        public static double[] filtered5;
        public static double[] filtered12;
        public static double[] filtered19;
        public static double[] filtered25;

        public static String enemySelected;
        void Awake(){
            print("SignalFiltering Started");
            DontDestroyOnLoad(this.gameObject);
        }
        void Update ()
        {
            // use synthetic board for demo
            /*
            BoardShim.enable_dev_board_logger ();
            BrainFlowInputParams input_params = new BrainFlowInputParams ();
            

            
            BoardShim board_shim = new BoardShim (board_id, input_params);
            board_shim.prepare_session ();
            board_shim.start_stream (3600);
            System.Threading.Thread.Sleep (5000);
            board_shim.stop_stream ();
            */
            int board_id = staticPorts.boardIdSelected;
            //double[,] unprocessed_data = openbciConnection.data;
            Debug.Log("Num elements SF unprocessed data: " + unprocessed_data.GetLength(1));
            int[] eeg_channels = staticPorts.eeg_channels;
            //board_shim.release_session ();
            /*
            if (unprocessed_data.GetLength(1) > (staticPorts.sampling_rate*3)){
                print("Entering the segmentation loop");
                print((unprocessed_data.GetRow (eeg_channels[0]), staticPorts.sampling_rate, 15.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0));
            }
            */
            
            if (unprocessed_data.GetLength(1) % (staticPorts.sampling_rate*3) == 0){
                //print("Entering the segmentation loop");
                //print((unprocessed_data.GetRow (eeg_channels[0]), staticPorts.sampling_rate, 15.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0));
                for (int i = 0; i < eeg_channels.Length; i++){

                    filtered5 = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 5.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);
                    filtered12 = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 12.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);
                    filtered19 = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 19.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);
                    filtered25 = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 25.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);


                    /*
                    filtered = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 15.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);

                    print("FILTERLENGTH"+filtered.Length);
                    print("Filtered channel " + eeg_channels[i]);

                    print(("[{0}]", string.Join (", ", filtered)));
                    print(("[{1}]",string.Join(", ",(unprocessed_data.GetRow (eeg_channels[i])))));
                    */
                //Console.WriteLine ("Filtered channel " + eeg_channels[i]);
                //Console.WriteLine ("[{0}]", string.Join (", ", filtered));
                }

                double sum5 = 0,sum12 = 0, sum19 = 0, sum25 = 0;
                for(int j = 0;j < filtered5.Length;j++){
                    sum5 = sum5 + filtered5[j];
                    sum12 = sum12 + filtered12[j];
                    sum19 = sum19 + filtered19[j];
                    sum25 = sum25 + filtered25[j];
                }
                print(sum5/filtered5.Length);
                if ((sum5/filtered5.Length) > staticPorts.ssvep_threshold){
                    print(sum5/filtered5.Length);
                    print("ENEMY 5");
                    enemySelected = Convert.ToString(1);
                }
                else if ((sum12/filtered12.Length) > staticPorts.ssvep_threshold){
                    print(sum12/filtered12.Length);
                    print("ENEMY 12");
                    enemySelected = Convert.ToString(2);
                }
                else if ((sum12/filtered19.Length) > staticPorts.ssvep_threshold){
                    print("ENEMY 19");
                    enemySelected = Convert.ToString(3);
                }
                else if ((sum25/filtered25.Length) > staticPorts.ssvep_threshold){
                    print("ENEMY 25");
                    enemySelected = Convert.ToString(4);
                }else{
                    enemySelected = Convert.ToString(5);
                }
                //print("AVERAGE FILTERED "+sum /filtered.Length );

                unprocessed_data = empty_data;
            }
            
            
            
            
            /*
            for (int i = 0; i < eeg_channels.Length; i++)
            {
                Console.WriteLine ("Before processing:");
                Console.WriteLine ("[{0}]", string.Join (", ", unprocessed_data.GetRow (eeg_channels[i])));
                switch (i)
                {
                    case 0:
                        filtered = DataFilter.perform_lowpass (unprocessed_data.GetRow(eeg_channels[i]), BoardShim.get_sampling_rate (board_id), 20.0, 4, (int)FilterTypes.BESSEL, 0.0);
                        Console.WriteLine ("Filtered channel " + eeg_channels[i]);
                        Console.WriteLine ("[{0}]", string.Join (", ", filtered));
                        break;
                    case 1:
                        filtered = DataFilter.perform_highpass (unprocessed_data.GetRow (eeg_channels[i]), BoardShim.get_sampling_rate (board_id), 2.0, 4, (int)FilterTypes.BUTTERWORTH, 0.0);
                        Console.WriteLine ("Filtered channel " + eeg_channels[i]);
                        Console.WriteLine ("[{0}]", string.Join (", ", filtered));
                        break;
                    case 2:
                        filtered = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), BoardShim.get_sampling_rate (board_id), 15.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);
                        Console.WriteLine ("Filtered channel " + eeg_channels[i]);
                        Console.WriteLine ("[{0}]", string.Join (", ", filtered));
                        break;
                    case 3:
                        filtered = DataFilter.perform_bandstop (unprocessed_data.GetRow (eeg_channels[i]), BoardShim.get_sampling_rate (board_id), 50.0, 1.0, 6, (int)FilterTypes.CHEBYSHEV_TYPE_1, 1.0);
                        Console.WriteLine ("Filtered channel " + eeg_channels[i]);
                        Console.WriteLine ("[{0}]", string.Join (", ", filtered));
                        break;
                    default:
                        filtered = DataFilter.remove_environmental_noise(unprocessed_data.GetRow(eeg_channels[i]), BoardShim.get_sampling_rate(board_id), (int)NoiseTypes.FIFTY);
                        Console.WriteLine("Filtered channel " + eeg_channels[i]);
                        Console.WriteLine("[{0}]", string.Join(", ", filtered));
                        break;
                }
            }
            */
        }
    }
