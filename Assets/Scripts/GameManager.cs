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
    }
    public GameObject[] FailImages;
    bool isFail;
    public GameObject[] Sliders;

    void Start()
    {
        string ConfigJsonString = File.ReadAllText(Application.dataPath + "\\Resources\\config.json");
        Config GameConfig = JsonMapper.ToObject<Config>(ConfigJsonString);
        GameObject.Find("ProgressBar").GetComponent<Slider>().maxValue = GameConfig.EventCount;

        isFail = false;

        
    }

    void Update()
    {
        print(Player.People);
        if (Sliders[0].GetComponent<Slider>().value <= 0)
        {
            Invoke("PeopleFail", 2f);
        }
        if (Sliders[1].GetComponent<Slider>().value <= 0)
        {
            Invoke("PolicyFail", 2f);
        }
        if (Sliders[2].GetComponent<Slider>().value <= 0)
        {
            Invoke("EconomicFail", 2f);
        }
        if (Sliders[3].GetComponent<Slider>().value <= 0)
        {
            Invoke("MilitaryFail", 2f);
        }
        if (isFail)
        {
            if(Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(0);
            }
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
    }
    void PolicyFail()
    {
        isFail = true;
        FailImages[1].SetActive(true);
    }
    void EconomicFail()
    {
        isFail = true;
        FailImages[2].SetActive(true);
    }
    void MilitaryFail()
    {
        isFail = true;
        FailImages[3].SetActive(true);
    }
    #endregion

    #region
    void Win()
    {

    }
    #endregion

}
