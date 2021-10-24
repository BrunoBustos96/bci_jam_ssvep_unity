using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class automatic_fire : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float angularSpeed = 250;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }
    private void OnMouseDown() {
        print("clicked!");
        faceEnemy();
    }




     void faceEnemy()
    {
        if (player_asteroids.playerIsAlive == false)
            return;
      

        // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, angularSpeed * Time.deltaTime);
        player.transform.up = -1* (player.transform.position - transform.position);
        // player.transform.up = Vector2.MoveTowards(transform.position, player.transform.position, angularSpeed * Time.deltaTime);
    }


}



