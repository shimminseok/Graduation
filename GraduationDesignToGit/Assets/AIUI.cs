using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AIUI : MonoBehaviour
{
    public Text _setLab;
    public Button _back;
    public Button _start;
    public Dropdown _setleb;

    static public float _settingLab;
    void Start()
    {

    }

    void Update()
    {
        SetLab();
        Menu.ExitGame();

    }
    void SetLab()
    {
        _setLab.text = _setleb.options[_setleb.value].text;
        if (_setLab.text == "500M")
        {
            _settingLab = 4.5f;
        }
        else if (_setLab.text == "1000M")
        {
            _settingLab = 9f;
        }
        else if (_setLab.text == "1500M")
        {
            _settingLab = 13.5f;
        }
        else if (_setLab.text == "3000M")
        {
            _settingLab = 27f;
        }

    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("AI");
    }
}
