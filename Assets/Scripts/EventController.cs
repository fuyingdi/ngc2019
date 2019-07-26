using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventController : MonoBehaviour/*事件控制器*/
{

    public TextMeshProUGUI ShowBox;
    public TextMeshProUGUI OptionAText;
    public TextMeshProUGUI OptionBText;

    public static GameEvent currentEvent;//当前的事件
    private int currentEventID = 0;//当前事件ID号

    public static bool eventUpdated = true;//是否已经更新了事件


    public GameObject ChracaterObj;
    public Sprite[] CharacterSprites;


    private void Awake()
    {
        Player.Economic = Player.People = Player.Policy = Player.Military = 100;//初始每项的值为100
    }

    private void Start()
    {
        ShowEvent();
    }

    public void ShowEvent()
    {
        currentEvent = EventCreator.GetGameEvent();//获取事件
        ShowBox.text = currentEvent.ShowText;
        OptionAText.text = currentEvent.OptionTextA;
        OptionBText.text = currentEvent.OptionTextB;
        ChracaterObj.GetComponent<SpriteRenderer>().sprite = CharacterSprites[0];
        Camera.main.GetComponent<ScrollController>().foo();

    }
    public void ShowResult(string buttonName)
    {
        if (buttonName == "A")
            ShowBox.text = currentEvent.ResultTextA;
        else
            ShowBox.text = currentEvent.ResultTextB;
        Camera.main.GetComponent<ScrollController>().StartCoroutine("RollScroll");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))//当鼠标按下后抬起
        {
            if (EventandResultController.resultShowed)//如果结果已展示
            {
                EventandResultController.resultShowed = eventUpdated = false;//设定事件需要被更新，新的结果未显示
                CharacterImageController.imageUpdated = false;//设定人物图片需要更新
            }
            else if (!eventUpdated)//如果事件需要被更新
            {
                ;
            }
        }
        //if (!eventUpdated && doorAnimator[0].GetFloat("Time") > 1)//如果事件没有更新并且门的动画已播放完毕
        //{
        //    doorAnimator[0].SetFloat("Time", 0);//重置动画
        //    doorAnimator[1].SetFloat("Time", 0);
        //    doorAnimator[0].enabled = doorAnimator[1].enabled = false;//关闭门的动画
        //    currentEvent = EventCreator.GetGameEvent();//更新事件
        //    GetComponent<EventandResultController>().UpdateEventText();//更新事件文本
        //    GetComponent<ButtonController>().OnEnter();//更新按钮文本
        //    GetComponent<ButtonController>().buttonAText.GetComponentInParent<Button>().enabled = GetComponent<ButtonController>().buttonBText.GetComponentInParent<Button>().enabled = true;//设定按钮为开启状态
        //    eventUpdated = true;//设定事件已更新
        //}
    }
}