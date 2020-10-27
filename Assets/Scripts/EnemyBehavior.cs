using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] float shootCooldown = 1600f;
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] GameObject gunEnd = null;
    [SerializeField] ParticleSystem die;
    [SerializeField] AudioClip noise;
    float cooldown = 0f;
    public bool targeting;
    float respawn = 300f;


    // Start is called before the first frame update
    void Start()
    {
        targeting = false;
        cooldown = shootCooldown;
        respawn = 2000f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gunEnd.activeSelf)
        {
            
            if (respawn == 2000f)
            {
                die.Play();
            }
            respawn -= 1f;

        }
        else
        {
            if (targeting)
            {
                if (cooldown == shootCooldown)
                {
                    AudioManager.PlayClip2D(noise, 100f);
                    GameObject bullet = Instantiate(bulletPrefab, gunEnd.transform.position + (gunEnd.transform.forward * 1.75f), gunEnd.transform.rotation);
                    cooldown = 0f;
                }
            }
        }

        cooldown = Math.Min(shootCooldown, cooldown + 1f);

        if (respawn == 0f)
        {
            gunEnd.SetActive(true);
            respawn = 2000f;
        }

    }
}
