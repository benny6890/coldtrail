using UnityEngine;
using System.Collections;

public class SpawnItems : MonoBehaviour {

	public float sizeX = 5f;
	public float sizeY = 5f;
	public int nrMaxFood = 5;
	public int nrMaxWood = 5;
	public float radiusFire = 2f;
	public GameObject wood;
	public GameObject food;
	public GameObject wolf;
	private int woodSpawned;

	// Use this for initialization
	void Start () {

		Vector3 temp;


		for (int i = 0;i<3; i++) {
			temp = getRandomPoint ();
			Instantiate (wood, temp, Quaternion.identity);
		}

		for (int i = 0;i<3; i++) {
			temp = getRandomPoint ();
			Instantiate (food, temp, Quaternion.identity);
		}

	}


	Vector3 getRandomPoint()	{
		float x, y;
	
		do {
			x = Random.Range (-sizeX / 2, sizeX / 2);
			y = Random.Range (-sizeY / 2, sizeY / 2);
		} while(((x>-radiusFire)&&(x<radiusFire))||((y>-radiusFire)&&(y<radiusFire)));

		return new Vector3 (x, y,0f);
	}

	// Update is called once per frame
	void Update () {
	
	}

/*	IEnumerator SpawnWood()
	{


	} */

}
