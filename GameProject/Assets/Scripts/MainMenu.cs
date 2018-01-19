using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Text highscoreText;
	// Use this for initialization
	void Start () {
		highscoreText.text = "Highscore : " + ((int) PlayerPrefs.GetFloat("HighScore")).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToGame() {
		SceneManager.LoadScene ("Game");
	}
}
