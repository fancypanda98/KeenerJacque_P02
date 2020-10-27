using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{

    [SerializeField] Level01Controller lc;
    [SerializeField] AudioClip noise;

    public bool check;
    public bool pin;
    public int val;

    // Start is called before the first frame update
    void Start()
    {
        check = false;
        pin = false;
        val = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!check)
        {
            lc.IncreaseScore(1);
            AudioManager.PlayClip2D(noise, 100f);
        }
        check = true;
        Debug.Log("AHH");
        pin = false;
    }

    private void OnTriggerExit(Collider other)
    {
        pin = true;
    }

}
