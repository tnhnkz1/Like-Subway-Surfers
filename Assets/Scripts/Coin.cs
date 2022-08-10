using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Transform Character;
    Character Control;

    void Start()
    {
        Character = GameObject.Find("Character").transform;
        Control = GameObject.Find("Character").GetComponent<Character>();
    }

    
    void Update()
    {
        float Distance = Vector3.Distance(transform.position, Character.position);

        if (Control.Magnet_Taken == true)
        {
            

            if(Distance <= 5.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Character.position, 10.0f * Time.deltaTime);
            }
            
        }

        if (transform.position.z < (Character.position.z - 5.0f))
        {
            if(transform.position.z < (Character.position.z - 0.0f))
            { 
        
                gameObject.SetActive(false);
            }

            gameObject.SetActive(false);
        }



    }
}
