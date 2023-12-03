using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Curl_Manager : MonoBehaviour
{
    public GameObject Parent;

    //종료 후 비활성화
    public TextMeshPro Text;
    public TextMeshPro Time;
    public TextMeshPro Data_Curl;
    public GameObject User_Obj;

    //종료 후 활성화
    public GameObject SelectExercise;
    public GameObject RuntimeMenu;

    //카운트
    private int Count = 0;
    private int Set = 0;
    public static int Data_Set = 0; //누적데이터 저장

    //운동 종료
    private int i;

    //효과음
    public AudioClip audioClip;
    private AudioSource audioSource;

    public GameObject Point1;
    public GameObject Point2;


    private void Start()
    {

        Data_Curl.text = "누적 : " + Data_Set.ToString() + "회";
        Curl_Count.CountUP += CountUP;

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

        //오디오 클립 재생
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("오디오 클립이 할당되지 않았습니다!");
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
    void Destroy() //운동 종료
    {
        Data_Set = Data_Set + Set;
        Debug.Log("누적 : " + Data_Set);

        Data_Curl.text = "누적 : " + Data_Set.ToString() + "회";


        Count = 0;
        Set = 0;

        if(MenuManager._loginMode == true) {  //서버 업로드
            StartCoroutine(WebCn.Data_Update(MenuManager.nt, Data_Set));
        }
        else { 
            MenuManager.Curl_Grade = Data_Set; //Curl값 저장 *** 
        }

        Player.Player_Orign();
        Parent.transform.parent = Camera.main.transform;
        gameObject.transform.parent = Camera.main.transform;

        Text.text = "운동시작시 카운트";
        Time.text = "타이머";

        //종료 후 비활성화
        Text.gameObject.SetActive(false);
        Time.gameObject.SetActive(false);
        User_Obj.gameObject.SetActive(false);

        //종료 후 활성화
        SelectExercise.transform.parent = null;
        SelectExercise.gameObject.SetActive(true);
        RuntimeMenu.gameObject.SetActive(true);
        MenuManager.Reset_Action();

        if (MenuManager._loginMode == true) {  //서버 읽어오기
            StartCoroutine(WebCn.Data_Read(WebCn._id));
        }
    }

    //운동 시작 카운트
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
