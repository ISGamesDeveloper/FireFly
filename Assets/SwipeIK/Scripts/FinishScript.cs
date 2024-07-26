using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {

    public string commandNameForFinishButton;

    public static int FINISHcount;
    bool[] Levels = new bool[41];

    void Start()
    {
        FINISHcount = PlayerPrefs.GetInt("FINISHcount");
        Levels[SceneManager.GetActiveScene().buildIndex] = true;

        if (gameObject.name.Contains("PauseButton"))
        {
            commandNameForFinishButton = "pauseButton";
        }

        if (gameObject.name.Contains("Restart")) 
        {
            commandNameForFinishButton = "restart";
        }

        if (gameObject.name.Contains("MainMenu") || gameObject.name.Contains("MAIN MENU"))
        {
            commandNameForFinishButton = "exitVmenu";
        }

        if (gameObject.name.Contains("Restart"))
        {
            commandNameForFinishButton = "restart";
        }

        if (gameObject.name.Contains("NEXT LEVEL"))
        {
            commandNameForFinishButton = "nextLevelButton";
        }

    }
   
    void MetodPlayer(Transform transform)
    {
        if (VoprosScript.whileFORnumerator)
        {
           VoprosScript.whileFORnumerator = false;
           MainController.instance.uiController.UITimeLine.SetActive(false); 
           MainController.instance.uiController.UITimeText.SetActive(false); 
        }

        if (transform.localScale != new Vector3(1f, 1f, 1f))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        VoprosScript.secondsFORtext = 0;
        SwipeScript.smenaZX = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SwipeScript.smenaZX = false;

            MetodPlayer(col.transform);

            MainController.instance.uiController.UIFinishButtons.gameObject.SetActive(true);
            for (int i = 1; i <= Levels.Length; i++)
            {
                if(Levels[i])
                {
                    if (FINISHcount <= i)
                    {
                        FINISHcount = i+1;
                        PlayerPrefs.SetInt("FINISHcount", FINISHcount);
                    }
                    break;
                }
            }
        }
    }

    public void Click()
    {
        MainController.instance.uiController.ClickUIButtons(commandNameForFinishButton);
    }
}
