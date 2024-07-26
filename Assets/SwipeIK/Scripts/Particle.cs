using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour
{

    private ParticleSystem ps;
    private void Start()
    {
        ps = (ParticleSystem)GetComponent(typeof(ParticleSystem));
    }

    private void Update()
    {
		if (ps)
		if (!ps.IsAlive ())
                Object.Destroy(this.gameObject);
      
    }
   
}
