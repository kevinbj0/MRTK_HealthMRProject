using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public static System.Action Player_Fix;
    public static System.Action Player_Orign;

    public GameObject Changeparent;
    public GameObject CameraParent;

    public GameObject Info;
    public GameObject DumbellUI;

    public GameObject EquipPoint1;
    public GameObject EquipPoint2;

    public GameObject CurlManger;

    Animator ani;

    private void Awake()
    {
        //플레이어 고정, 해제 Action
        Player_Fix = () => { FixPlayer(); };
        Player_Orign = () => { OriginalPlayer(); };
    }

    void Start()
    {
        ani = GetComponent<Animator>();
    }
    
    public void ShowCharactor()
    {
        gameObject.SetActive(true);
    }

    public void InvisivleCharactor()
    {
        gameObject.SetActive(false);
    }

    public void Curl()
    {
        ani.SetBool("SelectCurl", true);
    }

    public void Press()
    {
        ani.SetBool("SelectPress", true);
    }

    public void Raise()
    {
        ani.SetBool("SelectRaise", true);
    }

    public void UnCurl()
    {
        ani.SetBool("SelectCurl", false);
    }

    public void UnPress()
    {
        ani.SetBool("SelectPress", false);
    }

    public void UnRaise()
    {
        ani.SetBool("SelectRaise", false);
    }

    //플레이어 가이드 고정
    public void FixPlayer()
    {
        transform.parent = Changeparent.transform;
        Info.transform.parent = Changeparent.transform;
        CurlManger.transform.parent = Changeparent.transform;
    }

    //플레이어 가이드 원상복귀
    public void OriginalPlayer()
    {
        transform.parent = CameraParent.transform;
        //transform.localPosition = new Vector3(-0.013f, -0.531f, 0.896f);
        transform.rotation = new Quaternion(0, 0, 0, 0);

        Info.transform.parent = CameraParent.transform;
        Info.transform.localPosition = new Vector3(0f, 0f, 0f);
        Info.transform.rotation = new Quaternion(0, 0, 0, 0);

        CurlManger.transform.parent = CameraParent.transform;
    }

    public void ChangeDumbellUI()
    {
        DumbellUI.transform.parent = Changeparent.transform;
    }

    public void DestroyDumbell()
    {
        if(EquipPoint1.transform.Find("D7") != null)
        {
            Destroy(EquipPoint1.transform.GetChild(0).gameObject);
            Destroy(EquipPoint2.transform.GetChild(0).gameObject);
        }
        else if (EquipPoint1.transform.Find("D5") != null)
        {
            Destroy(EquipPoint1.transform.GetChild(0).gameObject);
            Destroy(EquipPoint2.transform.GetChild(0).gameObject);
        }
        else if (EquipPoint1.transform.Find("D3") != null)
        {
            Destroy(EquipPoint1.transform.GetChild(0).gameObject);
            Destroy(EquipPoint2.transform.GetChild(0).gameObject);
        }
        else if (EquipPoint1.transform.Find("D1") != null)
        {
            Destroy(EquipPoint1.transform.GetChild(0).gameObject);
            Destroy(EquipPoint2.transform.GetChild(0).gameObject);
        }
    }
}