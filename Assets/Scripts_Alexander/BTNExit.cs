using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Alexander
/// Date: 20190727
/// Function: Exit all game whether in editor mode or in published mode.
/// </summary>
public class BTNExit : MonoBehaviour
{
    public void BtnQuit()
    {
#if     UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
