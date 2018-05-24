using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEManage : MonoBehaviour {

    public GUISkin menuSkin;
    public Rect menuArea;
    public Rect restartButton;

    public AudioClip beep;
    AudioSource buttonSound;

    Rect menuAreaNormalized;
    string menuPage = "main";

    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
        buttonSound.clip = beep;
        menuAreaNormalized =
            new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
    }
    void OnGUI()
    {
        GUI.skin = menuSkin;
        GUI.BeginGroup(menuAreaNormalized);
        GUI.skin.button.fontSize = 32;

        if (GUI.Button(new Rect(restartButton), "Restart"))
        {
            buttonSound.Play();
            StartCoroutine("WaitForMusic", 0.6f);
        }


        GUI.EndGroup();
    }

    public IEnumerator WaitForMusic(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Card_GameManager.clickTimes = 40;
        Card_GameManager.cardNum = 16;
        Application.LoadLevel("MenuScene");

    }
}
