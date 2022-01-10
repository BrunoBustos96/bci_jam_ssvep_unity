using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAlternation : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    // Start is called before the first frame update
    private float timeRemaining = 3;
    void Start()
    {
        enemy1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining>0){
            timeRemaining -= Time.deltaTime;
        }else{

            timeRemaining = 3;
            if(enemy1.active){
                enemy1.SetActive(false);
                enemy2.SetActive(true);
            }else if(enemy2.active){
                enemy2.SetActive(false);
                enemy3.SetActive(true);
            }else if(enemy3.active){
                enemy3.SetActive(false);
                enemy4.SetActive(true);
            }else if(enemy4.active){
                ;
            }
        }
    }
}
