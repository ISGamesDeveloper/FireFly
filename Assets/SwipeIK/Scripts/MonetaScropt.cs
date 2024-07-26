using UnityEngine;
using UnityEngine.UI;

public class MonetaScropt : MonoBehaviour {

    public static int monetaCount;
    public Text textMonet,textSHIT;
    public ParticleSystem ps;
    public bool MonetaVmenu;
    public Collider collider7_obucheniye;
    public bool Obucheniye;
    void Start() {
        if (MonetaVmenu) { textMonet = GetComponent<Text>(); }

        monetaCount = PlayerPrefs.GetInt("monetaCount");         
        SHITscript.SHITcount = PlayerPrefs.GetInt("SHITcount");
		//SHITscript.SHITcount = 3;
        textMonet.text = monetaCount + "";
        textSHIT.text = SHITscript.SHITcount + "";
	}

    void OnEnable()
    {
        if (MonetaVmenu) { textMonet = GetComponent<Text>(); textMonet.text = PlayerPrefs.GetInt("monetaCount")+"";
            textSHIT.text = SHITscript.SHITcount + "";
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            monetaCount += 1;
            if (Obucheniye) { if (monetaCount >= 10) { collider7_obucheniye.transform.position = gameObject.transform.position; } }    
            if (monetaCount >= 10) { monetaCount -= 10; SHITscript.SHITcount += 1; textSHIT.text = SHITscript.SHITcount + ""; }
            textMonet.text = monetaCount + "";
            PlayerPrefs.SetInt("monetaCount", monetaCount);
            PlayerPrefs.SetInt("SHITcount", SHITscript.SHITcount);

            ps.startColor = GetComponent<SpriteRenderer>().color;
            Instantiate(ps, transform.position, transform.rotation);  
            gameObject.SetActive(false);
        }
    }
}
