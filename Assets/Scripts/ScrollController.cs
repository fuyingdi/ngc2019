using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public Button[] Scrolls;
    public float TargetY = 310f;
    public float OriginY = 40f;

    public float speed = 1f;

    void Start()
    {
        TargetY = 310f;
        OriginY = 40f;
        //StartCoroutine("ExpandScroll");
        //StartCoroutine("RollScroll");
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A)) StartCoroutine("RollScroll");
        if (Input.GetKey(KeyCode.S)) StartCoroutine("ExpandScroll");
    }

    public void foo()
    {
        Debug.Log("!");
        StartCoroutine("ExpandScroll");
    }


    // 展开
    public IEnumerator RollScroll()
    {
        Button btn1 = Scrolls[0];
        Button btn2 = Scrolls[1];
        RectTransform trans1 = btn1.GetComponent<RectTransform>();
        RectTransform trans2 = btn2.GetComponent<RectTransform>();
        while (trans1.localPosition.y < TargetY || trans2.localPosition.y < TargetY)
        {
            trans1.Translate(Vector3.up * speed);
            trans2.Translate(Vector3.up * speed);
            yield return null;
        }
    }

    // 卷起
    public IEnumerator ExpandScroll()
    {
        Debug.Log("2");
        Button btn1 = Scrolls[0];
        Button btn2 = Scrolls[1];
        RectTransform trans1 = btn1.GetComponent<RectTransform>();
        RectTransform trans2 = btn2.GetComponent<RectTransform>();
        while (trans1.localPosition.y > OriginY || trans2.localPosition.y > OriginY)
        {
            trans1.Translate(Vector3.down * speed);
            trans2.Translate(Vector3.down * speed);
            yield return null;
        }
    }
}
