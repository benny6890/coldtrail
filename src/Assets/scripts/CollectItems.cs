using UnityEngine;
using System.Collections;

public class CollectItems : MonoBehaviour {

	public GameObject gameLogic;
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
			gameLogic.GetComponent<SpawnItems> ().WoodCollected ();
			gameLogic.GetComponent<AudioSystem> ().PlayCollectWood ();
			Destroy (other.gameObject);
			}
		if (other.name == "food1(Clone)") {
			this.GetComponent<PlayerStatus> ().Eat (other.GetComponent<Value> ().value);
			gameLogic.GetComponent<SpawnItems> ().FoodCollected ();
			gameLogic.GetComponent<AudioSystem> ().PlayCollectFood ();
			Destroy (other.gameObject);
		}
	}


}
