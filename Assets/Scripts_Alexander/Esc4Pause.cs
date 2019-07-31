using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc4Pause : MonoBehaviour
{
    public Canvas uiImage;// The name of the class should be in accordance with the child module of Object
    public GameObject eventSys;// The EventSystem should always be closed for keyboard choice activation

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiImage.enabled = !uiImage.enabled;  // Function "enabled" can be got and set
            eventSys.SetActive(!eventSys.activeSelf);
        }
        if (uiImage.enabled)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
