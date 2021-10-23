using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using brainflow;
public class chooseBoardGUI : MonoBehaviour
{
 

    public void cytonOnClick()
    {
        staticPorts.boardIdSelected = (int)BoardIds.CYTON_BOARD;
    }

     public void ganglionOnClick()
    {
        staticPorts.boardIdSelected = (int)BoardIds.GANGLION_BOARD;
    }

     public void syntheticOnClick()
    {
        staticPorts.boardIdSelected = (int)BoardIds.SYNTHETIC_BOARD;
        staticPorts.synthetic = true;
    }
}
