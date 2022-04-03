using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Button _personalPlay;
    Button _aiPlay;
    void Start()
    {
        _personalPlay = GetComponentInChildren<Button>();
        _aiPlay = GetComponentInChildren<Button>();
    }

    void Update()
    {

    }
    public void PersonalPlay()
    {
        SceneManager.LoadScene("PlayerSetting");
    }
    public void AIPlay()
    {
        SceneManager.LoadScene("AISetting");
    }
}
