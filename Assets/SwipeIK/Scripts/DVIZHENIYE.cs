using UnityEngine;
using System.Collections;

public class DVIZHENIYE : MonoBehaviour {

    public bool X, Z,ROTATION,VERTUSHKA;  //для вертушки включать булевые переменные ROTATION и VERTUSHKA
    public bool PLUS, MINUS;
    float x, z;
    Rigidbody rig;
    Vector3 rotate,startRotate;
    public float speed_rotate;

    void Awake() {
        if (speed_rotate == 0) { speed_rotate = -3000f; }
        if (!VERTUSHKA) { rotate = new Vector3(0, 0, speed_rotate * Time.deltaTime); startRotate = rotate; }
        if (VERTUSHKA) { rotate = new Vector3(0, speed_rotate * Time.deltaTime, 0); startRotate = rotate; }
        if (GetComponent<Rigidbody>()) { rig = GetComponent<Rigidbody>(); }
        if (X && PLUS) { x = 2f; }
        if (X && MINUS) { x = -2f; }
        if (Z && PLUS) { z = 2f; }
        if (Z && MINUS) { z = -2f; }
        if (X && !PLUS && !MINUS) { x = 2f; }
        if (Z && !PLUS && !MINUS) { z = 2f; }
    }

    void FixedUpdate()
    {
        if (X || Z) { rig.position += new Vector3(x * Time.deltaTime, 0, z * Time.deltaTime); }
        if (ROTATION){rig.MoveRotation(rig.rotation * Quaternion.Euler(rotate * Time.deltaTime));}
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Stena")) { if (X) { x *= -1f; } if (Z) { z *= -1f; } }
        if (/*col.gameObject.CompareTag("Player")||*/col.gameObject.CompareTag("SHIT")) {  StartCoroutine(FiveSecond()); }
    }

    IEnumerator FiveSecond()
    {
        if (ROTATION)
        {
            rotate = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(3f);
            rotate = startRotate;
        }
        else if (GameObject.Find("SpritePlayer"))
        {
            if (X)
            {
                X = false;
                yield return new WaitForSeconds(3f);
                X = true;
            }
            if (Z)
            {
                Z = false;
                yield return new WaitForSeconds(3f);
                Z = true;
            }
        }     
    }
    }
