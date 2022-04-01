using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_EndUI : MonoBehaviour
{
    public Text[] _rank;


    void Start()
    {

    }

    void Update()
    {
        Rank();
    }
    void Rank()
    {
        for (int i = 0; i < _rank.Length; i++)
        {
            _rank[i].text = " Record : " + AI._record;
        }
    }
}
