using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class GameManager : MonoBehaviour
{
    public class Config
    {
        public int EventCount;
    }

    void Start()
    {
        string ConfigJsonString = File.ReadAllText(Application.dataPath + "\\Resources\\config.json");
        Config GameConfig = JsonMapper.ToObject<Config>(ConfigJsonString);
        GameObject.Find("ProgressBar").GetComponent<Slider>().maxValue = GameConfig.EventCount;

        
    }

    void Update()
    {
        if(Player.People<=0)
        {
            PeopleFail();
        }
        if(Player.Policy<=0)
        {
            PolicyFail();
        }
        if(Player.Economic<=0)
        {
            EconomicFail();
        }
        if(Player.Military<=0)
        {
            MilitaryFail();
        }
    }


    #region GameOver
    void PeopleFail()
    {

    }
    void PolicyFail()
    {

    }
    void EconomicFail()
    {

    }
    void MilitaryFail()
    {

    }
    #endregion

    #region
    void Win()
    {

    }
    #endregion

}
