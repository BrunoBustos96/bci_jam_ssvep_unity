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
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("enemy")){
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            print("You are death!");
            }
    }


}
