using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BGChanger : MonoBehaviour
{
    static public BGChanger instance;

    public TextMeshPro Info1;
    public TextMeshPro Info2;
    public TextMeshPro Info3;
    public TextMeshPro Info4;
    public TextMeshPro Info5;
    public TextMeshPro Info6;

    public int countdownTime;
    public GameObject bg1;
    public GameObject bg2;
    float curTime = 0.0f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        //StartBGChange();

    }

    IEnumerator BGChangeStart()
    {
        while (countdownTime > 0)
        {
            curTime += Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
            if (curTime > 1.0f)
            {
                curTime = 0.0f;
                countdownTime--;
            }

        }
        yield return new WaitForSeconds(1.0f);
        bg1.SetActive(!bg1.activeSelf);
        bg2.SetActive(!bg2.activeSelf);
        countdownTime = 10;
        //StartBGChange();

    }

    public void StartBGChange()
    {
        StartCoroutine(BGChangeStart());
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    //StartBGChange();
        //    //bg1.SetActive(!bg1.activeSelf);
        //    //bg2.SetActive(!bg2.activeSelf);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    SelectMap(1);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    SelectMap(2);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    SelectMap(3);
        //}
    }

    public void SelectMap(int index)
    {
        switch (index)
        {
            case 1: // 1번맵 활성
                {
                    bg1.SetActive(true); 
                    bg2.SetActive(false);
                    Info1.color = Color.white;
                    Info2.color = Color.white;
                    Info3.color = Color.white;
                    Info4.color = Color.white;
                    Info5.color = Color.white;
                    Info6.color = Color.white;
                    break;
                }
            case 2:// 2번맵 활성
                {
                    bg1.SetActive(false);
                    bg2.SetActive(true);
                    Info1.color = Color.white;
                    Info2.color = Color.white;
                    Info3.color = Color.white;
                    Info4.color = Color.white;
                    Info5.color = Color.white;
                    Info6.color = Color.white;
                    break;
                }
            case 3://둘다비활성
                {
                    bg1.SetActive(false);
                    bg2.SetActive(false);
                    break;
                }
            default: break;

        }
    }
        

}
