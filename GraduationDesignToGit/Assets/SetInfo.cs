using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetInfo : MonoBehaviour
{


    public InputField _name;
    public InputField _maxSpeed;
    public InputField _rotSpeed;
    public GameObject[] _character;
    public Dropdown _setLab;

    Button _start;
    Button _backMenu;
    Sprite[] _sprites;
    Dropdown _setCountry;
    public string _setcountry;
    void Start()
    {
        _start = GetComponentInChildren<Button>();
        _setCountry = GetComponentInChildren<Dropdown>();
    }

    void Update()
    {
        SetCountry();
        SetCharacter();
    }
    void SetCountry()
    {
        _setcountry = _setCountry.options[_setCountry.value].text;
    }
    void SetCharacter()
    {
        if (_setcountry == "Korea")
        {
            _character[0].gameObject.SetActive(true);
            _character[1].gameObject.SetActive(false);
            _character[2].gameObject.SetActive(false);
            _character[3].gameObject.SetActive(false);
        }
        else if (_setcountry == "China")
        {
            _character[0].gameObject.SetActive(false);
            _character[1].gameObject.SetActive(true);
            _character[2].gameObject.SetActive(false);
            _character[3].gameObject.SetActive(false);
        }
        else if (_setcountry == "Russia")
        {
            _character[0].gameObject.SetActive(false);
            _character[1].gameObject.SetActive(false);
            _character[2].gameObject.SetActive(true);
            _character[3].gameObject.SetActive(false);
        }
        else if (_setcountry == "NetherLand")
        {
            _character[0].gameObject.SetActive(false);
            _character[1].gameObject.SetActive(false);
            _character[2].gameObject.SetActive(false);
            _character[3].gameObject.SetActive(true);
        }
    }
    public void GameStart()
    {
        SceneManager.LoadScene("PersonalPlay");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
