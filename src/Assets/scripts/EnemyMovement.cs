using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public bool isHuntingPlayer = true; 
	GameObject huntedPlayer;

	public int numberOfPlayers = 4;
	public int minX= -10;
	public int maxX = 10;
	public int minY = -10;
	public int maxY = 10;
	Vector3 nextPosition;

	//Vector2 moveTowards;
	public int speed = 10;
	public float randomMovementSpeed = 0.5f;

	public float minimumRunningDistance = 0.3f; 

	// Use this for initialization
	void Start () {
		//set hunted player to a random player
		GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
		int huntPlayer = Random.Range (0, allPlayers.Length - 1);
		huntedPlayer = allPlayers[huntPlayer];
				nextPosition = new Vector3(Random.Range(minX,maxX), Random.Range(minY, maxY),0);
		
		


		//todo only take alive players && random??

	}
	
	// Update is called once per frame
	void Update () {

		if (isHuntingPlayer) {
						Vector2 velocity = new Vector2 ((transform.position.x - huntedPlayer.transform.position.x), (transform.position.y - huntedPlayer.transform.position.y));
						velocity.Normalize ();
			rigidbody2D.velocity = -velocity * speed * Time.deltaTime;
		
				} else {
						//run around randomly
			if((Mathf.Abs(transform.position.x - nextPosition.x) < minimumRunningDistance) && (Mathf.Abs(transform.position.y - nextPosition.y ) < minimumRunningDistance)){
				nextPosition = new Vector3(Random.Range(minX,maxX), Random.Range(minY, maxY),0);
			}
				Vector2 velocity = new Vector2 ((transform.position.x - nextPosition.x), (transform.position.y - nextPosition.y));
				velocity.Normalize ();
				rigidbody2D.velocity = -velocity * speed * Time.deltaTime;
				

				}

	}

	private void OnTriggerEnter2D( Collider2D other) {
				if (other.name.Substring (0, 6).Equals ("player")) {
						isHuntingPlayer = false;
						numberOfPlayers --;
						other.transform.root.gameObject.tag = "dead";
						Destroy (other.transform.root.gameObject);


						GameObject[] allPlayers = GameObject.FindGameObjectsWithTag ("Player");
						if (allPlayers.Length > 0) {
								int huntPlayer = Random.Range (0, allPlayers.Length - 1);
								huntedPlayer = allPlayers [huntPlayer];
								isHuntingPlayer = true;
			
						} else {
								isHuntingPlayer = false;

						}
		
				}
		}



	public void switchPlayerToAttack(){


	}

}
