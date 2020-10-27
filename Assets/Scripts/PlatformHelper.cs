using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHelper : MonoBehaviour
{

    [SerializeField] Material standard;
    [SerializeField] Material pressed;
    [SerializeField] MeshRenderer plat;
    [SerializeField] PlatformTrigger trig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trig.check)
        {
            plat.material = pressed;
        }
        else
        {
            plat.material = standard;
        }
    }
}
