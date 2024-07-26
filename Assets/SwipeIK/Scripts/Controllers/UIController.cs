using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public SwipeScript swipeScript;
    public GameObject UIFinishButtons;
    public GameObject UIPauseButtons;
    public GameObject UIPauseButton;
    public GameObject UIGameOverButtons;
    public GameObject UITimeLine;
    public GameObject UITimeText; 

    private void Awake()
    {
        MainController.instance.uiController = this;

        if(swipeScript == null)
        {
            swipeScript = transform.Find("Canvas").transform.Find("SwipeImage").GetComponent<SwipeScript>();
        }

        if(UIFinishButtons == null)
        {
            UIFinishButtons = transform.Find("UIFinish").gameObject;
        }

        if(UIPauseButtons == null)
        {
            UIPauseButtons = transform.Find("UIPause").gameObject;
        }

        if(UIPauseButton == null)
        {
            UIPauseButton = UIPauseButtons.transform.Find("PauseButton (1)").gameObject;
        }

        if(UIGameOverButtons == null)
        {
            UIGameOverButtons = transform.Find("UIGameOver").gameObject;
        }

        if(UITimeLine == null)
        {
            UITimeLine = transform.Find("Canvas").transform.Find("Полоса").gameObject;
        }

        if(UITimeText == null)
        {
            UITimeText = transform.Find("Canvas").transform.Find("Text_3").gameObject;
        }




    }

    public void ClickUIButtons(string nameButton)
    {
        if (nameButton.Equals("pauseButton"))
        {
            if (!UIPauseButtons.activeInHierarchy) { UIPauseButtons.SetActive(true); Time.timeScale = 0; swipeScript.gameObject.SetActive(false); return; }
            else { UIPauseButtons.SetActive(false); Time.timeScale = 1; swipeScript.gameObject.SetActive(true); return; }
        }
        if (nameButton.Equals("nextLevelButton"))
        {
            Debug.Log("SceneManager.sceneCount: " + SceneManager.sceneCount);
            if (SceneManager.GetActiveScene().buildIndex < 14)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene("EndScene");
                //SceneManager.LoadScene("Menu");
            }
        }
        if (nameButton.Equals("exitVmenu"))
        {
            SceneManager.LoadScene("Menu");
        }
        if (nameButton.Equals("restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Time.timeScale = 1;
    }
}
