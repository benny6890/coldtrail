using UnityEngine;
using System.Collections;

public class MovementPlayer : MonoBehaviour {


	private float force = 100f;					/**<force applied to the player object */
	private float maxSpeed = 5f;	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

				float h = Input.GetAxis ("Horizontal");
				float v = Input.GetAxis ("Vertical");

				/* add force to the player GameObject */
				if (h * rigidbody2D.velocity.x < maxSpeed)
						rigidbody2D.AddForce (Vector2.right * h * force);
		
				/* stop acceleration if maxSpeed is reached */
				if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, 0f);



				/* add force to the player GameObject */
				if (v * rigidbody2D.velocity.y < maxSpeed)
						rigidbody2D.AddForce (Vector2.up * v * force);
		
				/* stop acceleration if maxSpeed is reached */
				if (Mathf.Abs (rigidbody2D.velocity.y) > maxSpeed)
						rigidbody2D.velocity = new Vector2 (0f, Mathf.Sign (rigidbody2D.velocity.y) * maxSpeed);
		}
}
