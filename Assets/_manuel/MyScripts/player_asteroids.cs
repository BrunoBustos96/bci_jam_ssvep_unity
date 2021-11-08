using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_asteroids : MonoBehaviour
{
public int player_num;
public float angularSpeed;
private float horizontal;
private Vector2 bulletPosition;
public float offsetBullet;
public GameObject bulletPrefab;
public GameObject explosion;
private int health = 2;
public static bool playerIsAlive = true;

public static string winMultiplayer;

public static bool shooting;

public float timeRemaining = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerIsAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = InputManager.Horizontal;
        // player_asteroids.shooting = InputManager.Fire;
        //Rotate();
        if(timeRemaining>0){
            timeRemaining -= Time.deltaTime;
        }else{
            timeRemaining = 2.0f;
            if(player_asteroids.shooting == true){
                Shoot();
            }
        }
        // if (transform.rotation.x != 0|| transform.rotation.y != 0){
        //     print("Corrected!");
        //             transform.rotation = Quaternion.Euler(0,0,transform.rotation.z);
        // }

    }


    public void Rotate()
    {
        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);

    }

    private void Shoot()
    {
        if(player_asteroids.shooting){
            
            var pos = transform.up * offsetBullet + transform.position;

            var bullet = Instantiate(
                bulletPrefab,
                pos,
                transform.rotation
            );
            Destroy(bullet, 5);
            player_asteroids.shooting = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        string msg;
        if (other.CompareTag("enemy")){

            health--;

             if (health == 0)
            {
                    Kill(); //Destroy Ship
            }
            else{
                msg = "Force Field Damaged!";
                print(msg);
                // Destroy(forceField.gameObject);
                Destroy(other.gameObject);
            }
            }
    }
        public void Kill(){
            if(gameController.multiplayerLvl == true)
            {
                /*
                staticPorts.scorePlyr1 = staticPorts.scorePlyr1+1;
                staticPorts.scorePlyr2 = staticPorts.scorePlyr2+1;
                */
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(explosion, 5);

                UpdateScore(player_num); // You pass the loser as an argument to update the score

                winMultiplayer = string.Format("Player {0} Lose!", player_num);
                print("You are dead!");
                playerIsAlive = false;
            }
            else{
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(explosion, 5);
                print("You are dead!");
                playerIsAlive = false;

            }
        }
        void UpdateScore(int playerNumber){
            if(playerNumber==2){
                staticPorts.scorePlyr1 = staticPorts.scorePlyr1 + 1;
            }else if(playerNumber==1){
                staticPorts.scorePlyr2 = staticPorts.scorePlyr2 + 1;
            }
    }

}
