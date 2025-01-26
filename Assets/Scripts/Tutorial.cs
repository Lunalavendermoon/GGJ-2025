using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutPage1;
    public GameObject tutPage2;
    public GameObject tutPage3;
    public GameObject tutPage4;
    public GameObject tutPage5;
    public GameObject tutPage6;
    public GameObject tutPage7;

    public GameObject[] tutPages; //array for the tutorial pages
    public int currentActiveTutPgIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void ShowTutorial()
    {
        //show first tutorial slide
        tutPage1.SetActive(true);
        Update();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when player clicks, call show next tutorial page function
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextTutPage();
        }
    }

    void ShowNextTutPage()
    {
        tutPages[currentActiveTutPgIndex].SetActive(false); //hide currently active tutorial page
        //go to next page in sequence
        currentActiveTutPgIndex++;
        //show it
        tutPages[currentActiveTutPgIndex].SetActive(false);
    }
}
