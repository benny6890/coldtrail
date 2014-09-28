using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	private float hunger=100f;
	private float warmth=100f;

	float woodCollected = 0f;

	public GameObject firePlace;

	public float hungerSpeed = 0.05f;
	public float freezeSpeed = 0.05f;
	public float warmUpSpeed = 1f;
	public int hSize = 34;
	public int vSize = 4;
	public int borderSize = 1;
	public int spacing = 1;
	public int offsetX = -17;
	public int offsetY = - 27;
	public Texture2D HpBarTexture;
	public Texture2D WBarTexture;
	public Texture2D BackGroundTexture;
	public GameObject blood;
	
	// Use this for initialization
	void Start () {

		StartCoroutine (Starve());
		if (HpBarTexture == null) {
			HpBarTexture = new Texture2D (1, 1, TextureFormat.ARGB32, false);
			HpBarTexture.SetPixel (0, 0, Color.green);
			HpBarTexture.Apply ();
		}
		if (WBarTexture == null) {
			WBarTexture = new Texture2D (1, 1, TextureFormat.ARGB32, false);
			WBarTexture.SetPixel (0, 0, Color.blue);
			WBarTexture.Apply ();
		}
		if (BackGroundTexture == null) {
			BackGroundTexture = new Texture2D (1, 1, TextureFormat.ARGB32, false);
			BackGroundTexture.SetPixel (0, 0, Color.black);
			BackGroundTexture.Apply ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (hunger <= 0 || warmth <= 0) {
			Instantiate(blood, this.transform.position, Quaternion.identity);
			this.gameObject.SetActive(false);

			//Quaternion.identity
		}
	
	}

	void OnGUI() {
		Vector3 pos = transform.position;
		pos.y = -pos.y;
		Vector3 temp = Camera.main.WorldToScreenPoint(pos);
		Vector2 temp2 = GUIUtility.ScreenToGUIPoint(new Vector2(temp.x,temp.y));
		DrawStatus (temp);

	}

	public void Eat(float food) {
		hunger += food;
		if (hunger > 100f) 
			hunger = 100f;
	}

	public void AddWood (float wood) {
		woodCollected += wood;
		if (woodCollected > 100f) 
			woodCollected = 100f;

	}


	void OnTriggerEnter2D( Collider2D other) {
		if (other.name == "fire_flare") {
			this.transform.GetChild(0).gameObject.SetActive(false);
			StopCoroutine ("Freeze");
			StartCoroutine ("WarmUp");
		}

		if (other.name == "fire_wood") {
			firePlace.GetComponent<FireStatus> ().AddFuel (woodCollected);
			woodCollected = 0;
		}


	}


	void OnTriggerExit2D( Collider2D other) {
		if (other.name == "fire_flare") {
			this.transform.GetChild(0).gameObject.SetActive(true);
			
			StopCoroutine ("WarmUp");
			StartCoroutine ("Freeze");
			}

	}


	IEnumerator Starve()
	{
		do {
	
			hunger -= hungerSpeed;
		yield return new  WaitForEndOfFrame();
		} while (hunger > 0f );
	}

	IEnumerator Freeze()
	{
		do {

			warmth -=  freezeSpeed;

			yield return new  WaitForEndOfFrame();
		} while (warmth > 0f );
		StopCoroutine ("Freeze");
	}

	IEnumerator WarmUp()
	{
		do {

			warmth +=  warmUpSpeed;

			yield return new  WaitForEndOfFrame();
		} while (warmth < 100f );
		StopCoroutine ("WarmUp");
	}



	void DrawStatus(Vector2 position)
	{
	
		GUI.BeginGroup (new Rect (position.x+offsetX, position.y+offsetY,hSize+2*borderSize ,2*vSize+2*borderSize+spacing));

		GUI.DrawTexture(new Rect(0 , 0,hSize+2*borderSize ,2*vSize+2*borderSize+spacing), BackGroundTexture); 
		GUI.DrawTexture(new Rect(borderSize , borderSize, Mathf.Round(hunger*hSize/100), vSize), HpBarTexture); 
		GUI.DrawTexture(new Rect(borderSize , borderSize+vSize+spacing, Mathf.Round(warmth*hSize/100), vSize), WBarTexture); 


		GUI.EndGroup ();

	}




}
