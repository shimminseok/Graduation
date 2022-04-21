using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    public GameObject[] _cam;
    public int i = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (i < 3)
            {
                i++;
                _cam[i].SetActive(true);
                _cam[i - 1].SetActive(false);
            }
            else
            {
                i = 0;
                _cam[0].SetActive(true);
                _cam[3].SetActive(false);
            }


        }
    }
}
