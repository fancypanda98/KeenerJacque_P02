using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] float baseSpeed = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = .4f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpHeight = 3f;

    [SerializeField] ParticleSystem gunSmoke = null;
    [SerializeField] AudioClip shootingNoise = null;
    [SerializeField] Camera cameraController = null;
    [SerializeField] Transform rayOrigin = null;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] CharacterController playerController = null;

    [SerializeField] GameObject canvas3 = null;
    [SerializeField] ShootBarScript barScript = null;

    Vector3 velocity;
    bool isGrounded;
    RaycastHit objectHit;
    float currentShootDistance;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Pause", 0);
    }

    // Update is called once per frame
    void Update()
    {
        currentShootDistance = shootDistance;
        if (canvas3.activeSelf)
        {
            float speed = baseSpeed;

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            if (isGrounded)
            {
                if (velocity.x > 0)
                {
                    velocity.x = Math.Max(velocity.x - 2f, 0);
                }
                if (velocity.x < 0)
                {
                    velocity.x = Math.Min(velocity.x + 2f, 0);
                }
                if (velocity.z > 0)
                {
                    velocity.z = Math.Max(velocity.z - 2f, 0);
                }
                if (velocity.z < 0)
                {
                    velocity.z = Math.Min(velocity.z + 2f, 0);
                }
            }
            else
            {
                if (velocity.x > 0)
                {
                    velocity.x = Math.Max(velocity.x - .02f, 0);
                }
                if (velocity.x < 0)
                {
                    velocity.x = Math.Min(velocity.x + .02f, 0);
                }
                if (velocity.z > 0)
                {
                    velocity.z = Math.Max(velocity.z - .02f, 0);
                }
                if (velocity.z < 0)
                {
                    velocity.z = Math.Min(velocity.z + .02f, 0);
                }
                currentShootDistance = shootDistance + 1f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
            {
                speed *= 2f;
            }

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0) && barScript.reload == barScript.timeToReload)
            {
                ShootGun();
            }

            controller.Move(velocity * Time.deltaTime);
        }
    }

    public void ShootGun()
    {
        Vector3 rayDirection = cameraController.transform.forward;
        Debug.DrawRay(rayOrigin.position, rayDirection * currentShootDistance, Color.white, 1f);
        if (Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, currentShootDistance))
        {
            Debug.Log("Hitt: " + objectHit.transform.name);
            Vector3 moveDir = playerController.transform.position - objectHit.point;
            moveDir.Normalize();
            velocity.x += moveDir.x * 20;
            velocity.y += moveDir.y * 20;
            velocity.z += moveDir.z * 20;

        }
        else
        {
            Debug.Log("Miss");
        }

        gunSmoke.Play();
        AudioManager.PlayClip2D(shootingNoise, 100);
        barScript.reload = 0f;
    }
}
