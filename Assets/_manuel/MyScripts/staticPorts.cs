using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class staticPorts 
{
   
   public static string[] ports_names;
   public static string selected_port;
   public static int boardIdSelected;
   public static bool synthetic = false;
   public static bool connect = false;
   public static bool statusON = false;
   
   public static int[] eeg_channels;

   public static int sampling_rate = 0;

   public static float ssvep_threshold;

   public static int scorePlyr1 = 0;
   public static int scorePlyr2 = 0;
   //public static int enemy_selected;
}
