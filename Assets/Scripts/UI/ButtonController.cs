using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 按钮控制器
/// </summary>
public class ButtonController : MonoBehaviour
{
    public Text buttonAText, buttonBText;//两个按钮的文本

    private void Update()
    {
        
    }

    /// <summary>
    /// 点击按钮触发该方法
    /// </summary>
    /// <param name="button">点击的是A还是B</param>
    public void OnClick(string button)
    {
        GetComponent<EventandResultController>().UpdateResultText(button);//更新结果文本
    }

    /// <summary>
    /// 鼠标进入按钮触发该方法
    /// </summary>
    public void OnEnter()
    {
        buttonAText.text = EventController.currentEvent.OptionTextA;//更新A选项文本
        buttonBText.text = EventController.currentEvent.OptionTextB;//更新B选项文本
    }
}