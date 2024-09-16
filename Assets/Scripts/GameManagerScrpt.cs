using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManagerScrpt : MonoBehaviour
{
    private Spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    public int FallDistance;
    public GameObject splash;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
    public GameObject scoreSystem;
    public Text scoreText;
    public int pointsWorth;
    private int score;



    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;
        splash.SetActive(false);

        scoreText.enabled = true;
        scoreSystem.GetComponent<Score>().score = 0;
        scoreSystem.GetComponent<Score>().Start();
    }
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);
        
    }
    void Awake()
    {
        scoreText.enabled = false;
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = playerPrefab;
       
    }
   void OnPlayerKilled()
    {
        spawner.active = false;
        gameStarted = false;

         splash.SetActive(true);
    }
    void Update()
    {
        


        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                ResetGame();
            }
        } else
        {
            if (!player)
            {
                OnPlayerKilled();
            }
        }
        var nextBomb = GameObject.FindGameObjectsWithTag("bomb");

        foreach (GameObject bombObject in nextBomb)
        {
            if (!gameStarted)
            {

                Destroy(bombObject);

            } else if (bombObject.transform.position.y < (-screenBounds.y) - FallDistance || !gameStarted)
            {
                scoreSystem.GetComponent<Score>().AddScore(pointsWorth);
                Destroy(bombObject);
                
            }
        }
    }
}
