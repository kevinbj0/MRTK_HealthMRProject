using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reverse_Manager : MonoBehaviour
{
    //���� �� ��Ȱ��ȭ
    public TextMeshPro Text;
    public TextMeshPro Time;
    public TextMeshPro Data_Reverse;
    public GameObject User_Obj;

    //���� �� Ȱ��ȭ
    public GameObject SelectExercise;
    public GameObject RuntimeMenu;

    //ī��Ʈ
    private int Count = 0;
    private int Set = 0;
    public static int Data_Set = 0; //���������� ����

    //� ����
    private int i;

    //ȿ����
    public AudioClip audioClip;
    private AudioSource audioSource;

    public GameObject Point1;
    public GameObject Point2;


    private void Start()
    {

        Data_Reverse.text = "���� : " + Data_Set.ToString() + "ȸ";
        Reverse_Count.CountUP += CountUP;

        audioSource = GetComponent<AudioSource>();
    }

    public void CountUP()
    {
        Count = Count + 1;
        Set = Count / 2;
        if (Set == 0)
        {
            StartCoroutine(StartTimer());
        }
        Text.text = "Count : " + Set.ToString();

        //����� Ŭ�� ���
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("����� Ŭ���� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    public void CountEnd()
    {
        Text.text = "Total : " + Set.ToString();
        Invoke("Destroy", 4.0f);
        Point1.gameObject.SetActive(false);
        Point2.gameObject.SetActive(false);
        SelectTrainer.False_Action();
    }
    void Destroy() //� ����
    {
        Data_Set = Data_Set + Set;
        Debug.Log("���� : " + Data_Set);

        Data_Reverse.text = "���� : " + Data_Set.ToString() + "ȸ";


        Count = 0;
        Set = 0;

        if (MenuManager._loginMode == true)
        {
            //***
            StartCoroutine(WebCn.Data_Update2(MenuManager.nt, Data_Set));
        }
        else
        {
            //Reverse�� ���� ***
            MenuManager.Reverse_Grade = Data_Set;
        }
        //���� fix Ǯ����
        Player.Player_Orign();

        //���� �� ��Ȱ��ȭ
        Text.gameObject.SetActive(false);
        Time.gameObject.SetActive(false);
        User_Obj.gameObject.SetActive(false);

        //���� �� Ȱ��ȭ
        SelectExercise.transform.parent = null;
        SelectExercise.gameObject.SetActive(true);
        RuntimeMenu.gameObject.SetActive(true);
        MenuManager.Reset_Action();

        if (MenuManager._loginMode == true)
        {
            StartCoroutine(WebCn.Data_Read2(WebCn._id));
        }
    }

    //� ���� ī��Ʈ
    IEnumerator StartTimer()
    {
        for (i = MenuManager._level; i >= 0; i--)
        {
            Time.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        Time.text = "Timer Set!";
        CountEnd();
    }
}
