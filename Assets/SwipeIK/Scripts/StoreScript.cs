using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class StoreScript : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler{

    public bool Obmenyat;
    int Armor;
    public Text textNehvatayet;
    public Text ArmorCount;
    Image imageButton;
    Color colorButton;
    int numer;
	void Start () {
        Armor = PlayerPrefs.GetInt("Armor");
        MonetaScropt.monetaCount = PlayerPrefs.GetInt("monetaCount");
        if (GetComponent<Image>()) { imageButton = GetComponent<Image>(); colorButton = imageButton.color; }
    }

    IEnumerator numerator()
    {
        textNehvatayet.text = "НЕ ХВАТАЕТ МОНЕТ";
        yield return new WaitForSeconds(numer);
        numer = 0;
        textNehvatayet.text = "";
        StopCoroutine(numerator());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Obmenyat) { if (MonetaScropt.monetaCount >= 10) { MonetaScropt.monetaCount -= 10; Armor += 1; PlayerPrefs.SetInt("Armor", Armor); PlayerPrefs.SetInt("monetaCount", MonetaScropt.monetaCount); }
            else { if (numer == 0) { numer = 2; StartCoroutine(numerator()); } }
        }       
    }

    public void OnPointerDown(PointerEventData eventData){imageButton.color = Color.gray;}

    public void OnPointerUp(PointerEventData eventData){imageButton.color = colorButton;}

}
