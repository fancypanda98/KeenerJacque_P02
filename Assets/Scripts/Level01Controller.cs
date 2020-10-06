using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{

    [SerializeField] Text _currentScoreTextView;

    int _currentscore = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel();
        }
    }

    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");

        if(_currentscore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentscore);
            Debug.Log("New high score: " + _currentscore);
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _currentscore += scoreIncrease;
        _currentScoreTextView.text = "Score: " + _currentscore.ToString();
    }
}
