using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemySight : MonoBehaviour
{

    [SerializeField] GameObject body = null;
    [SerializeField] EnemyBehavior behavior = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        body.transform.LookAt(other.transform);
        behavior.targeting = true;
    }

    private void OnTriggerExit(Collider other)
    {
        behavior.targeting = false;
    }

}
