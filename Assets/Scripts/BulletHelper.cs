﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHelper : MonoBehaviour
{

    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "FirstPersonPlayer")
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 1);
        }
        bullet.SetActive(false);
    }

}
