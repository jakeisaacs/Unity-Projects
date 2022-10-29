using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private GameObject[] collectibles;
    private GameObject player;

    private float cloudSpacing = 4f;
    private float controlX;
    private float minX, maxX;
    private float lastCloudY;

    private void Awake()
    {
        for (int i = 0; i < collectibles.Length; i++)
        {
            collectibles[i].SetActive(false);
        }

        controlX = 0;
        SetMinAndMax();
        CreateClouds();
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        PositionPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
 //       Debug.Log(minX + " " + maxX);
    }

    void Shuffle(GameObject[] arrayToShuffle)
    {
        for(int i=0;i<arrayToShuffle.Length;i++)
        {
            int random = Random.Range(i, arrayToShuffle.Length);
            if (!(arrayToShuffle[i].activeInHierarchy) && !(arrayToShuffle[random].activeInHierarchy))
            {
                GameObject temp = arrayToShuffle[i];
                arrayToShuffle[i] = arrayToShuffle[random];
                arrayToShuffle[random] = temp;
            }
        }
    }

    void CreateClouds()
    {
        float positionY = 0f;

        Shuffle(clouds);

        for(int i=0;i < clouds.Length;i++)
        {
            Vector3 temp = clouds[i].transform.position;

            temp.y = positionY;

            if (controlX == 0)
            {
                temp.x = Random.Range(maxX, 0.0f);
                controlX = 1;
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            //         Debug.Log(clouds[i].transform.position);
            //            Debug.Log(i%2);


            lastCloudY = positionY;

            clouds[i].transform.position = temp;
            clouds[i].SetActive(true);
            positionY -= cloudSpacing;
        }
    }

    void PositionPlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");

        for(int i = 0; i < darkClouds.Length;i++)
        {
            if (darkClouds[i].transform.position.y == 0.0f)
            {
                Vector3 t = darkClouds[i].transform.position;
                darkClouds[i].transform.position = clouds[0].transform.position;
                clouds[0].transform.position = t;
            }
        }

        Vector3 temp = clouds[0].transform.position;

        for(int i=0;i<clouds.Length;i++)
        {
            if (clouds[i].transform.position.y > temp.y)
                temp = clouds[i].transform.position;
        }

        player.transform.position = temp + new Vector3(0,0.2f,0);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Cloud" || target.tag == "Deadly")
        {
            if (target.transform.position.y == lastCloudY)
            {
                Shuffle(clouds);
                Shuffle(collectibles);

                Vector3 temp = target.transform.position;
                temp.y -= cloudSpacing;


                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(maxX, 0.5f);
                            controlX = 1;
                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(-0.5f, minX);
                            controlX = 2;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 3;
                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;
                        }



                        lastCloudY = temp.y;

                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);
                        temp.y -= cloudSpacing;


                        int random = Random.Range(0, collectibles.Length);

                        if (clouds[i].tag != "Deadly")
                        {
                            if (!collectibles[random].activeInHierarchy)
                            {
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;

                                if (collectibles[random].tag == "Life" && PlayerScore.lifeCount < 3)
                                {
                                    collectibles[random].transform.position = temp2;
                                    collectibles[random].SetActive(true);
                                }
                                else
                                {
                                    collectibles[random].transform.position = temp2;
                                    collectibles[random].SetActive(true);
                                }
                            }
                        }

                    }
                }
            }
        }
    }
}
