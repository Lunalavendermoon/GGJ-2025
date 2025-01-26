using Unity.VisualScripting;
using UnityEngine;

public class ScoreCopy : MonoBehaviour, IDataPersistance
{
    
    public void LoadData(GameData data) {
        Score.highScore = data.highScore;
    }

    public void SaveData(ref GameData data) {
        data.highScore = Score.highScore;
        Debug.Log("data.highScore is " + data.highScore);
    }
}
