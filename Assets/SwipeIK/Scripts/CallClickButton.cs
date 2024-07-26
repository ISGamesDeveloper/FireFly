using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallClickButton : MonoBehaviour
{
    public string buttonName;

    public void ClickButton()
    {
        MainController.instance.uiController.ClickUIButtons(buttonName);
    }
}
