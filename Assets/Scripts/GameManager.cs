using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public Player player;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
/*    public Text bestScore;*/
    private void Awake()
    {
        Application.targetFrameRate = 60;
        setActiveness(true,false,true);
        
        Pause();
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        setActiveness(false, false, false);

        Time.timeScale = 1f;
        
        player.enabled = true;
        
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i=0;i< pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        setActiveness(true, true, false);
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    private void setActiveness(bool playButtonEnabled,bool gameOverEnabled,bool getReadyEnabled)
    {
        playButton.SetActive(playButtonEnabled);
        gameOver.SetActive(gameOverEnabled);
        getReady.SetActive(getReadyEnabled);
    }

}
