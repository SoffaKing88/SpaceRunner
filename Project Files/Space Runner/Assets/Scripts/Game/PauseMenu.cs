using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseUI;

	private bool paused = false;
	private bool startWait = false;

	void Start(){
		pauseUI.SetActive (false);
	}

	void Update() {
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused && !startWait) {
			pauseUI.SetActive (true);
			Time.timeScale = 0;
		} else if (!paused) {
			pauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Resume(){
		paused = false;
	}

	public void Restart() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void mainMenu(){
		SceneManager.LoadScene ("Main Menu");
	}

	public void Quit(){
		Application.Quit ();
	}
}
