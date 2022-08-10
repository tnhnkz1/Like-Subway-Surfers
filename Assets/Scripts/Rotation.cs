using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    string Name;


    void Start()
    {
        Name = gameObject.tag;
    }

    
    void Update()
    {
        if (Name == "Magnet")
        {
            transform.Rotate(1.0f, 0, 0, Space.World);
        }

        if (Name == "Coin")
        {
            transform.Rotate(0, 1.5f, 0, Space.World);
        }
    }
}
