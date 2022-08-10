using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    Transform Character;

    void Start()
    {
        Character = GameObject.Find("Character").transform;
    }

    
    void Update()
    {
        if (transform.position.z < (Character.position.z - 2.8f))
        {
            gameObject.SetActive(false);
        }
    }
}
