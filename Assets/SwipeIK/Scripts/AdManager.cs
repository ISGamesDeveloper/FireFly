using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    public bool lifes
       // , VIDEOprosmotrNAkarte
        ;
 //   public GameObject SHIT;
    public GameObject text;
    int LANG;
    [SerializeField]
    string gameID = "1169209";
    int NETreklami;

    void Awake()
    {
        NETreklami = PlayerPrefs.GetInt("kupili_reklamu", 0);
        if (NETreklami == 0
         //   && !VIDEOprosmotrNAkarte
            ) {
            Advertisement.Initialize(gameID, false);
        }  //тут был почему то в конце return;
   //    if (VIDEOprosmotrNAkarte) { Advertisement.Initialize(gameID, false); }
        LANG = PlayerPrefs.GetInt("LANG");
        text.SetActive(false);
    }

    public void ShowAd(string zone = "rewardedVideo")
    {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

        if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady(zone)) { Advertisement.Show(zone, options); }
        else { StartCoroutine(ForAnimation()); }
    }
    void AdCallbackhandler(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Time.timeScale = 1;
                if (lifes) { player.PlayerLifes = 5; PlayerPrefs.SetInt("PlayerLifes", player.PlayerLifes);
                    if (SceneManager.GetActiveScene().name != "Menu") { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
                    if (SceneManager.GetActiveScene().name == "Menu") { GameObject.Find("NET ZHIZNEY").SetActive(false); } }
           //     if (VIDEOprosmotrNAkarte) { SHIT.SetActive(true); GetComponent<SpriteRenderer>().enabled = false; GetComponent<CapsuleCollider>().enabled = false; }
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }
    IEnumerator WaitForAd()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;
        Time.timeScale = currentTimeScale;
    }

    IEnumerator ForAnimation()
    {
        Advertisement.Initialize(gameID, false);
        if (LANG == 0) { text.GetComponent<Text>().text = "ВИДЕО НЕ ЗАГРУЖЕНО"; }
        else { text.GetComponent<Text>().text = "VIDEO NOT UPLOADED"; }
        text.SetActive(true);
        yield return new WaitForSeconds(2f);
        text.SetActive(false); 
      //  StopCoroutine(ForAnimation());
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SwipeScript.p = SwipeScript.Pivots.Pnull;
            SwipeScript.speed = 0;
            ShowAd("rewardedVideo");
        }
    }

}