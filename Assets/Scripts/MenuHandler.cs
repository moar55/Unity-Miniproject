using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {
    public AudioSource gameMusic;
    AudioSource menuAudioSource;

    void Start() {
        gameMusic = GameObject.Find("GameMusicHandler").GetComponent<AudioSource>();
        menuAudioSource = GameObject.Find("MenuMusicHandler").GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update () {
	}

    public void GoBackToOptions() {
        SceneManager.UnloadSceneAsync(4);
    }

    public void GoBackToOptions2()
    {
        SceneManager.UnloadSceneAsync(6);
    }

    public void GoBackToMainMenu() {
        SceneManager.UnloadSceneAsync(3);
    }

    public void LoadOptionsScreen() {
        SceneManager.LoadScene("OptionsScreen", LoadSceneMode.Additive);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
    }

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void ResumeGame() {
        gameMusic.UnPause();
        menuAudioSource.Stop();
        SceneManager.UnloadSceneAsync(2);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("isPaused", 0);
    }

    public void MuteOrUnMuteSound(){
        if (PlayerPrefs.GetInt("muteSound", 0) == 0) {
			PlayerPrefs.SetInt("muteSound", 1);
			GameObject.Find("MenuMusicHandler").GetComponent<AudioSource>().Stop();
        } else {
			PlayerPrefs.SetInt("muteSound", 0);
            GameObject.Find("MenuMusicHandler").GetComponent<AudioSource>().Play();
        } 

    }

    public void LoadHowToPlay() {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Additive);
    }

    public void Quit() {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
