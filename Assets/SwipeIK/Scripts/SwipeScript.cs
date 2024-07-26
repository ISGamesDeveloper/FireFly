using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SwipeScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler    //раскоментировать если нужен будет тап для снижения скорости
{
    Transform player;
    public enum Pivots {Pnull,XM,XP,YM,YP};
    public static Pivots p;

    public static float speed;
    public static bool smenaZX;
    Vector3 playerNACHALOpozition;  //это можно использовать во время чекпоинтов!!!
    public bool PLAYERupdate;
    Vector3 pos;
    public GameObject SHITplayer, SHITplayer2;
    bool zaglushka;
    public bool DUBLEplayer;
    public static bool PlayerDead = false;
    bool shitTRUEpovFALSE;

    public int TapCount = 0;
    public GameObject player1, player2, Tochka;
    public static float rotationSpeed = 1400; // Скорость поворота 
    float targetAngle = 270f; // Угол на который надо повернуться 
    public static float currentAngle;

    void Start()
    {
        if (GameObject.Find("SpritePlayer")) { SHITplayer = GameObject.Find("SpritePlayer"); SHITplayer.SetActive(false); }
        if (GameObject.Find("SpritePlayer2")) { SHITplayer2 = GameObject.Find("SpritePlayer2"); SHITplayer2.SetActive(false); }

        if (GameObject.Find("Player")) { player1 = GameObject.Find("Player");}
        if (GameObject.Find("Player2")) { player2 = GameObject.Find("Player2");}

        if (SceneManager.GetActiveScene().buildIndex > 14)
        {
            if(SHITplayer2 != null)
            {
                DUBLEplayer = true; player = gameObject.transform; SHITplayer2.SetActive(false);
            }
           
        }
        else { player = GameObject.Find("Player").transform; }

        Time.timeScale = 1;
        playerNACHALOpozition = player.transform.position;
        speed = 6;
        p = Pivots.Pnull;
    }
    void Update()
    {
        if (!PlayerDead)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                speed = 6;
                p = Pivots.XM;
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                speed = 6;
                p = Pivots.XP;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                speed = 6;
                p = Pivots.YP;
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                speed = 6;
                p = Pivots.YM;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (speed == 10)
                {
                    speed = 6;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (speed == 6)
                {
                    speed = 10;
                }
            }
        }


        if (!PLAYERupdate)
        {
            if (Input.touchCount >= 2 && !zaglushka || Input.GetKey(KeyCode.Space) && !zaglushka)
            {
                zaglushka = true;
                if (SHITscript.SHITcount > 0)
                {
                    if (!SHITplayer.activeInHierarchy)
                    {
                        SHITplayer.SetActive(true); SHITplayer.GetComponent<SpriteRenderer>().enabled = true;
                        if (DUBLEplayer)
                        {
                            SHITplayer2.SetActive(true); SHITplayer2.GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }
                    else { SHITplayer.SetActive(false); if (DUBLEplayer) { SHITplayer2.SetActive(false); } }
                }
            }
            if (Input.touchCount >= 2)
            {
                shitTRUEpovFALSE = true;
                StartCoroutine(DoubleTap());
            } //есть щит или нет щита, все ровно это условие сработет! так надо)))
            if (Input.touchCount == 0)
            {
                zaglushka = false;
            }
            return;
        }

        if (p == Pivots.XP) { player.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime); }
        if (p == Pivots.XM) { player.transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime); }

        if (DUBLEplayer)
        {
            if (p == Pivots.YP) { player.transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime); }
            if (p == Pivots.YM) { player.transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime); }
        }
        else
        {
            if(p == Pivots.YP) { player.transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime); }
            if (p == Pivots.YM) { player.transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime); }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (PlayerDead)
            return;
        var coeffDrag = 4; 
        TapCount = 0;
        if (player.transform.position == playerNACHALOpozition || speed == 0) { speed = 6; }
        if (!smenaZX)
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (eventData.delta.x > coeffDrag) { p = Pivots.XP; }// xP = true; xM = false; yP = false; yM = false; }    // если нужен будет тап то написать if (eventData.delta.x > 3)
                if (eventData.delta.x < -coeffDrag) { p = Pivots.XM; }   // и if (eventData.delta.x < -3)    с игриком ниже так же
            }
            else
            {
                if (eventData.delta.y > coeffDrag) { p = Pivots.YP; }
                if (eventData.delta.y < -coeffDrag) { p = Pivots.YM; }
            }
        }
        else
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (eventData.delta.x > coeffDrag) { p = Pivots.XM; }    // если нужен будет тап то написать if (eventData.delta.x > 3)
                if (eventData.delta.x < -coeffDrag) { p = Pivots.XP; }   // и if (eventData.delta.x < -3)    с игриком ниже так же
            }
            else
            {
                if (eventData.delta.y > coeffDrag) { p = Pivots.YM; }
                if (eventData.delta.y < -coeffDrag) { p = Pivots.YP; }
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (speed == 6)
        {
            speed = 10;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (speed == 10)
        {
            speed = 6;
        }
    }

    public void OnDrag(PointerEventData eventData) { }  //Не удалять!Не мешает!!!А то работать не будет!!

    public void OnPointerClick(PointerEventData eventData)
    {
        //if (TRIALplayer)
        //{
        //    TapCount++;
        //    if (TapCount == 2&&!shitTRUEpovFALSE)
        //    {
        //        if (SHITplayer.activeInHierarchy)
        //        {
        //            player1.GetComponent<Collider>().enabled = false; player2.GetComponent<Collider>().enabled = false;
        //        }
        //        StartCoroutine(RotateMeNow());
        //    }  
        //    StartCoroutine(DoubleTap());
        //}
    }

    IEnumerator DoubleTap()
    {
        yield return new WaitForSeconds(0.5f);
        TapCount = 0;
        shitTRUEpovFALSE = false;
        //if (TRIALplayer)
        //{
        //    yield return new WaitForSeconds(2f);
        //    player1.GetComponent<Collider>().enabled = true; player2.GetComponent<Collider>().enabled = true;
        //}
    }
    IEnumerator RotateMeNow()
    {
        currentAngle = 0f;
        
        while (true)
        {
            float step = rotationSpeed * Time.deltaTime;
            if (currentAngle + step > targetAngle)
            {
                // Докручиваем до нашего угла 
                step = targetAngle - currentAngle;
                player1.transform.RotateAround(Tochka.transform.position, Vector3.up, step);
                player2.transform.RotateAround(Tochka.transform.position, Vector3.up, step);
                TapCount = 0;
                break;
            }
            currentAngle += step;
            player1.transform.RotateAround(Tochka.transform.position, Vector3.up, step);
            player2.transform.RotateAround(Tochka.transform.position, Vector3.up, step);

            TapCount = 0;
            yield return null;
        }
    }










}