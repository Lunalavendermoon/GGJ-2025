using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public List<GameObject> tutPages; //list for the tutorial pages
    private int currentActiveTutPgIndex;
    public GameObject startPage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void ShowTutorial()
    {
        //show first tutorial slide
        tutPages[0].SetActive(true);
        currentActiveTutPgIndex = 0;
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

        if (currentActiveTutPgIndex == tutPages.Count - 1) //if at last image exit tut
        {
            startPage.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            //go to next page in sequence
            currentActiveTutPgIndex++;
            //show it
            tutPages[currentActiveTutPgIndex].SetActive(true);
        }
    }
}
