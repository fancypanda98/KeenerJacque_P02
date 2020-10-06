using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaVolume : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonPlayer")
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health")-1);
        }
    }
}
