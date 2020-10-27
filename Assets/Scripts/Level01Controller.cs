using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{

    [SerializeField] Text _currentScoreTextView;
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _canvas3;

    int _currentscore = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Reach 1");
        _canvas.SetActive(false);
        Vector3 temp = new Vector3(0f, 5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanvas();
        }

        if(PlayerPrefs.GetInt("Health") == 0){
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
        Cursor.lockState = CursorLockMode.None;
        PlayerPrefs.SetInt("Health", 3);
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _currentscore += scoreIncrease;
        _currentScoreTextView.text = "Score: " + _currentscore.ToString();
    }

    public void ToggleCanvas()
    {
        _canvas.SetActive(!_canvas.activeSelf);
        _canvas3.SetActive(!_canvas3.activeSelf);

        if(PlayerPrefs.GetInt("Pause") == 0)
        {
            PlayerPrefs.SetInt("Pause", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Pause", 0);
        }

        if (_canvas.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void TakeDamage()
    {
        Debug.Log("hit");
    }
}
