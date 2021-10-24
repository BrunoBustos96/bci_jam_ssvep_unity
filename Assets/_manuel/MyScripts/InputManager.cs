using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   public static float Horizontal {
       get { return Input.GetAxis("Horizontal");}
   }
   public static bool Fire {
       get { return Input.GetMouseButtonDown(0);}
   }
}
