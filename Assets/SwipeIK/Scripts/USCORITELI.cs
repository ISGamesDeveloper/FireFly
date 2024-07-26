using UnityEngine;
using System.Collections;

public class USCORITELI : MonoBehaviour {
    public bool USCORITEL, ZAMEDLITEL;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (USCORITEL && SwipeScript.speed != 0) { SwipeScript.speed = 16;}
            if (ZAMEDLITEL && SwipeScript.speed != 0) { SwipeScript.speed = 3; }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            if (USCORITEL && SwipeScript.speed != 0) { SwipeScript.speed = 6; }
            if (ZAMEDLITEL && SwipeScript.speed != 0) { SwipeScript.speed = 6; }
        }
    }
}
