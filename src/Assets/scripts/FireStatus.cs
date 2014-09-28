using UnityEngine;
using System.Collections;

public class FireStatus : MonoBehaviour {

	private float fuel = 100f;
	public float burnSpeed = 0.05f;
	public GameObject fire;
	public GameObject border;
	public GameObject flame;

	// Use this for initialization
	void Start () {

		//fire = GameObject.Find ("fire_flare");
		Vector2 fireScale = new Vector2 (fuel / 10f, fuel / 10f);
		fire.transform.localScale = fireScale;
		border.transform.localScale = fireScale;
	

		StartCoroutine ("Burn");


	}
	
	// Update is called once per frame
	void Update () {

		Vector2 fireScale = new Vector2 (fuel / 50f, fuel / 50f);
		fire.transform.localScale = fireScale;
		border.transform.localScale = fireScale;
		if (fuel < 1f) {
			border.SetActive(false);
			fire.SetActive(false);
			flame.SetActive(false);
		} else {
			border.SetActive(true);
			fire.SetActive(true);
			flame.SetActive(true);
		}
	}

	public void AddFuel(float f)
	{
		fuel += f;
		if (fuel > 100f)
			fuel = 100f;
	}

	IEnumerator Burn()
	{
		do {

			fuel -= burnSpeed;

			yield return new  WaitForEndOfFrame();
		} while (fuel > 0 );
	}


}
