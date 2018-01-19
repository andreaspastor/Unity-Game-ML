using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public DeathMenu deathMenu;
	private int DiffLevel = 1;
	private int maxDiff = 10;
	private int scoreToNextLevel = 10;

	private bool isDead = false;
	private float score = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;
		if (score >= scoreToNextLevel)
			LevelUp ();
		
		score += Time.deltaTime * DiffLevel;
		scoreText.text = ((int) score).ToString ();
	}

	void LevelUp() {
		if (DiffLevel == 1000.0f*maxDiff)
			return;
		scoreToNextLevel += 10;
		DiffLevel += 1;

		GetComponent<PlayerMotor> ().SetSpeed (DiffLevel);
	}

	public void OnDeath() {
		isDead = true;
		Debug.Log (PlayerPrefs.GetFloat("HighScore"));
		Debug.Log (score > PlayerPrefs.GetFloat("HighScore"));
		if( score > PlayerPrefs.GetFloat("HighScore"))
			PlayerPrefs.SetFloat ("HighScore", score);
		deathMenu.ToggleEndMenu (score);
	}
}
