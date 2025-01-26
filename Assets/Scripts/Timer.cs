using UnityEngine;
using System.Collections;
using TMPro;
using System.Transactions;
using UnityEngine.UI;

public class Timer: MonoBehaviour {

    public float targetTime;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI addedTimeText;
    public GameObject gameend;
    public GameManager gameManager;

    void Start() {
        targetTime = 10.0f;
    }

    void Update() {

        targetTime -= Time.deltaTime;
        timeText.text = Mathf.Round(targetTime * 10.0f) * 0.1f + "s";

        if (targetTime <= 0.0f)
        {
            targetTime = 0.0f;
            Score.currentScore = gameManager.GetPoints();
            gameend.SetActive(true);
            gameObject.SetActive(false);
        }

    }

    public void AddTime(float amt) {
        targetTime += amt;
        StartCoroutine(DisplayTextRoutine(amt));
    }

    public void EndTime() {
        targetTime = 0.0f;
    }

    public float GetTime() {
        return targetTime;
    }

    public void ResetTime() {
        targetTime = 10.0f;
    }

    private IEnumerator DisplayTextRoutine(float amt)
    {
        addedTimeText.text = "+" + Mathf.Round(amt * 10.0f) * 0.1f + "s";
        addedTimeText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        addedTimeText.gameObject.SetActive(false);
    }

}