using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextGAMEOWER : MonoBehaviour {

    public Text textGAMEOWER, WanchTheVideo, Menu,PosmVideoText,Next;
    int LANG;
	void Start () {
        LANG = PlayerPrefs.GetInt("LANG");
        if (LANG == 1)
        {
            textGAMEOWER.text = "GAME OWER";
            WanchTheVideo.text = "WATCH THE VIDEO";
            Menu.text = "MENU";
            PosmVideoText.text = "WATCH THE VIDEO AND GET 5 LIVES";         
        }
        else
        {
            textGAMEOWER.text = "ИГРА ОКОНЧЕНА";
            WanchTheVideo.text = "ПОСМОТРЕТЬ ВИДЕО";
            Menu.text = "МЕНЮ";
            PosmVideoText.text = "ПОСМОТРИ ВИДЕО И ПОЛУЧИ 5 ЖИЗНЕЙ";
        }
	}
	

}
