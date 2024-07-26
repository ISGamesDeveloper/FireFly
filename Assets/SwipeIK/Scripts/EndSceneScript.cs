using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public Text MainMenuText;
    public Text BudyText;
    public Button MainMenuButton;
    public Button GooglePlayLogo;
    public Button ISGamesLogo;

    void Start()
    {
        var lang = PlayerPrefs.GetInt("LANG");

        if (lang == 0)
        {
            MainMenuText.text = "ГЛАВНОЕ МЕНЮ";
            BudyText.text = "Спасибо что доиграл до конца. Если хочешь продолжение, напиши об этом на странице игры";
        }
        else
        {
            MainMenuText.text = "MAIN MENU";
            BudyText.text = "Thanks for playing to the end. If you want a sequel, write about it on the game page";
        }

        GooglePlayLogo.onClick.AddListener(delegate
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=by.ISGames.FireFly");
        });


        ISGamesLogo.onClick.AddListener(delegate
        {
            Application.OpenURL("https://play.google.com/store/apps/dev?id=8715971215053349204");
        });

        MainMenuButton.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Menu");
        });
    }
}
