using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AcumulativeScore : MonoBehaviour
{
    public TextMeshProUGUI scorePlayer1;
    public TextMeshProUGUI scorePlayer2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayer1.text  = "Player 1: "+staticPorts.scorePlyr1;
        scorePlayer2.text  = "Player 2: "+staticPorts.scorePlyr2;
    }
}
