using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VoprosScript : MonoBehaviour {

    Vector3 rotate;
    public Text text_3;
    public GameObject playerFIREFLY;
    public GameObject Player2;
    public GameObject polosa;
    public ParticleSystem ps;
    public GameObject SHIT,SHIT2;
    public GameObject SMENAXZ,SMENAXZ2;
    public GameObject Trigger;  //У каждого вопроса свой триггер в обучении!Он стоит после вопроса.Нужен после того как пройдет 3 секунды.

    float x, z,forSCALEpolosa;
    int timeFORtext,timesatic;
    public bool X, Z;
    public static int secondsFORtext;
    public static bool whileFORnumerator;
    public bool BONUSspeedPLUS,BONUSspeedMINUS,BONUSscalePLUS,BONUSscaleMINUS,BONUSbronya,BONUSsmenaXZ;
    public bool OBUCHENIYE;
    Rigidbody rig;
    public static int destVOPROS;
    int destmyCOUNT, COUNT;  //destroyCOUNT нужен для проверки переменной. Если данная переменная меньше чем статическая destVOPROS то удалять вопросик, который мы взяли до этого(который только что взяли). COUNT помогает не удалять те вопросы, которые мне еще не брали.
	void Awake()
	{
	     if (!OBUCHENIYE)
        {
		
			if (GameObject.Find ("Полоса")) {text_3 = GameObject.Find ("Text_3").GetComponent<Text> ();text_3.enabled = false;polosa = GameObject.Find ("Полоса");polosa.SetActive (false);}
			if (GameObject.Find ("smenaXZ")) {SMENAXZ = GameObject.Find ("smenaXZ");SMENAXZ.SetActive (false);}
			 if (GameObject.Find("smenaXZ2")) { SMENAXZ2 = GameObject.Find("smenaXZ2"); SMENAXZ2.SetActive(false); }
            SHIT = GameObject.Find("SpritePlayer");
           
            playerFIREFLY = GameObject.Find("Player");
            if (GameObject.Find("Player2")) { Player2 = GameObject.Find("Player2"); }
            if (GameObject.Find("SpritePlayer2")) { SHIT2 = GameObject.Find("SpritePlayer2"); }
           
        }
	}
    void Start () {
        rotate = new Vector3(0,0, -3500 * Time.deltaTime);
        if (GetComponent<Rigidbody>()) { rig = GetComponent<Rigidbody>(); }
        if (X) { x = 1f; }if (Z) { z = 1f; }
        timesatic = 15;
        forSCALEpolosa = 0.099f;
        if (OBUCHENIYE){timesatic = 6;forSCALEpolosa = 0.25f;}
		 if (GameObject.Find("smenaXZ")) {SMENAXZ.SetActive(false);}  
		 if (GameObject.Find("smenaXZ2")) { SMENAXZ2.SetActive(false);}
   
	}
    void FixedUpdate()
    {
        if (X || Z) { rig.position += new Vector3(x * Time.deltaTime, 0, z * Time.deltaTime); }
        rig.MoveRotation(rig.rotation * Quaternion.Euler(rotate * Time.deltaTime));
        if (destVOPROS > destmyCOUNT && COUNT == 1) { SBROS(); Destroy(gameObject); }
    }
	void Update () {
       
        if (timeFORtext > 0) { polosa.transform.localScale -= new Vector3(forSCALEpolosa *Time.deltaTime, 0, 0);}
       
    }
    public IEnumerator seconds()  //когда началось время
    {

        secondsFORtext = 3;
        while (whileFORnumerator)
        {
            text_3.text = secondsFORtext + "";
            if (secondsFORtext <= 0)
            {
                text_3.enabled = false;
                timeFORtext = timesatic;

                    if (BONUSspeedPLUS)
                    {
                        SwipeScript.speed = 11; playerFIREFLY.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", Color.red); playerFIREFLY.GetComponent<Light>().color = Color.red;
					if (Player2) { Player2.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", Color.red); Player2.GetComponent<Light>().color = Color.red; } 
                    }
                    if (BONUSspeedMINUS)
                    {
                        SwipeScript.speed = 1; playerFIREFLY.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", Color.black); playerFIREFLY.GetComponent<Light>().color = Color.black;
					if (Player2) { Player2.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", Color.black); Player2.GetComponent<Light>().color = Color.black; }
                    }
                    if (BONUSscalePLUS)
                    {
                        playerFIREFLY.transform.localScale = new Vector3(2f, 2f, 1f); playerFIREFLY.GetComponent<Light>().range = 2.8f;
					if (Player2) {Player2.transform.localScale = new Vector3(2f, 2f, 1f); Player2.GetComponent<Light>().range = 2.8f; }
                    }
                    if (BONUSscaleMINUS)
                    {
                        playerFIREFLY.transform.localScale = new Vector3(0.5f, 0.5f, 1f); playerFIREFLY.GetComponent<Light>().range = 0.7f;
					if (Player2) {Player2.transform.localScale = new Vector3(0.5f, 0.5f, 1f); Player2.GetComponent<Light>().range = 0.7f; }
                    }
                    if (BONUSbronya) { SHIT.SetActive(true);if (Player2) { SHIT2.SetActive(true); }}
				if (BONUSsmenaXZ) { SwipeScript.smenaZX = true; SMENAXZ.SetActive(true);if (Player2) { SMENAXZ2.SetActive(true); } }

                    polosa.SetActive(true);
                    StartCoroutine(bonus());
                    StopCoroutine(seconds());
                    if (OBUCHENIYE) { StartCoroutine(forCOLLIDERS()); }
                    secondsFORtext = 999;  // это для того, что бы это окошко не появлялось снова (вы взяли вопросик). А то каждые 1.5 сек появлялось. А  StopCoroutine(seconds()); и StopCoroutine(forCOLLIDERS()); НАХЕР не работает         
            }
            yield return new WaitForSeconds(1f);
            secondsFORtext -= 1;
        }

    }
    public IEnumerator bonus()   //когда окончилось время
    {

        while (whileFORnumerator)
        {
            if (timeFORtext <= 0)
            {
                if (BONUSspeedPLUS||BONUSspeedMINUS)
                {
                    SwipeScript.speed = 6; playerFIREFLY.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", player.GameColor); playerFIREFLY.GetComponent<Light>().color = player.GameColor;
                    if (Player2) { Player2.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", player.GameColor); Player2.GetComponent<Light>().color = player.GameColor; }
                }

                if (BONUSscaleMINUS || BONUSscalePLUS)
                {
                    playerFIREFLY.transform.localScale = new Vector3(1f, 1f, 1f); playerFIREFLY.GetComponent<Light>().range = 1.4f;
                    if (Player2) { Player2.transform.localScale = new Vector3(1f, 1f, 1f); Player2.GetComponent<Light>().range = 1.4f; }
                }


                if (BONUSbronya) { SHIT.SetActive(false); if (Player2) { SHIT2.SetActive(false); } }
                if (BONUSsmenaXZ) { SwipeScript.smenaZX = false; SMENAXZ.SetActive(false); if (Player2) { SMENAXZ2.SetActive(false); } }

                polosa.SetActive(false);
                whileFORnumerator = false;
                StopCoroutine(bonus());
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1f);
            timeFORtext -= 1;
        }
          
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Stena")){if (X) { x *= -1f; }if (Z) { z *= -1f; }}
    if (col.gameObject.CompareTag("Player"))
    {
        COUNT = 1;
        destVOPROS += 1;
        destmyCOUNT = destVOPROS;
        polosa.transform.localScale = new Vector3(1.5f, 1, 1);
        ps.startColor = GetComponent<SpriteRenderer>().color;
        Instantiate(ps, transform.position, transform.rotation);
        secondsFORtext = 3;
        text_3.enabled = true;
        whileFORnumerator = true;


        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false; GetComponent<Collider>().enabled = false;
        StartCoroutine(seconds());
      }
    }

    public void SBROS()
    {
        SwipeScript.speed = 6; 
		//Player 1
		playerFIREFLY.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", player.GameColor); playerFIREFLY.GetComponent<Light>().color = player.GameColor;
        playerFIREFLY.transform.localScale = new Vector3(1f, 1f, 1f); playerFIREFLY.GetComponent<Light>().range = 1.4f; // player.GetComponent<CapsuleCollider>().radius = 0.46f; 
		//Player 2
        if(Player2 != null)
        {
            Player2.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", player.GameColor); Player2.GetComponent<Light>().color = player.GameColor;
            Player2.transform.localScale = new Vector3(1f, 1f, 1f); Player2.GetComponent<Light>().range = 1.4f;
        }
        else
        {
            Debug.Log("PLAYER2 IS NULL");
        }
		

        SwipeScript.smenaZX = false; SMENAXZ.SetActive(false);
        timeFORtext = 0;
        polosa.SetActive(false);
        whileFORnumerator = true;
        secondsFORtext = 3;
        StartCoroutine(seconds());
    }

    public IEnumerator forCOLLIDERS()
    {
        yield return new WaitForSeconds(1.5f);
        Trigger.SetActive(true); Trigger.transform.position = playerFIREFLY.transform.position;
        StopCoroutine(forCOLLIDERS());
    }

    }
