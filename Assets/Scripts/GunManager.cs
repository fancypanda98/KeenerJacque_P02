using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] ParticleSystem gunSmoke = null;
    [SerializeField] AudioClip shootingNoise = null;
    [SerializeField] Camera cameraController = null;
    [SerializeField] Transform rayOrigin = null;
    [SerializeField] float shootDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootGun();
        }
    }

    public void ShootGun()
    {
        Vector3 rayDirection = cameraController.transform.forward;
        Debug.DrawRay(rayOrigin.position, rayDirection*shootDistance, Color.white,1f);
        if(Physics.Raycast(rayOrigin.position, rayDirection, shootDistance))
        {
            Debug.Log("Hitt");
        }
        else
        {
            Debug.Log("Miss");
        }

        gunSmoke.Play();
        AudioManager.PlayClip2D(shootingNoise, 100);
    }
}
