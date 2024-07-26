using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Player,Player2;
    public GameObject SmenaXZ,SmenaXZ2;
    public GameObject Shit, Shit2;

    private void Awake()
    {
        MainController.instance.playerController = this;
        Debug.Log("Init player controller: " + MainController.instance.playerController);
#if UNITY_EDITOR
        Debug.Log("press left/right/top/bottom buttons and shift for change player speed.");
#endif
    }
}
