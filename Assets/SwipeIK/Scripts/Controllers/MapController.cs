using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    [HideInInspector] public GameObject Finish;

    private void Awake()
    {
        MainController.instance.mapController = this;

        if (Finish == null)
        {
            Finish = GameObject.Find("FINISH");
        }
    }
}
