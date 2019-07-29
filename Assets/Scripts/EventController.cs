using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class EventController : MonoBehaviour/*事件控制器*/
{

    public TextMeshProUGUI ShowBox;
    public TextMeshProUGUI OptionAText;
    public TextMeshProUGUI OptionBText;
    public GameObject DoorLeft;
    public GameObject DoorRight;
    public Slider ProgressBar;
    public float DoorSpeed = 10f;

    public static GameEvent currentEvent;//当前的事件
    private int currentEventID = 0;//当前事件ID号



    public GameObject ChracaterObj;
    public Sprite[] CharacterSprites;

    public bool isWaitForNext;



    private void Awake()
    {
        Player.Economic = Player.People = Player.Policy = Player.Military = 50;
    }

    private void Start()
    {
        ShowNewEvent();
    }
    

    public void ShowNewEvent()
    {

        currentEvent = EventCreator.GetGameEvent();//获取事件
        ShowBox.text = currentEvent.ShowText;
        OptionAText.text = currentEvent.OptionTextA;
        OptionBText.text = currentEvent.OptionTextB;
        ChracaterObj.GetComponent<SpriteRenderer>().sprite = CharacterSprites[currentEvent.ImageIndex];
        Camera.main.GetComponent<ScrollController>().ExpandScroll();

    }
    public void ShowResult(string buttonName)
    {
        Camera.main.GetComponent<ScrollController>().RollScroll();
        if (buttonName == "A")
            ShowBox.text = currentEvent.ResultTextA;
        else
            ShowBox.text = currentEvent.ResultTextB;
        //isWaitForNext = true;
        ProgressBar.value++;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            MoveDoor();
        }
        if (isWaitForNext && Input.GetMouseButtonDown(0))//当鼠标按下后抬起
        {
            isWaitForNext = false;
            MoveDoor();
            Invoke("ShowNewEvent", 0.4f);

        }
    }

    void MoveDoor()
    {
        StartCoroutine("DoorAnimation");
    }

    IEnumerator DoorAnimation()
    {
        float leftOrigin = -8.1f;
        float leftTarget = -5.5f;
        float rightOrigin = -0.53f;
        float rightTarget = -2.8f;
        while(DoorLeft.transform.localPosition.x<leftTarget||DoorRight.transform.localPosition.x>rightTarget)
        {
            DoorLeft.transform.Translate(Vector2.right * DoorSpeed*Time.deltaTime);
            DoorRight.transform.Translate(Vector2.left * DoorSpeed*Time.deltaTime);
            yield return null;
        }
        while(DoorLeft.transform.localPosition.x>leftOrigin||DoorRight.transform.localPosition.x<rightOrigin)
        {
            DoorLeft.transform.Translate(Vector2.left * DoorSpeed * Time.deltaTime);
            DoorRight.transform.Translate(Vector2.right * DoorSpeed * Time.deltaTime);
            yield return null;
        }





    }
}
