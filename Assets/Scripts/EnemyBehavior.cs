using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] float shootCooldown = 180f;
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] GameObject gunEnd = null;
    float cooldown = 0f;
    public bool targeting;


    // Start is called before the first frame update
    void Start()
    {
        targeting = false;
        cooldown = shootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = Math.Min(shootCooldown, cooldown + 1f);
        if (targeting)
        {
            if(cooldown == shootCooldown)
            {
                GameObject bullet = Instantiate(bulletPrefab,gunEnd.transform.position + (gunEnd.transform.forward * 1.75f),gunEnd.transform.rotation);
                cooldown = 0f;
            }
        }
    }
}
