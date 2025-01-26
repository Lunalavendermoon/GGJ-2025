using TMPro;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public TextMeshProUGUI highestScoreTextStart;
    public DataPersistanceManager dpm;
    void Start() {
        dpm.LoadGame();
    }
    void Update()
    {
        highestScoreTextStart.text = "Highest Score: " + Score.highScore;
    }
}
