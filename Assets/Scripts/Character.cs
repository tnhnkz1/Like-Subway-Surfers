using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody rigi;

    float Jumping_power = 10.0f;
    float Running_speed = 10.0f;

    bool Right;
    bool Left;
    bool Jumped = false;

    public GameObject Dust;

    public Animator anim;

    Transform Ground;
    Transform Ground_1;

    Main Man;

    public bool Magnet_Taken = false;

    public GameObject Over_IMG;
    
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        Ground = GameObject.Find("Ground").transform;
        Ground_1 = GameObject.Find("Ground_1").transform;

        Man = GameObject.Find("Main").GetComponent<Main>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ground")
        {
            Ground_1.position = new Vector3(Ground_1.position.x, Ground_1.position.y, Ground.position.z + 45.0f);
        }
        if(other.gameObject.name == "Ground_1")
        {
            Ground.position = new Vector3(Ground.position.x, Ground.position.y, Ground_1.position.z + 45.0f);
        }

        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            Man.Increase_Score(10);
        }

        if(other.gameObject.tag == "Magnet")
        {
            other.gameObject.SetActive(false);

            Magnet_Taken = true;

            Invoke("Destroy_Magnet", 10.0f);
        }
    }

    void Destroy_Magnet()
    {
        Magnet_Taken = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Over_IMG.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if (collision.gameObject.tag == "Car")
        {
            Over_IMG.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Jumped = false;

        if (Dust.activeSelf == false)
        {
            Dust.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Jumped = true;

        if (Dust.activeSelf == true)
        {
            Dust.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.touchCount > 0 )
        {
            Touch Finger = Input.GetTouch(0);

            if (Finger.deltaPosition.x > 50.0f)
            {
                Right = true;
                Left = false;
            }

            if (Finger.deltaPosition.x < -50.0f)
            {
                Right = false;
                Left = true;
            }
        }

        int random = Random.Range(0, 2);

        if (Right == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(7.15f, transform.position.y, transform.position.z), Running_speed * Time.deltaTime);

        }

        if (Left == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0.30f, transform.position.y, transform.position.z), Running_speed * Time.deltaTime);
        }

        transform.Translate(0, 0, Running_speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (Jumped == false)
        {
            anim.SetTrigger("Jump");
            rigi.velocity = Vector3.zero;
            rigi.velocity = Vector3.up * Jumping_power;
        }
    }
}
