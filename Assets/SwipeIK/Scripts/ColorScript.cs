using UnityEngine;
using UnityEngine.UI;
public class ColorScript : MonoBehaviour {

	void Start () {
        if (GetComponent<Image>()) { GetComponent<Image>().color = player.GameColor; return; }
        if (GetComponent<Text>()) { GetComponent<Text>().color = player.GameColor; return; }
        if (GetComponent<Light>()) { GetComponent<Light>().color = player.GameColor; return; }
    }
	

}
