using UnityEngine;
using System.Collections;

public class Value : MonoBehaviour {


	public float value =20f;
	public float plopSize= 0.1f;
	// Use this for initialization
	void Start () {
		StartCoroutine ("Plop");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Plop()
	{
		Vector2 temp;
		for (int i = 0; i < 5; i++) {
			temp = transform.localScale;
			transform.localScale = new Vector2(temp.x+plopSize, temp.y+plopSize);
			yield return new  WaitForEndOfFrame ();
		}
		for (int i = 0; i < 8; i++) {
			temp = transform.localScale;
			transform.localScale = new Vector2(temp.x-plopSize, temp.y-plopSize);
			yield return new  WaitForEndOfFrame ();
		}
		for (int i = 0; i < 3; i++) {
			temp = transform.localScale;
			transform.localScale = new Vector2(temp.x+plopSize, temp.y+plopSize);
			yield return new  WaitForEndOfFrame ();
		}


		StopCoroutine ("Plop");
	}

}
