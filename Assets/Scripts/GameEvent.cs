using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent
{
    public GameEvent()
    {

    }

    public string ShowText { get; set; }
    public string ResultTextA { get; set; }
    public string ResultTextB { get; set; }

    public int EventID { get; set; }
    public int ImageIndex { get; set; }

    public int[] Changes_A = new int[4];
    public int[] Changes_B = new int[4];

}
