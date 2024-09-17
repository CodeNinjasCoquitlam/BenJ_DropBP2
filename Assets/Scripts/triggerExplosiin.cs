using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerExplosiin : MonoBehaviour
{
    [Header("test")]
    public GameObject explosion;

    private void onCollisionEnter(Collision collision)
    {
        
        Instantiate(explosion, transform.position, transform.rotation);
        
    }
}
