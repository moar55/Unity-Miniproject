using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {

	public GameObject wall1;
	public GameObject wall2;
	Renderer rendWall1, rendWall2;
	float scrollSpeed = 0.5f;
    public GameObject player;

	// Use this for initialization
	void Start () {
		rendWall1 = wall1.GetComponent<Renderer>();
		rendWall2 = wall2.GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * scrollSpeed;
        rendWall1.material.SetTextureOffset("_MainTex", new Vector2(0, -offset * player.GetComponent<Player>().speedFactor));
        rendWall2.material.SetTextureOffset("_MainTex", new Vector2(0, offset * player.GetComponent<Player>().speedFactor));
	}
}
