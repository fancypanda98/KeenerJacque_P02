using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] float lifetimeSeconds = 5f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject canvas3;

    // Start is called before the first frame update
    void Start()
    {
        lifetimeSeconds *= 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Pause") == 1)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.Rotate(0f, 0f, 2f, Space.Self);
            lifetimeSeconds--;
            if (lifetimeSeconds == 0)
            {
                bullet.SetActive(false);
            }
        }
    }
}
