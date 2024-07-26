using UnityEngine;
using UnityEngine.UI;

public class LanguageScript : MonoBehaviour {

    public Text PLAYGAME, SETTINGS, EXIT, MY_GAMES, LANGUAGE, NO_ADS, ON, OFF, SOUND,POSMOTRI_VIDEO,NE_HVATAYET_ZHIZNEY;
    int LANG,perviyZapusk;
    public bool RU_L, EN_L;
    public bool Menu, Level1, Level2;
    string s;
    void Start()
    {
        LANG = PlayerPrefs.GetInt("LANG");
        perviyZapusk = PlayerPrefs.GetInt("perviyZapusk");
        if (perviyZapusk != 0)
        {
            if (LANG == 0) { LocalizationManager.instance.SetLang("RU"); }
            if (LANG == 1) { LocalizationManager.instance.SetLang("EN"); }
        }
        if (perviyZapusk == 0)
        {
            if (Application.systemLanguage == SystemLanguage.Russian) { LANG = 0; PlayerPrefs.SetInt("LANG", LANG); LocalizationManager.instance.SetLang("RU"); }
            if (Application.systemLanguage == SystemLanguage.English) { LANG = 1; PlayerPrefs.SetInt("LANG", LANG); LocalizationManager.instance.SetLang("EN"); }
            if (Application.systemLanguage != SystemLanguage.Russian && Application.systemLanguage != SystemLanguage.English) { LANG = 1; PlayerPrefs.SetInt("LANG", LANG);
                LocalizationManager.instance.SetLang("EN"); }
            perviyZapusk = 1; PlayerPrefs.SetInt("perviyZapusk", perviyZapusk);
        }
        TextText();
    }
    void TextText()
    {
        if (Menu)
        {
            PLAYGAME.text = LocalizationManager.instance.GetWord("PlayGame");
            SETTINGS.text = LocalizationManager.instance.GetWord("Settings");
            EXIT.text = LocalizationManager.instance.GetWord("Exit"); 
            MY_GAMES.text = LocalizationManager.instance.GetWord("MyGames");
            LANGUAGE.text = LocalizationManager.instance.GetWord("Language");
            NO_ADS.text = LocalizationManager.instance.GetWord("Ads");
            SOUND.text = LocalizationManager.instance.GetWord("Sound");
            ON.text = LocalizationManager.instance.GetWord("On");
            OFF.text = LocalizationManager.instance.GetWord("Off");
            POSMOTRI_VIDEO.text = LocalizationManager.instance.GetWord("PosmotriVideo");
            NE_HVATAYET_ZHIZNEY.text = LocalizationManager.instance.GetWord("NeHvataetZhizney");
        }
    }

    public void OnClick()
    {
        if (RU_L) { LocalizationManager.instance.SetLang("RU"); LANG = 0; }
        if (EN_L) { LocalizationManager.instance.SetLang("EN"); LANG = 1; }
        TextText(); PlayerPrefs.SetInt("LANG", LANG);
    }
}
