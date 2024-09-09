using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScrpt : MonoBehaviour
{
    private Spawner spawner;
    public GameObject title;
    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
    }
    void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            spawner.active = true;
            title.SetActive(false);
        }
    }
}
