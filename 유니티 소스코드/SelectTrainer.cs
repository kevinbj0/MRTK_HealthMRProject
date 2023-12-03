using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SelectTrainer : MonoBehaviour
{
    //트레이너 선택
    public GameObject Trainer01;
    public GameObject Trainer02;
    private byte Trainer;
    public static System.Action Select_Action;
    public static System.Action False_Action;

    //트레이너 운동동작
    public static System.Action Exercise_Start;
    private byte Select;

    //델리게이트, 이벤트 활용
    public delegate void ExerciseON();
    public static event ExerciseON IdleON;
    public static event ExerciseON CurlON;
    public static event ExerciseON ReverseON;
    public static event ExerciseON RollingON;

    //Instantiate활용
    private GameObject TR_Pool1;
    private GameObject TR_Pool2;
    public GameObject Parent;
    public GameObject Curl_Start;
    public GameObject Reverse_Start;
    public GameObject Rolling_Start;
    public GameObject TrainerRoom;


    private void Awake()
    {
        //Parent 하위로 이동시켜둠
        TR_Pool1 = Instantiate(Trainer01);
        Vector3 position = TR_Pool1.transform.position;
        TR_Pool1.transform.SetParent(Parent.transform);
        TR_Pool1.transform.position = position;

        TR_Pool2 = Instantiate(Trainer02);
        position = TR_Pool2.transform.position;
        TR_Pool2.transform.SetParent(Parent.transform);
        TR_Pool2.transform.position = position;

        //운동 동작 Action
        Exercise_Start = () => { Exercise(); };
        Select_Action = () => { Select_ON(); };
        False_Action = () => { Trainer_false(); };
    }

    private void Start()
    {
        TR_Pool1.SetActive(false);
        TR_Pool2.SetActive(false);

        //초기 Trainer
        Trainer = 1;
        Select = 1;
    }
 
    public void Select_ON()
    {
        Parent.transform.parent = null;
       switch(Trainer)
        {
            case 1:
                TR_Pool1.SetActive(true);
                break;
            case 2:
                TR_Pool2.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void Trainer_false()
    {
        TR_Pool1.SetActive(false);
        TR_Pool2.SetActive(false);
    }
    public void Select01()
    {
        Trainer = 1;
        TR_Pool1.SetActive(true);
        TR_Pool2.SetActive(false);
    }

    public void Select02()
    {
        Trainer = 2;
        TR_Pool2.SetActive(true);
        TR_Pool1.SetActive(false);
    }

    public void Exercise()
    {
       //Debug.Log("운동 시작");
        switch (Select)
        {
            case 1:
                CurlON();
                Curl_Start.SetActive(true);
                break;
            case 2:
                ReverseON();
                Reverse_Start.SetActive(true);
                break;
            case 3:
                RollingON();
                Rolling_Start.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void Idle()
    {
        IdleON();
    }
    public void Curl()
    {
        CurlON();
        Select = 1;
    }

    public void Reverse()
    {
        Debug.Log("리버스");
        ReverseON();
        Select = 2;
    }
    public void Rolling()
    {
        Debug.Log("롤링");
        RollingON();
        Select = 3;
    }

    void DefaultAction()
    {
        Debug.Log("Default action executed!");
    }
}
