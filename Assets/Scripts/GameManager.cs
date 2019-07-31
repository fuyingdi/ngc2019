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

    void Start()
    {
        string ConfigJsonString = File.ReadAllText(Application.dataPath + "\\Resources\\config.json");
        Config GameConfig = JsonMapper.ToObject<Config>(ConfigJsonString);
        GameObject.Find("ProgressBar").GetComponent<Slider>().maxValue = GameConfig.EventCount;

        isFail = false;

        
    }

    void Update()
    {
        if(Player.People<=0)
        {
            Invoke("PeopleFail",0.5f);
        }
        if(Player.Policy<=0)
        {
            Invoke("PolicyFail", 0.5f);
        }
        if(Player.Economic<=0)
        {
            Invoke("EconomicFail", 0.5f);
        }
        if (Player.Military<=0)
        {
            Invoke("MilitaryFail", 0.5f);
        }
        if (isFail)
        {
            if(Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(0);
            }
        }
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
