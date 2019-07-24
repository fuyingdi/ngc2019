using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class EventCreator : MonoBehaviour
{
    public string JsonString;
    public List<GameEvent> GameEvents= new List<GameEvent>(); //游戏事件池
    void Start()
    {
        JsonString = File.ReadAllText(Application.dataPath + "\\Events.json");
        JsonData EventData = JsonMapper.ToObject(JsonString);
        GameEvents = JsonMapper.ToObject<List<GameEvent>>(JsonString);

        #region
        foreach (System.Reflection.PropertyInfo p in GameEvents[0].GetType().GetProperties())
        {
            print(p.Name + ":" + p.GetValue(GameEvents[0], null));
        }
        print(GameEvents[0].EventID);
        print(GameEvents[0].Changes_A.people);
        #endregion
    }

    void Update()
    {
        
    }
}
