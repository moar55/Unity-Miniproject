using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void LoadMenuScreen() {
        SceneManager.LoadScene("MenuScreen");
    }

    public void LoadOptionsScreen() {
        SceneManager.LoadScene("OptionsScreen");
    }

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void ResumeGame() {
        SceneManager.UnloadSceneAsync(2);
    }

    public void Quit() {
        Application.Quit();
    }
}
