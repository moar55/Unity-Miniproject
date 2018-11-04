using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	// Use this for initialization
	public int score = 0;
    public int actualscore = 0;
    public Material attackableEnemyMat;
    public GameObject enemyManager;
    public int speedFactor = 1;
    int threshold = 50;
    public Text scoreText;

    // Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android) {
            transform.Translate(Input.acceleration.x, 0f,0f);
        } else {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position -= transform.right * Time.deltaTime * 10;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * 10;
            }
            else
            {
                transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * 10, 0f, 0f));
            }
        }
     
        scoreText.text = "Score: " + score;
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
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "ColorChangeWall") {
            enemyManager.GetComponent<EnemyManager>().changeColor = true;
			Destroy(col.gameObject);
        }
    }
}
