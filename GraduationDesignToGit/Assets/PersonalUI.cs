using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PersonalUI : MonoBehaviour
{
    public float _curTime;
    public Player _player;
    public Text _name;
    public Text _curSpeed;
    public Text _lab;
    public Text _time;
    public Button _reStart; 
    void Start()
    {
        _name.text = " Name : " + GameManager._instance._name;
    }

    void Update()
    {
        _player = FindObjectOfType<Player>();
        _curSpeed.text = "CurSpeed : " + _player._curSpeed.ToString();
        _lab.text = "Lab : " + _player._curLab + " / " + GameManager._instance._maxLab;
        _time.text = "Time : " + _curTime;
        if (_player.GameState == Player._eGameState.Play)
        {
            _curTime += Time.deltaTime;
        }
        UpdateUI();
        Menu.ExitGame();
    }
    void UpdateUI()
    {
        if (_player.GameState == Player._eGameState.End)
        {
            _reStart.gameObject.SetActive(true);
        }
    }
    public void ReStart()
    {
        SceneManager.LoadScene("PlayerSetting");
    }
}
