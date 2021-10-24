using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_asteroids : MonoBehaviour
{
public float angularSpeed;
private float horizontal;
private Vector2 bulletPosition;
public float offsetBullet;
public GameObject bulletPrefab;
public GameObject explosion;

private int health = 2;

// public GameObject forceField;



public static bool playerIsAlive = true;

public bool shooting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = InputManager.Horizontal;
        shooting = InputManager.Fire;
        // print(horizontal);
        Rotate();
        Shoot();
    }


    public void Rotate()
    {
        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);

    }

    private void Shoot()
    {
        if(shooting){
            
            var pos = transform.up * offsetBullet + transform.position;

            var bullet = Instantiate(
                bulletPrefab,
                pos,
                transform.rotation
            );
            Destroy(bullet, 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        string msg;
        if (other.CompareTag("enemy")){

            health--;

             if (health < 0)
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
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosion, 5);
            Destroy(gameObject);
            print("You are death!");
            playerIsAlive = false;
        }

}
