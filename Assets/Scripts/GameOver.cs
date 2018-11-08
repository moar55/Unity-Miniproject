using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text finalScore;
    public AudioSource menuAudioSource;
	// Use this for initialization
	void Start () {
        finalScore.text = "Score: " + PlayerPrefs.GetInt("finalScore");
        menuAudioSource = GameObject.Find("MenuMusicHandler").GetComponent<AudioSource>();
        menuAudioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
