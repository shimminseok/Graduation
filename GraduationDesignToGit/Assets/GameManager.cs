using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    [SerializeField]
    SetInfo _setInfo;

    public static GameManager _instance;

    public float _maxLab;
    public float _maxSpeed;
    public float _rotSpeed;
    public string _name;
    public string _country;


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // else
        // {
        //     Destroy(gameObject);
        // }
        // DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }

    void Update()
    {
        SetLab();
        SetInfomation();
    }
    void SetLab()
    {
        _maxLab = float.Parse(_setInfo._setLab.options[_setInfo._setLab.value].text);
        if (_maxLab == 500)
        {
            _maxLab = 4.5f;
        }
        else if (_maxLab == 1000)
        {
            _maxLab = 9;
        }
        else if (_maxLab == 1500)
        {
            _maxLab = 13.5f;
        }
        else if (_maxLab == 3000)
        {
            _maxLab = 27;
        }
    }
    void SetInfomation()
    {
        bool _isMaxspeedfloat;
        bool _isRotSpeedfloat;
        _name = _setInfo._name.text;
        _country = _setInfo._setcountry;
        _isMaxspeedfloat = float.TryParse(_setInfo._maxSpeed.text, out _maxSpeed);
        _isRotSpeedfloat = float.TryParse(_setInfo._rotSpeed.text, out _rotSpeed);
    }

}
