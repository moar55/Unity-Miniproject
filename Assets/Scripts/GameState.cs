using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
    public Button pause;
    public Button switchCam;
    public Camera top;
    public Camera third;

	// Use this for initialization
	void Start () {
        top.enabled = false;
        PlayerPrefs.SetInt("isPaused",0);
        if (Application.platform != RuntimePlatform.Android)
        {
            pause.gameObject.SetActive(false);
            switchCam.gameObject.SetActive(false);
        }
        else
        {
            pause.onClick.AddListener(PauseGame);
            switchCam.onClick.AddListener(SwitchCam);
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            if (Input.GetKeyDown("escape"))
            {
                PauseGame();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                SwitchCam();
            }
        }
    }

    public void PauseGame()
    {
        int newVal;
        if (PlayerPrefs.GetInt("isPaused") == 1)
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync(2);
            newVal = 0;
        }
        else
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            newVal = 1;
        }
        PlayerPrefs.SetInt("isPaused", newVal);
    }

    public void SwitchCam()
    {
        third.enabled = !third.enabled;
        top.enabled = !top.enabled;
    }
}
