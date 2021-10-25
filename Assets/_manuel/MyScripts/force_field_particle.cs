using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force_field_particle : MonoBehaviour
{
    public GameObject forceField;
    // [SerializeField] 
    private int health = 2;
    // Start is called
    
    //TO DO: 
    //Check Health
    //if lives available < 1
    //KILL() => force field
    //

 

    private void OnTriggerEnter2D(Collider2D other) {
        string  msg;
        
        if(other.CompareTag("enemy")){
            // Destroy(forceField);
            health--;
            if (health < 0)
            {
              msg = "Force Field Destroyed!";
              print(msg);
              Destroy(gameObject);
            }
            else{
                msg = "Force Field Damaged!";
                print(msg);
                Destroy(other.gameObject);

            }

        }
    }

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
