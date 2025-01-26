using TMPro;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public TextMeshProUGUI highestScoreTextStart;
    public DataPersistanceManager dpm;
    public Tutorial tut;
    void Start() {
        tut.ShowTutorial();
        dpm.LoadGame();
    }
    void Update()
    {
        highestScoreTextStart.text = "Highest Score: " + Score.highScore;
    }
}
