using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Transform follow_character;
    Vector3 Distance;

    float Speed = 5.0f;

    void Start()
    {
        follow_character = GameObject.Find("Character").transform;
    }

    
    void LateUpdate()
    {
        Distance = new Vector3(follow_character.position.x, transform.position.y, follow_character.position.z - 10.75f);
        transform.position = Vector3.Lerp(transform.position, Distance, Speed*Time.deltaTime);
    }
}
