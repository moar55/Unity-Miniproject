using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	// Use this for initialization
	// public GameObject player;
	public int score = 0;
    public int actualscore = 0;
    public Material attackableEnemyMat;
    public GameObject enemyManager;
    public int speedFactor = 1;
    int threshold = 50;
    public Text scoreText;
    bool isPaused = false;

	void Start () {
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            if (isPaused) {
                Time.timeScale = 0;
                //SceneManager.UnloadSceneAsync(2);
            }
            else {
                Time.timeScale = 1;
                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            }                 
			isPaused = !isPaused;
        }

        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * 10, 0f,0f));
        scoreText.text = "Score: " + score;
		// plane2.transform.Translate(new Vector3(0f,0f,-0.1f));
		// plane1.transform.Translate(new Vector3(0f,0f,-0.1f));
		// if (Vector3.Distance(plane1.transform.position, transform.position) >= 4f) {
		// 	plane1.transform.Translate(-plane2.transform.position);
		// }
		// transform.Translate(new Vector3(0f,0f,0.1f));
	}

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.GetComponent<Renderer>().material.color == attackableEnemyMat.color) {
				score+=20;
                actualscore += 20;
                if (score >= threshold) {
                    speedFactor *= 2;
                    threshold += 50;
                }
            }

            else {
				score/=2;
            }

			//Debug.Log("HIIIT. Score is : " + score );
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "ColorChangeWall") {
            enemyManager.GetComponent<EnemyManager>().changeColor = true;
			Destroy(col.gameObject);
        }
    }
}
