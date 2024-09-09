using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bomb;
    public float delay = 2.0f;
    public bool active = false;
    public Vector2 delayRange = new Vector2(1,2);


    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    

    // Start is called before the first frame update
    void Start()
    {
        ResetDelay();
        StartCoroutine(EnemyGenerator());

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = bomb.GetComponent<MeshRenderer>().bounds.size.x / 2;
        objectWidth = bomb.GetComponent<MeshRenderer>().bounds.size.x / 2;
    }

    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);
        if (active)
        {
            float RandomX = Random.Range(screenBounds.x - objectWidth, screenBounds.x * -1 + objectWidth);
            float spawnY = (screenBounds.y + objectHeight) + 5;

            Instantiate(bomb, new Vector3(RandomX, spawnY, 0), bomb.transform.rotation);
            ResetDelay();
        }

        StartCoroutine(EnemyGenerator());
    }
    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
