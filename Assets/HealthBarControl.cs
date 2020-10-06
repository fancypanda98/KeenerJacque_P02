using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarControl : MonoBehaviour
{

    [SerializeField] GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var theBar = bar.transform as RectTransform;
        theBar.localScale = new Vector2(PlayerPrefs.GetInt("Health"), .5f);
    }
}
