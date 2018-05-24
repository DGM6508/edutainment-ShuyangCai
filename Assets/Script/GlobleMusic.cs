using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobleMusic : MonoBehaviour {

    public GameObject globleMusic;
    GameObject myMusic;

	void Start () {
        myMusic = GameObject.FindGameObjectWithTag("GlobleMusic");
        if (myMusic==null)
        {
            myMusic = (GameObject)Instantiate(globleMusic);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
