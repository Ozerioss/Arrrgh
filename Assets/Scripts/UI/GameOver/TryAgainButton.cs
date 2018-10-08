using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour {

	string lastLevelSaveName = "LastLevelPlayed";

	public void ReloadLastLevel() {
		//the default value is 1, so that it replays the first level is no value is saved
		int indexLastLevel = PlayerPrefs.GetInt(lastLevelSaveName, 1);
		SceneManager.LoadScene(indexLastLevel);
	}
}