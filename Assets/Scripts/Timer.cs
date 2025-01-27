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
    //change 3: play ding sound when gaining time
    public AudioSource dingSound;

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

    public void AddTime(float amt, int pts) {
        //change 3
        dingSound.Play();
        targetTime += amt;
        StartCoroutine(DisplayTextRoutine(amt, pts));
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

    private IEnumerator DisplayTextRoutine(float amt, int pts)
    {
        addedTimeText.text = "+" + Mathf.Round(amt * 10.0f) * 0.1f + " secs\n" + "+" + pts + " pts";
        addedTimeText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        addedTimeText.gameObject.SetActive(false);
    }

}