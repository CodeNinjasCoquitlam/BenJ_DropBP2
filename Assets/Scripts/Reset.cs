﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    /*public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }*/
}
