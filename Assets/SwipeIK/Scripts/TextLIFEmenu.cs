using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextLIFEmenu : MonoBehaviour {

    public Text textLIFESvLEVELS, textLIFESvLEVELS2, textLIFESvLEVELS3, textLIFESvLEVELS4;
    void Start () {
        player.PlayerLifes = PlayerPrefs.GetInt("PlayerLifes", 0);
        if (player.PlayerLifes < 5) { StartCoroutine(forLifes()); }
        if (player.PlayerLifes > 5 && player.PlayerLifes < 1000) { player.PlayerLifes = 5; PlayerPrefs.SetInt("PlayerLifes", player.PlayerLifes); }
        if (player.PlayerLifes == 5) { textLIFESvLEVELS.text = player.PlayerLifes + ""; textLIFESvLEVELS2.text = player.PlayerLifes + ""; textLIFESvLEVELS3.text = player.PlayerLifes + ""; textLIFESvLEVELS4.text = player.PlayerLifes + ""; }
    }

    IEnumerator forLifes()
    {
        while (true)
        {
            textLIFESvLEVELS.text = player.PlayerLifes + "";
            textLIFESvLEVELS2.text = player.PlayerLifes + "";
            textLIFESvLEVELS3.text = player.PlayerLifes + "";
            textLIFESvLEVELS4.text = player.PlayerLifes + "";
            yield return new WaitForSeconds(1f);
        }
    }
}
