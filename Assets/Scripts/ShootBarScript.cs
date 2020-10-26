using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootBarScript : MonoBehaviour
{
    
    [SerializeField] GameObject bar;

    public float timeToReload = 60f;
    public float reload = 0f;

    // Start is called before the first frame update
    void Start()
    {
        reload = timeToReload;
    }

    // Update is called once per frame
    void Update()
    {
        reload = Math.Min(timeToReload , (reload + 1f) );
        var theBar = bar.transform as RectTransform;
        theBar.localScale = new Vector2((reload/timeToReload)*3f, .5f);
    }


}
