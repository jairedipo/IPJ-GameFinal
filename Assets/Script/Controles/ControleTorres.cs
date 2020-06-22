using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTorres : MonoBehaviour
{
    int progressaoAntiga = 0;
    public GameObject[] torres;

    void Update()
    {
        if(progressaoAntiga != GameManager.progressao)
        {
            for(int i = 0; i < GameManager.progressao; i++)
            {
                torres[i].SetActive(true);
            }
        }
    }
}
