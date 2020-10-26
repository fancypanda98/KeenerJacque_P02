using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] float shootCooldown = 180f;

    public bool targeting;


    // Start is called before the first frame update
    void Start()
    {
        targeting = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
