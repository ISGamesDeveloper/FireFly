using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
    Vector3 tr;
    Text LIFEStext;
    TrailRenderer trail,trail2;
    float ForTrailTime;
    public static int PlayerLifes;
    public GameObject SMENAXZ,SMENAXZ2;
    public ParticleSystem ps;
    MeshRenderer mesh,mesh2;
    Light halo,halo2;
    public static Color GameColor;
    public bool COLORcyan,COLORcyanDARK, COLORyellow, COLORgreen,COLORgreenDARK, COLORmagenta,COLORmagentaDARK, COLORorange;
    int perviyraz;
    bool zaglushka = true;

    bool DUALplayer;
    SwipeScript swipeScript;

    [HideInInspector]
    public GameObject playerObject;
    [HideInInspector]
    public GameObject playerObject2;

    void Awake() 
    {
        if (SceneManager.GetActiveScene().buildIndex > 14) { DUALplayer = true; }  ///////////////////////////////////////////////////////////////////////////////////////
        swipeScript = gameObject.GetComponent<SwipeScript>();
        PlayerLifes = PlayerPrefs.GetInt("PlayerLifes", 0);
        perviyraz = PlayerPrefs.GetInt("perviyraz", 0);
        if (perviyraz == 0) { PlayerLifes = 5; perviyraz = 1; PlayerPrefs.SetInt("perviyraz", perviyraz); }
        if (COLORcyan) { GameColor = new Color32(0, 220, 255, 255); }
        if (COLORcyanDARK) {GameColor = new Color32(0, 130, 160, 255); }
        if (COLORyellow) { GameColor = new Color32(250, 190, 45, 255); }
        if (COLORgreen) { GameColor = new Color32(0, 150, 120, 255); }
        if (COLORgreenDARK) { GameColor = new Color32(0, 130, 115, 255); }
        if (COLORmagenta) { GameColor = new Color32(160, 40, 180, 255); }
        if (COLORmagentaDARK) { GameColor = new Color32(100, 60, 180, 255); }
        if (COLORorange) { GameColor = new Color32(230, 75, 60, 255); }
    }

    void Start()
    {
        var player1 = GameObject.Find("Player");
        var player2 = GameObject.Find("Player2");
        MainController.instance.playerController.Player = player1;
        MainController.instance.playerController.Player2 = player2;

        MainController.instance.playerController.SmenaXZ = MainController.instance.playerController.Player.transform.Find("smenaXZ").gameObject;


        if (player2 != null)
        {
            var transform = player2.transform;
            MainController.instance.playerController.SmenaXZ2 = transform.Find("smenaXZ2").gameObject;
            MainController.instance.playerController.Shit2 = transform.Find("SpritePlayer2").gameObject;
        }


        var shit = MainController.instance.playerController.Player.transform.Find("SpritePlayer");
        if(shit == null)
        {
            shit = MainController.instance.playerController.Player.transform.Find("Shit");
        }

        MainController.instance.playerController.Shit = shit.gameObject;
        //MainController.instance.playerController.Shit2 = MainController.instance.playerController.Player2.transform.Find("SpritePlayer2").gameObject;

        halo = GetComponent<Light>();
        halo.color = GameColor;
        mesh = GetComponent<MeshRenderer>();
       
        LIFEStext = GameObject.Find("UILifes").GetComponent<Text>();
        tr = gameObject.transform.position;       
        trail = GetComponent<TrailRenderer>();
        trail.sharedMaterial.SetColor("_EmisColor", GameColor);
        ForTrailTime = 1f;
       
        LIFEStext.text = PlayerLifes +"";
        zaglushka = true;

      

        if (MainController.instance.playerController.Player2)
        {
            halo2 = MainController.instance.playerController.Player2.GetComponent<Light>();
            halo2.color = GameColor;
            trail2 = MainController.instance.playerController.Player2.GetComponent<TrailRenderer>();
            mesh2 = MainController.instance.playerController.Player2.GetComponent<MeshRenderer>();
   
		
            halo = MainController.instance.playerController.Player.GetComponent<Light>();
            halo.color = GameColor;
            trail = MainController.instance.playerController.Player.GetComponent<TrailRenderer>();
            mesh = MainController.instance.playerController.Player.GetComponent<MeshRenderer>();
            ForTrailTime = 0.4f;
		}

        trail.time = ForTrailTime;
    }

    IEnumerator numerator()
    {
        if (SceneManager.GetActiveScene().buildIndex % 5 == 0)
        {
            For_timeScript.StopTime = true;
            For_timeScript.time = For_timeScript.startTime;
            MainController.instance.uiController.UITimeText.GetComponent<Text>().text = "";
            MainController.instance.uiController.UITimeText.GetComponent<Text>().enabled = false;
        }
        SwipeScript.p = SwipeScript.Pivots.Pnull;
        SwipeScript.speed = 0;
        yield return new WaitForSeconds(2f);
        zaglushka = true;
        SwipeScript.PlayerDead = false;

        if (SceneManager.GetActiveScene().buildIndex % 5 == 0)//возможно работать не будет на 10 и 20 номерах
        {
            For_timeScript.StopTime = false;
            MainController.instance.uiController.UITimeText.GetComponent<Text>().enabled = true;
            For_timeScript.time = For_timeScript.startTime;
            //MainController.instance.uiController.UITimeText.GetComponent<Text>().text = For_timeScript.time.ToString();
        }

        if (PlayerLifes > 0)
        {
            mesh.enabled = true;
            halo.enabled = true;
            transform.position = tr;
            MainController.instance.uiController.swipeScript.GetComponent<Image>().enabled = true;
            if (MainController.instance.playerController.Player2)
            {
                MainController.instance.playerController.Player.SetActive(true);
                trail2.time = ForTrailTime;
            }

            trail.time = 0;

            yield return new WaitForSeconds(1);

            trail.time = ForTrailTime;
        }
        else
        {
            MainController.instance.uiController.UIGameOverButtons.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Stena") && zaglushka)
        {
            SwipeScript.PlayerDead = true;
            MainController.instance.uiController.swipeScript.GetComponent<Image>().enabled = false;
            zaglushka = false;

            var mainPs = ps.main;
            mainPs.startColor = halo.color;
           
            mesh.enabled = false;
            halo.enabled = false;
            PlayerLifes = PlayerPrefs.GetInt("PlayerLifes");///////////////////
            PlayerLifes -= 1;
            PlayerPrefs.SetInt("PlayerLifes", PlayerLifes);
            LIFEStext.text = PlayerLifes + "";
            if (PlayerLifes <= 0) { MainController.instance.uiController.UIPauseButton.SetActive(false);}
            SwipeScript.speed = 0;

            if (VoprosScript.whileFORnumerator)
            {
                VoprosScript.whileFORnumerator = false;
                MainController.instance.uiController.UITimeLine.SetActive(false);
                MainController.instance.uiController.UITimeText.GetComponent<Text>().enabled = false;
            }
            transform.localScale = new Vector3(1f, 1f, 1f);
            halo.range = 1.4f;
            trail.sharedMaterial.SetColor("_EmisColor", GameColor);
            halo.color = GameColor;
            VoprosScript.secondsFORtext = 0;
            MainController.instance.playerController.Shit.SetActive(false); 
			SwipeScript.smenaZX = false;
            MainController.instance.playerController.SmenaXZ.SetActive(false);
    
            trail.time = 0;
            if (!DUALplayer) { Instantiate(ps, transform.position, transform.rotation); }
            else
            {
                Instantiate(ps, MainController.instance.playerController.Player2.transform.position, MainController.instance.playerController.Player2.transform.rotation);
                halo2.range = 1.4f;
                trail2.sharedMaterial.SetColor("_EmisColor", GameColor);
                halo2.color = GameColor;
                MainController.instance.playerController.SmenaXZ2.SetActive(false); 
                trail2.time = 0;
                MainController.instance.playerController.Player2.SetActive(false);
            }
            StartCoroutine(numerator());
        }
        if (col.gameObject.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            trail.time = 0; SwipeScript.speed = 0;
            MainController.instance.uiController.swipeScript.GetComponent<Image>().enabled = false;
            transform.position = MainController.instance.mapController.Finish.transform.position;
        }
        if (col.gameObject.CompareTag("Svetlyachok")) { tr = gameObject.transform.position; }
        if (col.gameObject.CompareTag("P1")) { trail.time = 0; transform.position = GameObject.Find("P1.1").transform.position;}
        if (col.gameObject.CompareTag("P2")) { trail.time = 0; transform.position = GameObject.Find("P2.2").transform.position;}

        if (col.gameObject.CompareTag("checkpoint")) { tr = col.transform.position;}
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Finish") || col.gameObject.CompareTag("P1") || col.gameObject.CompareTag("P2"))
        { trail.time = ForTrailTime; }     
    }
}
