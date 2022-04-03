using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AI_EndUI : MonoBehaviour
{
    public AI_GameManage _aiManager;
    public Text[] _rank;
    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            _rank[i].text = _aiManager._player[i].name + " : " + _aiManager._player[i]._curTime + " " + _aiManager._player[i]._curLab + " / " + _aiManager._player[i]._maxLab;
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("AISetting");
    }

}
