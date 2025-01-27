using TMPro;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText; 
    public AudioSource deadendost;
    //change 1: adding audio source to play results screen music
    public AudioSource resultScreenMusic;
    public GameObject highestScoreText; // GameObject that shows a "New High Score" message
    public GameObject DeadEndText;
    public GameObject NormalEndText;
    public GameObject DeadEndImage;
    public GameObject NormalEndImage;

    public DataPersistanceManager dpm;
    //public GameObject NormalEndImage;
    private bool ending;

    //change 2: stamps (make sure they are un-active in inspector)
    public GameObject stamp1;
    public GameObject stamp2;
    public GameObject stamp3;


    void Update()
    {
        if (!ending) {
            if (Score.currentScore >= 0)
            {
                Debug.Log("Triggering NormalEnd");
                NormalEnd();
            }
            else
            {
                Debug.Log("Triggering DeadEnd");
                DeadEnd();
            }
        }
        ending = true;
        Debug.Log($"Current Score: {Score.currentScore}");
    }

    void NormalEnd()
    {
        finalScoreText.text = "Score: " + Mathf.FloorToInt(Score.currentScore);
        NormalEndText.SetActive(true);
        NormalEndImage.SetActive(true);

        //change 1
        resultScreenMusic.Play();

        // Check if the current score beats the high score
        if (Score.currentScore > Score.highScore)
        {
            highestScoreText.SetActive(true); // Show "New High Score" message
            Score.highScore = Score.currentScore; // Update the high score
            Debug.Log("Current high score: " + Score.highScore);
            dpm.SaveGame();
        }
        else
        {
            highestScoreText.SetActive(false); // Ensure it's hidden if no new high score
        }

        //change 2: turn on certain stamps depending on score level
        if (Score.currentScore >= 0)
        {
            //show stamp 1
            stamp1.SetActive(true);

            if (Score.currentScore > 100)
            {
                //show stamp 2
                stamp2.SetActive(true);
                if (Score.currentScore > 300)
                {
                    //show stamp 3
                    stamp3.SetActive(true);
                }
            }

        }
    }

    void DeadEnd()
    {
        deadendost.Play();
        DeadEndText.SetActive(true);
        DeadEndImage.SetActive(true);
        finalScoreText.text = "";
        highestScoreText.SetActive(false); // Hide "New High Score" message
    }

    public void ResetEnding() {
        ending = false;
        NormalEndText.SetActive(false);
        NormalEndImage.SetActive(false);
        DeadEndText.SetActive(false);
        DeadEndImage.SetActive(false);
        stamp1.SetActive(false);
        stamp2.SetActive(false);
        stamp3.SetActive(false);
        highestScoreText.SetActive(false);
    }
}
