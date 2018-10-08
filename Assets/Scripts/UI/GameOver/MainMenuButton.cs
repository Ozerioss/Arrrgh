using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour {

	//The menu scene is the first of all
	int mainMenuIndex = 0;
	public void LoadMainMenu() {
		SceneManager.LoadScene(mainMenuIndex);
	}
}
