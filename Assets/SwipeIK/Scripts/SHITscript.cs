using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SHITscript : MonoBehaviour
{
    public ParticleSystem ps;
    GameObject player1, player2;
    float radiusPLAYER = 0.45f;   //////////////////////////////////////ВНИМАНИЕ! РАДИУС КОЛЛАЙДЕРА ИГРОКА!!!!!!
    bool zaglushka;//не удалять!!!
    public static int SHITcount;
    Text textSHITcount;
    bool DUALplayer;
    Vector3 localScalePlayer = new Vector3(1f, 1f, 1f);
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex > 14) { DUALplayer = true; } else { DUALplayer = false; }

        textSHITcount = GameObject.Find("Text SHIT Text").GetComponent<Text>();
    }

    private void Start()
    {
        player1 = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");

        radiusPLAYER = player1.GetComponent<CapsuleCollider>().radius;
    }

    void OnEnable() { zaglushka = true; }

    void OnDisable()
    {
        GameObject.Find("Player").GetComponent<CapsuleCollider>().radius = radiusPLAYER;

        //if (DUALplayer)
        //{
        //    player2.GetComponent<CapsuleCollider>().radius = radiusPLAYER;
        //}
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Stena"))
        {
            if (zaglushka)
            {
                if (SHITcount >= 1) { SHITcount -= 1; }
                textSHITcount.text = SHITcount + "";
                PlayerPrefs.SetInt("SHITcount", SHITcount);
                SwipeScript.speed = 0;
                SwipeScript.p = SwipeScript.Pivots.Pnull;
                if (player1.transform.localScale == localScalePlayer && !SwipeScript.smenaZX)
                {
                    MainController.instance.uiController.UITimeLine.SetActive(false);
                }
                SwipeScript.speed = 6;
                player1.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", player.GameColor); player1.GetComponent<Light>().color = player.GameColor;
                ps.startColor = Color.white; Instantiate(ps, transform.position, transform.rotation);
                if (DUALplayer)
                {
                    player2.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmisColor", player.GameColor);
                    player2.GetComponent<Light>().color = player.GameColor;
                    MainController.instance.playerController.Shit.GetComponent<SpriteRenderer>().enabled = false;
                    MainController.instance.playerController.Shit2.GetComponent<SpriteRenderer>().enabled = false;
                    ps.startColor = Color.white;
                    Instantiate(ps, player2.transform.position, player2.transform.rotation);
                }
                else { GetComponent<SpriteRenderer>().enabled = false; }

                zaglushka = false;

            }
        }
        if (col.gameObject.CompareTag("Player"))
        {
            player1.GetComponent<CapsuleCollider>().radius = 0.05f; if (DUALplayer) { player2.GetComponent<CapsuleCollider>().radius = 0.05f; }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Stena"))
        {
            gameObject.SetActive(false);
        }
    }
}
