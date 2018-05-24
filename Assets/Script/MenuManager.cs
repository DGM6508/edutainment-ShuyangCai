using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public AudioClip beep;
    public GUISkin menuSkin;
    public Rect menuArea;
    public Rect playButton;
    public Rect instructionsButton;
    public Rect quitButton;
    public Rect instructions;
    Rect menuAreaNormalized;
    string menuPage = "main";
    AudioSource buttonSound;

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

        if (GUI.Button(new Rect(playButton), "play"))
        {
            buttonSound.Play();
            StartCoroutine("ButtonAction", "GameScene");
        }
        if (GUI.Button(new Rect(instructionsButton), "Instructions"))
        {
            buttonSound.Play();
            StartCoroutine("ButtonAction", "InstructionScene");

        }
        if (GUI.Button(new Rect(quitButton), "Quit"))
        {
            buttonSound.Play();
            StartCoroutine("ButtonAction", "quit");
        }
        
        
        GUI.EndGroup();
    }
    IEnumerator ButtonAction(string levelName)
    {

        yield return new WaitForSeconds(0.35f);

        if (levelName != "quit")
        {
            Application.LoadLevel(levelName);
        }
        else
        {
            Application.Quit();
            Debug.Log("Have Quit");
        }
    }

}