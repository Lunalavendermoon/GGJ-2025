using TMPro;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText; 
    public AudioSource deadendost;
    public GameObject highestScoreText; // GameObject that shows a "New High Score" message
    public GameObject DeadEndText;
    public GameObject NormalEndText;
    public GameObject DeadEndImage;
    public DataPersistanceManager dpm;
    //public GameObject NormalEndImage;
    private bool ending;

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
        DeadEndText.SetActive(false);
        DeadEndImage.SetActive(false);
        highestScoreText.SetActive(false);
    }
}
