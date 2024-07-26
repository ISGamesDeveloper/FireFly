using UnityEngine;
using System.Collections;

public class PSforPLAYER2 : MonoBehaviour
{
    public ParticleSystem ps;
    Light halo;
    void Start()
    {
        halo = GetComponent<Light>();
        halo.color = player.GameColor;
    }
        void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Stena"))
        {
            ps.startColor = halo.color;
            Instantiate(ps, transform.position, transform.rotation);
        }
    }
}
