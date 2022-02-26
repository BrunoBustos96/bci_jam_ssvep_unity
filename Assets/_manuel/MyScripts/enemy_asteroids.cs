using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_asteroids : MonoBehaviour
{

    public GameObject player;
    public GameObject explosion;
    public float Speed = 0.25f;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
        // print("Player pos y" + player.transform.position.y);
    }


    void facePlayer()
    {
        if (player_asteroids.playerIsAlive == false)
            return;
        // float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x -transform.position.x ) * Mathf.Rad2Deg;
        // Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle + 90.0f));
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);


        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
        transform.up = -1* (player.transform.position - transform.position);
        
        // transform.up = player.transform.position - new Vector3(transform.position.y - 90.0f, 0, 0);

    }

     private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet"))
        {
            health--;
            Destroy(other.gameObject); //destroy bullet
            if (health==0){
            Kill(); //Destroy enemy and bullet, instantiate explosion
            }
        }
        if(other.CompareTag("Player"))
        {
             Kill();
        }
    
        
    }

    public void Kill(){
        Destroy(gameObject);
        gameController.currentLvlEnemies --;
        print("Enemies Left "+ gameController.currentLvlEnemies);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosion, 5);
    }
  
 

}
