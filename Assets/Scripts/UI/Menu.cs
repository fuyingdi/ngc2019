using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject bian;
    public GameObject lianzi;
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
		    Application.Quit();
        #endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameManager.isFail = false;
        GameManager.isWin = false;
    }

    IEnumerator AsyncLoading()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        //阻止当加载完成自动切换  
        operation.allowSceneActivation = false;

        yield return operation;
    }
}
