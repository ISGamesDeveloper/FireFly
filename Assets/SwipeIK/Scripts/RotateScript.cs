using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

    Rigidbody rig;
    public Vector3 rotate;
    public bool moneta;
	void Start () {
       
        rig = GetComponent<Rigidbody>();
        if (moneta) { rotate = new Vector3(0, 0, -3500 * Time.deltaTime); }
	}

    void FixedUpdate()
    {
        rig.MoveRotation(rig.rotation * Quaternion.Euler(rotate * Time.deltaTime));
    }
}
