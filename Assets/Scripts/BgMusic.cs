using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour {
    public AudioSource audioSource;

    private void Awake() {
		DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("muteSound", 0) == 0)
            audioSource.Play();
    }
}
