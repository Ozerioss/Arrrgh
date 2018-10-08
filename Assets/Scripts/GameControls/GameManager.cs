using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool gameEnded = false;
    public float endDelay = 0.5f;
    public int lastScore = 0;
    string finalScoreTxtName = "FinalScore";
    string gameOverSceneName = "GameOver";
    public GameObject completeLevelUI;
    #region Player prefs && data
    string lastScoreSaveName = "LastScore";
    string bestScoreSaveName = "BestScore";
    string lastLevelSaveName = "LastLevelPlayed";
    #endregion

    public void CompleteLevel() {
        completeLevelUI.transform.Find(finalScoreTxtName).GetComponent<Text>().text = FindObjectOfType<Score>().ScoreValue.text;
        completeLevelUI.SetActive(true);
    }

    public void GameOver() {
        //Saving last score and updating best score
        PlayerPrefs.SetInt(lastScoreSaveName, Convert.ToInt32(FindObjectOfType<Score>().ScoreValue.text));
        //Remembering last level played
        PlayerPrefs.SetInt(lastLevelSaveName, SceneManager.GetActiveScene().buildIndex);

        int lastScoreSaved = PlayerPrefs.GetInt(lastScoreSaveName, 0);
        int bestScoreSaved = PlayerPrefs.GetInt(bestScoreSaveName, 0);
        if(lastScoreSaved > bestScoreSaved)
            PlayerPrefs.SetInt(bestScoreSaveName, lastScoreSaved);
        
        SceneManager.LoadScene(gameOverSceneName);
    }


    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}