using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    void Start()
    {

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

}
