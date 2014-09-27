using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class drawPath : MonoBehaviour {

	List<Path> pathList;
	int size;
	// Use this for initialization
	void Start () {
		this.pathList = this.gameObject.GetComponent<createPath> ().pathList;
		size = pathList.Count;
	}
	
	// Update is called once per frame
	void Update () {
			//	this.pathList = this.gameObject.GetComponent<createPath> ().pathList;
				Path tempPath;
				if (pathList.Count > size) {
						tempPath = pathList [size];
						//createObject (tempPath);
						size = pathList.Count;
				}
		}

	void createObject(Path objectPos) {
		float x, y,angle;
		GameObject newPath = GameObject.CreatePrimitive (PrimitiveType.Cube);

		if (objectPos.start.x < objectPos.end.x) 
						x = (objectPos.end.x - objectPos.start.x);
			else 
						x = (objectPos.start.x - objectPos.end.x);

		if (objectPos.start.y < objectPos.end.y) 
			y = (objectPos.end.y - objectPos.start.y);
		else 
			y = (objectPos.start.y - objectPos.end.y);

		if (!((x == 0) && (y == 0))) {
						if (x==0)
								angle = 90;
						else 
						        angle = Mathf.Atan (y / x)*180/Mathf.PI;
			if (y==0) 
				angle = 0;
						Vector3 rotation = new Vector3 (0f, 0f, angle);
						Vector3 length = new Vector3 (Mathf.Sqrt (x * x + y * y), 0.5f, 0.3f); 
						newPath.transform.position = new Vector3 (objectPos.start.x + x, objectPos.start.y + y, 0f);
						newPath.transform.localScale = length;
						newPath.transform.Rotate (rotation);
			Debug.Log("Drawing" + objectPos.start + " to " + objectPos.end );
			Debug.Log("Length " + length + " Angle: " + rotation );

				}
		}


}
