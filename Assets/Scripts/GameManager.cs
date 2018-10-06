using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameEnded = false;
    public float endDelay = 0.5f;
    public int lastScore = 0;

    public void GameOver()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            lastScore = Convert.ToInt32(FindObjectOfType<Score>().ScoreValue.text);
            Debug.Log("Over : "+lastScore);

            Invoke("Restart", endDelay);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
