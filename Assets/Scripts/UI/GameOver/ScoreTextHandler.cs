using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextHandler : MonoBehaviour {

	public ScoreType type;
	public TextMeshProUGUI score;

	string lastScoreSaveName = "LastScore";
	string bestScoreSaveName = "BestScore";
	// Use this for initialization
	void Start() {
		if (type == ScoreType.LastScore)
			score.text = PlayerPrefs.GetInt(lastScoreSaveName, 0).ToString();

		if (type == ScoreType.BestScore)
			score.text = PlayerPrefs.GetInt(bestScoreSaveName, 0).ToString();
	}

	// Update is called once per frame
	void Update() {
		// lastScore.text = PlayerPrefs.GetInt(lastScoreSaveName, 0).ToString();
	}
}