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
    public int score;
    public GameObject splash;
    private Text _text;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;



    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;
        splash.SetActive(false);
    }
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        score = 0;
        splash.SetActive(false);
        
    }
    void Awake()
    {
        _text = GameObject.Find("ScoreText").GetComponent<Text>();
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
        _text.text = "Score: " + score;


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
            if (bombObject.transform.position.y < (-screenBounds.y) - FallDistance || !gameStarted)
            {
                score++;
                Destroy(bombObject);
                
            }
        }
    }
}
