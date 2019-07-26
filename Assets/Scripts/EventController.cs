using UnityEngine;
using UnityEngine.UI;
public class EventController : MonoBehaviour/*事件控制器*/
{
    [HideInInspector] public static GameEvent currentEvent;//当前的事件

    private int currentEventID = 0;//当前事件ID号

    public int totalImages;//图片总数
    private int imagesIndex;//图片的索引值
    private Image[] images;//图片数组
    private Image currentImage;//当前显示的图片

    public int totalAudios;//声音总数
    private int audiosIndex;//声音的索引值
    private AudioClip[] audios;//声音片段数组
    private AudioClip currentAudio;//当前显示的声音

    public static bool eventUpdated = true;//是否已经更新了事件

    /// <summary>
    /// 初始化
    /// </summary>
    private void Awake()
    {
        images = new Image[totalImages];//确定图片数组长度
        audios = new AudioClip[totalAudios];//确定声音片段数组长度
        Player.Economic = Player.People = Player.Policy = Player.Military = 100;//初始每项的值为100
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Start()
    {
        currentEvent = EventCreator.GetGameEvent();//获取事件
        GetComponent<EventandResultController>().UpdateEventText();//初始化事件文本
    }

    /// <summary>
    /// 每帧更新的部分
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))//当鼠标按下后抬起
        {
            if (EventandResultController.resultShowed)//如果结果已展示
            {
                EventandResultController.resultShowed = eventUpdated = false;//设定事件需要被更新，新的结果未显示
            }
            else if (!eventUpdated)//如果事件需要被更新
            {
                currentEvent = EventCreator.GetGameEvent();//更新事件
                GetComponent<EventandResultController>().UpdateEventText();//更新事件文本
                GetComponent<ButtonController>().OnEnter();//更新按钮文本
                GetComponent<ButtonController>().buttonAText.GetComponentInParent<Button>().enabled = GetComponent<ButtonController>().buttonBText.GetComponentInParent<Button>().enabled = true;//设定按钮为开启状态
                eventUpdated = true;//设定事件已更新
            }
        }
    }
}