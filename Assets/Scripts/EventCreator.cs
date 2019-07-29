using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class EventCreator : MonoBehaviour
{
    public string JsonString;
    public static List<GameEvent> GameEvents= new List<GameEvent>();  //游戏事件池
    public static List<SerialGameEvent> SerialGameEvents= new List<SerialGameEvent>();  //连续事件池

    public static bool[] isEventUsed;
    public static bool[] isSerialEventUsed;

    public static int EventCount;
    public static int SerialEventCount;

    public static float SerialEventRate=0.01f; // 生成连续事件的概率

    public static int NextId=-1;
    public static bool inSeries;
    public static SerialGameEvent CurrentEvent;


    void Awake()
    {
        //生成普通事件池
        JsonString = File.ReadAllText(Application.dataPath + "\\Resources\\Events.json");
        JsonData EventData = JsonMapper.ToObject(JsonString);
        GameEvents = JsonMapper.ToObject<List<GameEvent>>(JsonString);

        //生成连续事件的事件池
        JsonString = File.ReadAllText(Application.dataPath + "\\SerialEvents.json");
        JsonData SerialEventData = JsonMapper.ToObject(JsonString);
        SerialGameEvents = JsonMapper.ToObject<List<SerialGameEvent>>(JsonString);

        EventCount = GameEvents.Count;
        SerialEventCount = SerialGameEvents.Count;

        isEventUsed = new bool[EventCount];
        isSerialEventUsed = new bool[SerialEventCount];

        foreach(GameEvent e in GameEvents)
        {
            if(e.Changes_A==null||e.Changes_B ==null)
            {
                Debug.Log(e.EventID);
            }
        }


        #region
        //foreach (System.Reflection.PropertyInfo p in GameEvents[0].GetType().GetProperties())
        //{
        //    print(p.Name + ":" + p.GetValue(GameEvents[0], null));
        //}
        //print(GameEvents[0].EventID);
        //print(GameEvents[0].Changes_A.people);
        #endregion
    }

    void Update()
    {

        
    }

    public static GameEvent GetGameEvent()
    {
        if(NextId==-1)
        {
            inSeries = false;
        }

        if(inSeries)
        {
            CurrentEvent = SerialGameEvents[NextId];
            return SerialGameEvents[NextId];
        }
        else
        {
            if(Random.Range(0f,1f)> SerialEventRate)
            {
                //生成普通事件
                int i = Random.Range(0, EventCount);
                int tryCount = 0;
                while (isEventUsed[i] && tryCount<=EventCount)
                {
                    i++;
                    i %= EventCount;
                    tryCount++;
                }
                isEventUsed[i] = true;
                return GameEvents[i];

            }
            else
            {
                //生成系列事件

                int i = Random.Range(0, SerialEventCount);
                int tryCount = 0;
                while (isSerialEventUsed[i] && tryCount <= SerialEventCount || SerialGameEvents[i].IsBegin ==false)
                {
                    i++;
                    i %= SerialEventCount;
                    tryCount++;
                }
                isSerialEventUsed[i] = true;

                inSeries = true;
                CurrentEvent = SerialGameEvents[i];
                return SerialGameEvents[i];
            }
        }

    }
}
