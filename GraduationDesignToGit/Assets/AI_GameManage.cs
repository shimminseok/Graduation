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
    public GameObject _track;

    public AI[] _player;
    public string[] _rank;
    public static float[] _rankTime = new float[4];
    void Start()
    {
        StartCoroutine("GameState");
    }

    void Update()
    {
        GetRank();
        Menu.ExitGame();

    }
    IEnumerator GameState()
    {
        yield return new WaitForSeconds(3f);
        _gameState = _eGameState.Play;
        yield return null;
    }
    void GetRank()
    {
        if (_player[0]._playMode == AI._ePlayMode.End &&
        _player[1]._playMode == AI._ePlayMode.End &&
        _player[2]._playMode == AI._ePlayMode.End &&
        _player[3]._playMode == AI._ePlayMode.End)
        {
            for (int i = 0; i < _player.Length; i++)
            {
                _rank[i] = _player[i].name;
                _rankTime[i] = _player[i]._curTime;

            }
            _gameState = _eGameState.End;
            _track.SetActive(false);
        }
    }
    // public int getRank(string name)
    // {
    //     int rank = 0;
    //     foreach (string tmp in _rank)
    //     {
    //         if (tmp.Equals(name))
    //             return rank;
    //         ++rank;
    //     }
    //     return -1;
    // }
}
