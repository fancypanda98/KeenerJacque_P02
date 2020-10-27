using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{

    [SerializeField] Level01Controller lc;

    public bool check;

    // Start is called before the first frame update
    void Start()
    {
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        lc.IncreaseScore(1);
        check = true;
        Debug.Log("AHH");
    }

}
