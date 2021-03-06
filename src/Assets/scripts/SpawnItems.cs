﻿using UnityEngine;
using System.Collections;

public class SpawnItems : MonoBehaviour {

	public float sizeX = 5f;
	public float sizeY = 5f;
	public int nrMaxFood = 5;
	public int nrMaxWood = 5;
	public int nrMaxWolfs = 5;
	public float radiusFire = 2f;
	public Vector2 ItemSpawnTime = new Vector2 (1.0f, 5.0f);
	public Vector2 EnemySpawnTime = new Vector2 (2.0f, 5.0f);
	public GameObject wood;
	public GameObject food;
	public GameObject wolf;
	private int woodSpawned;
	private int foodSpawned;
	private int wolfSpawned;

	public GameObject[] players;

	// Use this for initialization
	void Start () {

		Vector3 temp;
		woodSpawned=0;
		foodSpawned=0;
		wolfSpawned=0;

		for (int i = 0;i<3; i++) {
			temp = GetRandomPoint ();
			Instantiate (wood, temp, Quaternion.identity);
			woodSpawned++;
		}

		for (int i = 0;i<3; i++) {
			temp = GetRandomPoint ();
			Instantiate (food, temp, Quaternion.identity);
			foodSpawned++;
		}

		StartCoroutine ("SpawnWood");
		StartCoroutine ("SpawnFood");
		StartCoroutine ("SpawnWolf");

	}

	public void ResetGame (){
		StopCoroutine ("SpawnWood");
		StopCoroutine ("SpawnFood");
		StopCoroutine ("SpawnWolf");

		GameObject fire = GameObject.Find ("fire_flare");
		fire.GetComponent<FireStatus> ().AddFuel (100f);

		GameObject[] objlist = GameObject.FindGameObjectsWithTag ("item");
		for (int i = 0; i< objlist.Length; i++)
			Destroy (objlist [i]);
	
		for (int i = 0; i< players.Length; i++) {
			players [i].SetActive (true);
			players[i].GetComponent<PlayerStatus>().ResetPlayer ();
		}


		this.Start ();

	}






	public void WoodCollected (){
		if (woodSpawned > 0) 
			woodSpawned--;
	}

	public void FoodCollected() {
		if (foodSpawned > 0)
			foodSpawned--;
	}


	Vector3 GetRandomPoint()	{
		float x, y;
	
		do {
			x = Random.Range (-sizeX / 2, sizeX / 2);
			y = Random.Range (-sizeY / 2, sizeY / 2);
		} while(((x>-radiusFire)&&(x<radiusFire))||((y>-radiusFire)&&(y<radiusFire)));

		return new Vector3 (x, y,0f);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) 
			ResetGame();
	}

	IEnumerator SpawnWood()
	{
		float time;


		do {

			time = Random.Range (ItemSpawnTime.x, ItemSpawnTime.y);
			Vector2 temp = GetRandomPoint ();

			if (woodSpawned < nrMaxWood) {
				Instantiate (wood, temp, Quaternion.identity);
				woodSpawned++;
			}
			yield return new WaitForSeconds (time);
		} while (true );

	} 


	IEnumerator SpawnWolf()
	{
		float time;


		do {

			time = Random.Range (EnemySpawnTime.x, EnemySpawnTime.y);
			Vector2 temp = GetRandomPoint ();

			if (wolfSpawned < nrMaxWolfs) {
				Instantiate (wolf, temp, Quaternion.identity);
				wolfSpawned++;
			}
			yield return new WaitForSeconds (time);
		} while (true );

	} 

	IEnumerator SpawnFood()
	{
		float time;

		do {

			time = Random.Range (ItemSpawnTime.x, ItemSpawnTime.y);
			Vector2 temp = GetRandomPoint ();

			if (foodSpawned < nrMaxFood) {
				Instantiate (food, temp, Quaternion.identity);
				foodSpawned++;
			}
			yield return new WaitForSeconds (time);
		} while (true );

	} 


}
