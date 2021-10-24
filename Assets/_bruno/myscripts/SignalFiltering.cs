using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using brainflow;
using brainflow.math;



    public class SignalFiltering: MonoBehaviour
    {
        public static double[,] unprocessed_data;

        void Awake(){
            print("SignalFiltering Started");
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
                print("Entering the segmentation loop");
                print((unprocessed_data.GetRow (eeg_channels[0]), staticPorts.sampling_rate, 15.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0));
            }

            
            double[] filtered;
            for (int i = 0; i < eeg_channels.Length; i++){
                
                filtered = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 15.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);

                print("Filtered channel " + eeg_channels[i]);

                print(("[{0}]", string.Join (", ", filtered)));
                print(("[{1}]",string.Join(", ",(unprocessed_data.GetRow (eeg_channels[i])))));

                //Console.WriteLine ("Filtered channel " + eeg_channels[i]);
                //Console.WriteLine ("[{0}]", string.Join (", ", filtered));
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
