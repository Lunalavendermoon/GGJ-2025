using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public float ChargeLevel = 0f;
    public Timer timer;
    public TextMeshProUGUI currentscore;
    private int ChargeSpeed = 110;
    private int MaxCharge;
    private List<List<int>> Thresholds;
    public List<AnimationManager> animations;
    public List<SpriteRenderer> sprites;
    private bool ready = true;

    private int pointsEarned = 0;
    private int pointsTotal = 0;
    private int selection;
    private bool changedColor = false;

    void Start() {
        
        Thresholds = new List<List<int>>
        {
            new List<int> { 230, 260 },
            new List<int> { 355, 390 },
            new List<int> { 480, 520 },
            new List<int> { 730, 770 },
            new List<int> { 805, 845 }
        };
        selection = Random.Range(0,4);
        MaxCharge = Thresholds[selection][1];
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && ready == true)
        {
            ChargeLevel += Time.deltaTime * ChargeSpeed;

            ChargeLevel = Mathf.Min(ChargeLevel, MaxCharge); // Ensure it doesn't exceed MaxCharge
        }
        if (Input.GetMouseButtonUp(0) && ChargeLevel < MaxCharge)
        {
            pointsEarned = (int)(ChargeLevel / 10.0f + (float)ChargeLevel / (float)MaxCharge);
            if (ChargeLevel < Thresholds[selection][1] && ChargeLevel > Thresholds[selection][0]) {
                pointsEarned = (int)(pointsEarned * 1.5);
            }
            timer.GetComponent<Timer>().AddTime(0.8f * pointsEarned / 10.0f);
            pointsTotal += pointsEarned;
            ChargeLevel = 0f; // Reset charge when mouse button is released
            changedColor = false;
            pointsEarned = 0;
            selection = Random.Range(0,4);
            MaxCharge = Thresholds[selection][1];
            currentscore.text = "score:" + pointsTotal;
        }

        if (ChargeLevel == 0) {
            if (changedColor == false) {
                StartCoroutine(ChangeColor());
                changedColor = true;
            }
            ActiveAnimation(0);
        }
        if (ChargeLevel > 0 && ChargeLevel < Thresholds[selection][0]) {
            ActiveAnimation(1);
        }
        if (ChargeLevel > Thresholds[selection][0] && ChargeLevel < MaxCharge) {
            ActiveAnimation(2);
        }            
        if (ChargeLevel >= MaxCharge) {
            Debug.Log("exploded!");
            StartCoroutine(DisplayOverflow());
            pointsTotal = -1;
        }
    }
    void ActiveAnimation(int index) {
        Debug.Log($"ActiveAnimation called with index: {index}");
        for (int i = 0; i < animations.Count; i++) {
            for (int j = 0; j < animations[i].GetCount(); j++) {
                if (i == selection && j == index) {
                    animations[i].Activate(j);
                } else if (j == 2 && j == index) {
                    animations[i].Activate(j);
                } else if (j == 3 && j == index) {
                    animations[i].Activate(j);
                } else {
                    animations[i].DeActivate(j);
                }
            }
        }
    }


    public void ResetPoints() {
        timer.GetComponent<Timer>().ResetTime();
        pointsTotal = 0;
        Score.currentScore = 0;
        ChargeLevel = 0.0f;
        Debug.Log("Score: " + Score.currentScore + "pointsTotal: " + pointsTotal);
        Debug.Log(Score.currentScore);
    }
    public int GetPoints() {
        return pointsTotal;
    }
    private IEnumerator DisplayOverflow()
    {
        ActiveAnimation(3);

        yield return new WaitForSeconds(1.0f);

        timer.GetComponent<Timer>().EndTime();
    }
    private IEnumerator ChangeColor()
    {
        sprites[selection].color = (Color)new Color32(100, 100, 100, 255);

        yield return new WaitForSeconds(0.1f);

        sprites[selection].color = (Color)new Color32(255, 255, 255, 255);
    }
}

