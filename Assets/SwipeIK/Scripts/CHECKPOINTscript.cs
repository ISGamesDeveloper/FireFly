using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;
public class CHECKPOINTscript : MonoBehaviour {

    SpriteRenderer SP;
    Light L;
    void Start()
    {
        SP = GetComponent<SpriteRenderer>();
        L = GetComponent<Light>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SP.color = player.GameColor;
            L.color = player.GameColor;
        }
    }

}
