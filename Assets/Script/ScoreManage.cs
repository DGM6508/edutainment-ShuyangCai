using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManage : MonoBehaviour
{

    Text text;                      

    void Awake()
    {
        text = GetComponent<Text>();
    }


    void Update()
    {
        text.text = "Clicks: "+Card_GameManager.clickTimes;
    }
}