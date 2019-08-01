using System.Collections;
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
    }
    public GameObject[] FailImages;
    public GameObject WinImage;
    public static bool isFail;
    public static bool isWin;

    public GameObject[] Sliders;
    public static Config GameConfig;

    void Start()
    {
        string ConfigJsonString = File.ReadAllText(Application.dataPath + "\\Resources\\config.json");
        GameConfig = JsonMapper.ToObject<Config>(ConfigJsonString);
        GameObject.Find("ProgressBar").GetComponent<Slider>().maxValue = GameConfig.EventCount;
        EventCreator.SerialEventRate = (float)GameConfig.SpecialEventRate;

        isFail = false;

        
    }

    void Update()
    {
        if (Player.People<=0)
        {
            Invoke("PeopleFail", 2.5f);
        }
        if (Player.Policy<= 0)
        {
            Invoke("PolicyFail", 2.5f);
        }
        if (Player.Economic <= 0)
        {
            Invoke("EconomicFail", 2.5f);
        }
        if (Player.Military <= 0)
        {
            Invoke("MilitaryFail", 2.5f);
        }
        if (isFail||isWin)
        {
            if(Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Player.ProgressValue >= GameConfig.EventCount && EventCreator.NextId == -1) 
        {
            Invoke("Win", 2f);
        }

        //print(Player.People);
        //print(Player.Policy);
        //print(Player.Economic);
        //print(Player.Military);


    }


    #region GameOver
    void PeopleFail()
    {
        FailImages[0].SetActive(true);
        isFail = true;
        AudiosController.GameOver();
    }
    void PolicyFail()
    {
        isFail = true;
        FailImages[1].SetActive(true);
        AudiosController.GameOver();

    }
    void EconomicFail()
    {
        isFail = true;
        FailImages[2].SetActive(true);
        AudiosController.GameOver();

    }
    void MilitaryFail()
    {
        isFail = true;
        FailImages[3].SetActive(true);
        AudiosController.GameOver();

    }
    #endregion

    #region
    void Win()
    {
        AudiosController.GameWin();
        WinImage.SetActive(true);
        isWin = true;

    }
    #endregion

}
