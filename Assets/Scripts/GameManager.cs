﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public class Config
    {
        public int EventCount;
        public double SpecialEventRate;
        public double UpFactor;
        public double DownFactor;
    }
    public GameObject[] FailImages;
    public GameObject WinImage;
    public static bool isFail;
    public static bool isWin;

    public GameObject[] Sliders;
    public static Config GameConfig;
    public Image winmask;
    public Image losemask;

    bool isPlaying;
    void Awake()
    {
        string ConfigJsonString = File.ReadAllText(Application.dataPath + "\\Resources\\config.json");
        GameConfig = JsonMapper.ToObject<Config>(ConfigJsonString);
        GameObject.Find("ProgressBar").GetComponent<Slider>().maxValue = GameConfig.EventCount;
        EventCreator.SerialEventRate = (float)GameConfig.SpecialEventRate;
        EventCreator.UpFactor = (float)GameConfig.UpFactor;
        EventCreator.DownFactor = (float)GameConfig.DownFactor;


        isFail = false;
        isWin = false;
        Player.ProgressValue = 0;

        
    }

    void Update()
    {
        if (Player.People <= 0 && isFail == false)
        {
            StartCoroutine("PeopleFail");
        }
        if (Player.Policy<= 0 && isFail == false)
        {
            StartCoroutine("PolicyFail");
        }
        if (Player.Economic <= 0 && isFail == false)
        {
            StartCoroutine("EconomicFail");
        }
        if (Player.Military <= 0 && isFail == false)
        {
            StartCoroutine("MilitaryFail");
        }
        if (isFail||isWin)
        {
            if(Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Player.ProgressValue >= GameConfig.EventCount && EventCreator.NextId == -1&&isWin==false) 
        {
            AudiosController.GameWin();
            StartCoroutine("Win");
        }

    }



    #region GameOver
    IEnumerator PeopleFail()
    {
        
        for (int i = 0; i < 10; i++)
        {
            float x = i / 10f;
            losemask.color = new Color(1, 1, 1, x);
            yield return new WaitForSeconds(0.1f);
        }
        FailImages[0].SetActive(true);
        isFail = true;
        AudiosController.GameOver();
        yield break;
    }
    IEnumerator PolicyFail()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = i / 10f;
            losemask.color = new Color(1, 1, 1, x);
            yield return new WaitForSeconds(0.1f);
        }
        isFail = true;
        FailImages[1].SetActive(true);
        AudiosController.GameOver();
        yield break;


    }
    IEnumerator EconomicFail()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = i / 10f;
            losemask.color = new Color(1, 1, 1, x);
            yield return new WaitForSeconds(0.1f);
        }
        isFail = true;
        FailImages[2].SetActive(true);
        AudiosController.GameOver();
        yield break;

    }
    IEnumerator MilitaryFail()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = i / 10f;
            losemask.color = new Color(1, 1, 1, x);
            yield return new WaitForSeconds(0.1f);
        }
        isFail = true;
        FailImages[3].SetActive(true);
        AudiosController.GameOver();
        yield break;

    }
    #endregion

    #region
    IEnumerator Win()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = i / 10f;
            winmask.color = new Color(1, 1, 1, x);
            print(x);
            yield return new WaitForSeconds(0.1f);
        }
        isWin = true;
        WinImage.SetActive(true);
        yield break;
    }
    #endregion

}
