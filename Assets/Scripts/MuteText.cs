using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteText : MonoBehaviour {

    Text muteText;
	// Use this for initialization
	void Start () {
        muteText = gameObject.GetComponent<Button>().GetComponentInChildren<Text>();
     
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("muteSound", 0) == 1)
            muteText.text = "Unmute Sound";
        else
            muteText.text = "Mute Sound";  		
	}
}
