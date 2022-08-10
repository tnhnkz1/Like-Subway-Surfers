using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject Coin;

    public GameObject Magnet;
    public GameObject Car;
    public GameObject Log;
    public GameObject Stone;

    List<GameObject> Coins;

    List<GameObject> Others;

    Transform Character;

    public TMPro.TextMeshProUGUI Score_TMP;

    int Score = 0;

    public GameObject Over_IMG;
    public GameObject Stop_IMG;

    void Start()
    {
        Coins = new List<GameObject>();
        Others = new List<GameObject>();
        Character = GameObject.Find("Character").transform;

        Produce(Coin, 10, Coins);

        Produce(Magnet, 3, Others);
        Produce(Car, 3, Others);
        Produce(Log, 3, Others);
        Produce(Stone, 3, Others);

        InvokeRepeating("Produce_Coin", 0.0f, 1.0f);
        InvokeRepeating("Produce_Obstacle", 1.5f, 3.0f);

        Score_TMP.text = "SCORE" + Score.ToString();
    }

    public void Increase_Score(int value)
    {
        Score += value;
        Score_TMP.text = "SCORE" + Score.ToString();
    }

    

    void Produce_Obstacle()
    {
        int ran = Random.Range(0, Others.Count);

        if(Others[ran].activeSelf == false)
        {
            Others[ran].SetActive(true);

            int random = Random.Range(0, 2);

            if (random == 0)
            {
                Others[ran].transform.position = new Vector3(1, 1, Character.position.z + 10.0f);
            }
            if (random == 1)
            {
                Others[ran].transform.position = new Vector3(1, 1, Character.position.z + 10.0f);
            }
            
            if (Others[ran].tag == "Car")
            {
                Others[ran].transform.position = new Vector3(1.0f, 0.5f, Character.position.z + 30.0f);
                
            }

            if(Others[ran].tag == "Magnet")
            {
                if(Character.gameObject.GetComponent<Character>().Magnet_Taken == true)
                {
                    Others[ran].SetActive(false);
                }

                Others[ran].transform.position = new Vector3(4, 2.2f, Character.position.z + 10.0f);


            }
        }
        else
        {
            foreach(GameObject article in Others)
            {
                if(article.activeSelf == false)
                {
                    article.SetActive(true);

                    int random_2 = Random.Range(0, 2);

                    if (random_2 == 0)
                    {
                        article.transform.position = new Vector3(1.0f, 1, Character.position.z + 10.0f);
                    }
                    if (random_2 == 1)
                    {
                        article.transform.position = new Vector3(5, 1, Character.position.z + 10.0f);
                    }
                    if(article.tag == "Magnet")
                    {
                        if(Character.gameObject.GetComponent<Character>().Magnet_Taken == true)
                        {
                            article.SetActive(false);
                        }
                        
                        
                    }

                    return;  
                }
            }
        }
    }   
    
    
    
    void Produce_Coin()
    {
        foreach(GameObject Coin in Coins)
        {
            if (Coin.activeSelf == false)
            {
                Coin.SetActive(true);

                int random = Random.Range(0, 2);

                if(random == 0)
                {
                    Coin.transform.position = new Vector3(7.15f, 5, Character.position.z + 10.0f);
                }
                if(random == 1)
                {
                    Coin.transform.position = new Vector3(0.30f, 5, Character.position.z + 10.0f);
                }

                return;
            }
        }
    }
    
    
    
    void Produce(GameObject article, int amount, List<GameObject> list)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject new_article = Instantiate(article);
            new_article.SetActive(false);
            list.Add(new_article);
        }
         
    }
    
    void Update()
    {
        
    }

    public void Play_Again()
    {
        SceneManager.LoadScene("Scenes/SubwaySurfers");
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        
        Stop_IMG.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void StopTheGame()
    {
        Stop_IMG.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
