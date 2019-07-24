using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class EventCreator : MonoBehaviour
{
    public string jsonString;
    void Start()
    {
        jsonString = File.ReadAllText(Application.dataPath + "/Asset/Event.json");
    }

    void Update()
    {
        
    }
}
