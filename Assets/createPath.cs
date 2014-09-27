using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class createPath : MonoBehaviour {


	private Vector2 lastPos;
	public List<Path> pathList {get; private set;}

	// Use this for initialization
	void Awake() {
		lastPos = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		pathList = new List<Path>();
		StartCoroutine (RecordPath ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator RecordPath()
	{
				do {
						Vector2 currentPos = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
						if (!(lastPos == currentPos)) {
								Path temp = new Path (currentPos, lastPos, Time.time);
								pathList.Add (temp);
								lastPos = currentPos;
						}

						yield return new WaitForSeconds (1.0f);
				} while (true);
		}
}
