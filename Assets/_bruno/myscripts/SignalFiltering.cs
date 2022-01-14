using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using System;
using TMPro;

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

        //public GameObject textObject;

        //public TextMeshProUGUI enSel;
        void Awake(){

            
            DontDestroyOnLoad(this.gameObject);
            //enSel = textObject.GetComponent<TextMeshProUGUI> ();
        }

        void Update ()
        {
            
            if (staticPorts.statusON == true){
                //THIS FUNCTION WAS MAINLY TESTED WITH THE SYNTHETIC BOARD
                print("SignalFiltering Started");
                int board_id = staticPorts.boardIdSelected;
                //double[,] unprocessed_data = openbciConnection.data;
    //            Debug.Log("Num elements SF unprocessed data: " + unprocessed_data.GetLength(1));
                int[] eeg_channels = staticPorts.eeg_channels;
                
                BoardDescr board_descr = staticPorts.board_descr;
                int sampling_rate = board_descr.sampling_rate;
                /*
                int nfft = DataFilter.get_nearest_power_of_two(sampling_rate);
                // use second channel of synthetic board to see 'alpha'
                int channel = eeg_channels[1];
            
                double[] detrend = DataFilter.detrend(unprocessed_data.GetRow(channel), (int)DetrendOperations.LINEAR);
                Tuple<double[], double[]> psd = DataFilter.get_psd_welch (detrend, nfft, nfft / 2, sampling_rate, (int)WindowFunctions.HANNING);
                double band_power_alpha = DataFilter.get_band_power (psd, 7.0, 13.0);
                double band_power_beta = DataFilter.get_band_power (psd, 14.0, 30.0);
                Console.WriteLine ("Alpha/Beta Ratio:" + (band_power_alpha/ band_power_beta));
                */

                if (unprocessed_data.GetLength(1) % (staticPorts.sampling_rate*2) == 0){
                //print("Entering the segmentation loop");
                //print((unprocessed_data.GetRow (eeg_channels[0]), staticPorts.sampling_rate, 15.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0));
                print("ENTERED THE IF");
                for (int i = 0; i < eeg_channels.Length; i++){
                    
                    //FILTERING THE SIGNAL WITH 25,19,12,5
                    filtered25 = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 25.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);
                    filtered19 = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 19.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);
                    filtered12 = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 12.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);
                    filtered5 = DataFilter.perform_bandpass (unprocessed_data.GetRow (eeg_channels[i]), staticPorts.sampling_rate, 5.0, 5.0, 2, (int)FilterTypes.BUTTERWORTH, 0.0);

                }

                double sum5 = 0,sum12 = 0, sum19 = 0, sum25 = 0;
                for(int j = 0;j < filtered5.Length;j++){
                    sum5 = sum5 + filtered5[j];
                    sum12 = sum12 + filtered12[j];
                    sum19 = sum19 + filtered19[j];
                    sum25 = sum25 + filtered25[j];
                }
                //print(sum5/filtered5.Length);
                
                //ShowValueScript.enemyTextUpdate(7);

                //CHECKING IF THE AVERAGE FILTERED SIGNAL SURPASSES THE THRESHOLD
                if ((sum25/filtered25.Length) > staticPorts.ssvep_threshold){
                    print("ENEMY 25");
                    enemySelected = Convert.ToString(4);
                    //enSel.text = Convert.ToString(4);
                }
                else if ((sum12/filtered19.Length) > staticPorts.ssvep_threshold){
                    print("ENEMY 19");
                    enemySelected = Convert.ToString(3);
                    //enSel.text  = Convert.ToString(3);
                }
                else if ((sum12/filtered12.Length) > staticPorts.ssvep_threshold){
                    print(sum12/filtered12.Length);
                    print("ENEMY 12");
                    enemySelected = Convert.ToString(2);
                    //enSel.text  = Convert.ToString(2);
                }
                else if ((sum5/filtered5.Length) > staticPorts.ssvep_threshold){
                    print(sum5/filtered5.Length);
                    print("ENEMY 5");
                    enemySelected = Convert.ToString(1);
                    //enSel.text  = Convert.ToString(1);
                }
                else{
                    enemySelected = Convert.ToString(-1);
                    //enSel.text  = Convert.ToString(-1);
                }

                double sum = sum5+sum12+sum19+sum25;
                print("AVERAGE FILTERED "+sum /filtered5.Length );

                unprocessed_data = empty_data;
            }

            }           
            
        
        }
    }
