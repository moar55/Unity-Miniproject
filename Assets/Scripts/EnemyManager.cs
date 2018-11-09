using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	float spawnTime = 1f;
    float colorChangeTime = 6f;
    public GameObject[] enemies; // enemies prefabs
    public GameObject[] colorChangeWalls; //colorChangeWall prefabs
    public Material attackableEnemyMat;
    public Material[] materials;
    public bool changeColor;
    float[] possibleXLocations;
    int currColorIndex = -1;

	// Use this for initialization	
	void Start () {
        changeColor = false;
        possibleXLocations = new float[]{ 8.3f, 4.91f,1.22f};
        attackableEnemyMat.color = materials[2].color;
        currColorIndex = 2;
		InvokeRepeating("Spawn", spawnTime, spawnTime);
        InvokeRepeating("CreateColorChangeWall", colorChangeTime, colorChangeTime);

	}

    void CreateColorChangeWall() {
        int index = Random.Range(0, 3);
        while (index == currColorIndex) 
            index = Random.Range(0, 3);

        Instantiate(colorChangeWalls[index]);
        currColorIndex = index;
    }

    void Spawn()
    {
        // newPosition.z+= 10f;
        Instantiate(enemies[Random.Range(0, 3)], new Vector3(possibleXLocations[Random.Range(0, 3   )], 0.55f, -0.76f), transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        if (changeColor) {
            Material currMat = materials[currColorIndex];
            attackableEnemyMat.color = currMat.color;
			GameObject.Find("Player").GetComponent<Renderer>().material = currMat;
            changeColor = false;
        }
	}
}
