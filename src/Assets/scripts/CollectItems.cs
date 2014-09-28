using UnityEngine;
using System.Collections;

public class CollectItems : MonoBehaviour {

	public GameObject game_logic;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.Log ("Enter:" + other.name);
		if (other.name =="wood1(Clone)") {
			this.GetComponent<PlayerStatus>().AddWood(other.GetComponent<Value>().value);
			game_logic.GetComponent<SpawnItems> ().WoodCollected ();
			Destroy (other.gameObject);
			}
		if (other.name == "food1(Clone)") {
			this.GetComponent<PlayerStatus> ().Eat (other.GetComponent<Value> ().value);
			game_logic.GetComponent<SpawnItems> ().FoodCollected ();
			Destroy (other.gameObject);
		}
	}


}
