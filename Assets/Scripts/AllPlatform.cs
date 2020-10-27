using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlatform : MonoBehaviour
{

    [SerializeField] PlatformHelper one;
    [SerializeField] PlatformHelper two;
    [SerializeField] PlatformHelper three;
    [SerializeField] PlatformHelper four;
    [SerializeField] PlatformTrigger five;
    [SerializeField] PlatformTrigger six;
    [SerializeField] PlatformTrigger seven;
    [SerializeField] PlatformTrigger eight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(one.on && two.on && three.on && four.on)
        {
            if (one.pint && two.pint && three.pint && four.pint)
            {
                five.check = false;
                six.check = false;
                seven.check = false;
                eight.check = false;
            }
        }
    }
}
