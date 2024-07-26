using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour {

    public static int Sound;
    public Image IMGon, IMGoff;
    public bool PAUSEbutton,boolmenuIMAGES;
    public int forBUTTON;

    void Start()
    {
        Sound = PlayerPrefs.GetInt("Sound");
        if (Sound == 0)
        {
            AudioListener.pause = false;
            if (boolmenuIMAGES)
            {
                IMGon.enabled = true; IMGoff.enabled = false;
            }
        }
        else
        {
            AudioListener.pause = true;
            if (boolmenuIMAGES)
            {
                IMGon.enabled = false; IMGoff.enabled = true;
            }
        }
    }
    public void SoundClick()
    {
        if (PAUSEbutton) {
            if (forBUTTON == 0) { if (Sound == 0) { AudioListener.pause = true; forBUTTON = 1; } return; }
            if (forBUTTON == 1) { if (Sound == 0) { AudioListener.pause = false; forBUTTON = 0; } return; }
        }

        if (AudioListener.pause == true) { AudioListener.pause = false;IMGon.enabled = true;IMGoff.enabled = false; Sound = 0; PlayerPrefs.SetInt("Sound",Sound); }
        else { AudioListener.pause = true; IMGoff.enabled = true;IMGon.enabled = false; Sound = 1; PlayerPrefs.SetInt("Sound", Sound); }
    }
}
