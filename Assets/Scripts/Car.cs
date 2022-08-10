using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float Speed=1.0f;

    void Update()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);

    }
}






