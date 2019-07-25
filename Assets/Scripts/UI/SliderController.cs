using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 数值条控制器
/// </summary>
public class SliderController : MonoBehaviour
{
    public Slider[] sliders;//四个数值条
    private GameEvent.Changes chosenButton;//选择的按钮

    /// <summary>
    /// 更新数值条
    /// </summary>
    /// <param name="button">选择的是A还是B</param>
    public void UpdateSlider(string button)
    {
        chosenButton = (button == "A") ? EventController.currentEvent.Changes_A : EventController.currentEvent.Changes_B;//记录选择情况

        Player.ChangeAllValue(chosenButton.people, chosenButton.policy, chosenButton.military, chosenButton.economic);//改变并记录数值

        foreach (var slider in sliders)//改变数值条显示
        {
            switch (slider.name)
            {
                case "People":
                    slider.value = Player.People;
                    break;
                case "Economic":
                    slider.value = Player.Economic;
                    break;
                case "Military":
                    slider.value = Player.Military;
                    break;
                case "Policy":
                    slider.value = Player.Policy;
                    break;
            }
        }
    }
}