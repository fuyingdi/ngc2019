using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// 按钮控制器
/// </summary>
public class ButtonController : MonoBehaviour
{
    private void Update()
    {
        //if (!EventController.eventUpdated)//当事件需要被更新
        //{
        //    buttonAText.text = buttonBText.text = null;//清空按钮选项
        //}
    }
    public void OnClick(string button)
    {
        Debug.Log("love");
        GetComponent<EventController>().ShowResult(button);
    }

    public void OnEnter()
    {

    }
}