using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHelper : MonoBehaviour
{

    [SerializeField] Material standard;
    [SerializeField] Material pressed;
    [SerializeField] MeshRenderer plat;
    [SerializeField] PlatformTrigger trig;

    public bool on = false;
    public bool pint = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pint = trig.pin;
        on = trig.check;
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
