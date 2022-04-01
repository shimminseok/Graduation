using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AI_GameManage : MonoBehaviour
{
    public enum _eGameState
    {
        Ready, Play, End
    }
    public _eGameState _gameState = _eGameState.Ready;
    public AI[] _player;
    public string[] _rank = new string[4];
    public int _isRank;


    void Start()
    {
        StartCoroutine("GameState");
    }

    void Update()
    {
        GetRank();
    }
    IEnumerator GameState()
    {
        yield return new WaitForSeconds(3f);
        _gameState = _eGameState.Play;
        yield return null;
    }
    void GetRank()
    {
        for (int i = 0; i < _player.Length; i++)
        {
            if (_player[i]._playMode == AI._ePlayMode.End)
            {
                _rank[i] = _player[i].name;
            }
        }
    }
}
