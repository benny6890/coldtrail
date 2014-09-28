using UnityEngine;
using System.Collections;

public class AudioSystem : MonoBehaviour {


	AudioSource BGMAudio;
	AudioSource SFX;

	public AudioClip collectFood;
	public AudioClip collectWood;
	public AudioClip step;
	public AudioClip death;
	public AudioClip[] BGM;


	public float volumeBGM = 0.7f;
	public float volumeSFX = 0.8f;

	// Use this for initialization
	void Start () {

		BGMAudio = this.gameObject.AddComponent<AudioSource> ();
		SFX = this.gameObject.AddComponent<AudioSource> ();
		BGMAudio.clip = BGM[0];
		BGMAudio.volume = volumeBGM;
		BGMAudio.loop = true;
		SFX.volume = volumeSFX;

		PlayBgm ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.N)) 
			SwitchBGMMusic ();	
	}

	public void PlayBgm() {
		BGMAudio.Play ();
	}

	public void StopBgm() {
		BGMAudio.Stop ();
	}

	public void PlayCollectWood() {
		SFX.clip = collectWood;
		SFX.Play ();
	}
	public void PlayCollectFood() {
		SFX.clip = collectFood;
		SFX.Play ();
	}

	public void PlayStep() {
		SFX.clip = step;
		SFX.Play ();
	}

	public void PlayDeath() {
		SFX.clip = death;
		SFX.Play ();
	}

	public void SwitchBGMMusic() {
		BGMAudio.Stop ();
		BGMAudio.clip =BGM[Mathf.RoundToInt (Random.Range (1.0f, BGM.Length-1))];
		BGMAudio.Play ();
	}

}
