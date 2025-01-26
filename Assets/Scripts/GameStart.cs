using TMPro;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public TextMeshProUGUI highestScoreTextStart;
    public DataPersistanceManager dpm;
    public Tutorial tut;
    void Start() {
        dpm.LoadGame();
        gameObject.SetActive(true); //set Start game object to true
    }
    void Update()
    {
        highestScoreTextStart.text = "Highest Score: " + Score.highScore;
    }
}
