using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    #region 오브젝트
    public static System.Action Login_Action;
    public static System.Action Reset_Action;

    //안내 텍스트 Panel
    public GameObject Info0;    
    public GameObject MiniMenu; //손 자세 안내
    public GameObject Info;     //////////////
    public GameObject Info2;
    public GameObject Info4_P;
    public GameObject Info6;
    public TextMeshPro timerText;   //운동 시작 시간 카운트
    public TextMeshPro postureText; //T포즈 시간
    public TextMeshPro ActiveCount;
    public TextMeshPro ActiveTimer;

    //기록(데이터보드)***
    public TextMeshPro Name_Board;
    public TextMeshPro Curl_Board;
    public TextMeshPro Reverse_Board;
    public TextMeshPro Rolling_Board;

    public TextMeshPro Curl_GR;
    public TextMeshPro Reverse_GR;
    public TextMeshPro Rolling_GR;

    public static string Curl_Num = "0";
    public static string Reverse_Num = "0";
    public static string Rolling_Num = "0";

    //사용자 ID표시 텍스트
    public MRTKUGUIInputField IdInputField; //커서 고정

    public Text nameText;
    public static string nt;
    public TextMeshPro welcomname;
    public GameObject welcomeboard;
    string username;
    public GameObject PlayerID;
    public TextMeshPro PlayerIdText;

    //운동 실행중
    public GameObject F_Menu; //운동 시작 전 손메뉴
    public GameObject L_Menu; //운동 중 손메뉴
    public GameObject Check;

    //자세 선택 전 트레이너 & 자세 선택 후 트레이너
    public GameObject PT; //선택 전
    public GameObject PTRoom; //선택 후

    //운동 애니메이션
    public Animator[] ani;

    //회원 선택
    public GameObject SelectLogIn;
    public GameObject LoginMenu;

    //시작 손메뉴
    public GameObject StartMenu;
    public GameObject RuntimeMenu;

    //공통 손메뉴(배경 선택)
    public GameObject MapMenu;
    public GameObject TrainerMenu;

    //기록 메뉴
    public GameObject DataMenu;

    //운동 자세 선택 손메뉴
    public GameObject InfoExercise;

    //운동목록 선택
    public GameObject ExerciseCheck;

 
    #endregion


    #region 변수
    //첫 시작 페이드 인 아웃 변수
    float _fade_in_time = 0;
    float _fade_out_time = 2f;
    float _time;
    bool _welcome = true;

    //환영 메세지 페이드 인 아웃 변수
    float _w_fade_in_time = 0;
    float _w_fade_out_time = 2f;
    float _w_time;
    bool _member = false;

    //메뉴 변수
    bool _selectTrainer = false;
    bool _selectMap = false;
    bool _selectInfo = false;
    bool _selectData = false;

    //기록을 int로 변환하여 저장
    public static int Curl_Grade = 0;
    public static int Reverse_Grade = 0;
    public static int Rolling_Grade = 0;
    public static int _level;

    //로그인 or 게스트 ***
    public static bool _loginMode;
    #endregion

    public TouchScreenKeyboard keyboard;

    private void Awake()
    {
        Login_Action = () => { SelectMember(); };
        Reset_Action = () => { Reset(); };
    }


    void Update()
    {
        if (_welcome)
        {
            StartCoroutine(FadeInOut()); //환영 메세지 연출
        }

        if (_member)
        {
            StartCoroutine(WelcomeFade()); //회원 or 게스트 환영 메세지 연출
        }

        //기록판 업데이트
        //Curl_Board.text = "누적 : " + Curl_Num + "회";
        //Reverse_Board.text = "누적 : " + Reverse_Num + "회";
        //Rolling_Board.text = "누적 : " + Rolling_Num + "회";
        Curl_Board.text = "누적 : " + Curl_Grade.ToString() + "회";
        Reverse_Board.text = "누적 : " + Reverse_Grade.ToString() + "회";
        Rolling_Board.text = "누적 : " + Rolling_Grade.ToString() + "회";


        //개수를 받아 입문자, 평균, 고수 등급결정(int 갯수, TextMeshPro)
        Rating(Curl_Grade, Curl_GR);
        Rating(Reverse_Grade, Reverse_GR);
        Rating(Rolling_Grade, Rolling_GR);
    }

    public void Rating(int C, TextMeshPro Rate)
    {
        if (C >= 0 && C < 11)
            Rate.text = "입문자";
        else if (C>=11 && C<21)
            Rate.text = "평균";
        else
            Rate.text = "고수";
    }

    //처음 진입 환영 메세지 페이드 인 아웃 구현
    IEnumerator FadeInOut() 
    {
        if (_fade_in_time <= 0)
            yield return new WaitForSeconds(1.5f); //1.5초 후 시작
        
        if (_fade_in_time < 2f) //페이드 인 전
        {                       //2초에 걸쳐 글자 페이드 인
            Info0.GetComponent<TextMeshPro>().color = new Color(1, 1, 1, _fade_in_time / 2);
            _fade_in_time += Time.deltaTime;
        }
        else //페이드 인 후
        {
            if (_time <= 0)
                yield return new WaitForSeconds(1.5f); //1.5초 후 시작

            if (_time < _fade_out_time) //페이드 아웃 전
            {                           //_fade_out_time초에 걸쳐 글자 페이드 아웃
                Info0.GetComponent<TextMeshPro>().color = new Color(1, 1, 1, 1f - _time / _fade_out_time);
                _time += Time.deltaTime;
            }
            else //페이드 아웃 후
            {
                _welcome = false; //Update에서 다시 반복되지 않도록 변수 설정
                Info0.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                SelectLogIn.SetActive(true); //회원 or 게스트 선택화면 활성화
                yield break;
            }
        }
    }

    //회원 or 게스트 환영 (FadeInOut함수와 동일)
    IEnumerator WelcomeFade()
    {
        if (_w_fade_in_time <= 0)
            yield return new WaitForSeconds(1.5f);
        if (_w_fade_in_time < 2f)
        {
            welcomname.color = new Color(1, 1, 1, _w_fade_in_time / 2);
            _w_fade_in_time += Time.deltaTime;
        }
        else
        {
            if (_w_time <= 0)
                yield return new WaitForSeconds(1.5f);

            if (_w_time < _w_fade_out_time)
            {
                welcomname.color = new Color(1, 1, 1, 1f - _w_time / _w_fade_out_time);
                _w_time += Time.deltaTime;
            }
            else
            {
                _member = false;
                welcomeboard.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Info.SetActive(true);       //손동작 안내문 활성화
                StartMenu.SetActive(true);  //시작 손메뉴 활성화
                //ShowPlayerID();             //플레이어 ID 화면 왼쪽 하단에 출력
                yield break;
            }
        }
    }

    public void J_Login()
    {
        LoginMenu.gameObject.SetActive(false);
        Debug.Log("성공");
    }
  
    //입력된 ID설정
    public void SelectMember()
    {
        _loginMode = true;
        nameText.text = WebCn._id;
        Debug.Log(WebCn._id);
        username = nameText.text + "님 환영합니다";
        nt = nameText.text;
        Debug.Log("nt : " + nt);

        //운동카운트 읽어옴
        StartCoroutine(WebCn.Data_Read(WebCn._id));
        StartCoroutine(WebCn.Data_Read2(WebCn._id));
        StartCoroutine(WebCn.Data_Read3(WebCn._id));
        //StartCoroutine(WebCn.Data_Read(MenuManager.nt));

        Invoke("J_Login", 1.0f);

        _member = true;
        //else if(WebCn._suc == "존재하지 않는 아이디입니다")
        //{
        //    Debug.Log("로그인 실패");
        //}
        //else
        //{
        //    username = nameText.text + "Guest님 환영합니다";
        //}
        welcomname.text = username;

        Name_Board.text = nt + "님";
    }

    public void GuestClick()
    {
        _loginMode = false;
        nameText.text = "Guest";
        nt = nameText.text;
        Debug.Log("nt : " + nt);
        username = nameText.text + "님 환영합니다";
        _member = true;
        welcomname.text = username;

        Name_Board.text = nt + "님";
    }

    //회원 등록
    public void SelectLoginClick()
    {
        LoginMenu.SetActive(true);
        IdInputField.ActivateInputField();
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);

        Debug.Log("로그인 / 회원가입 선택");
        return;
    }

    //손메뉴 중 운동하기 선택 시
    public void SelectExercise()
    {
        InfoExercise.transform.parent = null;

        if (_selectMap == true) //배경설정창이 켜있는 경우 끄기
        {
            _selectMap = false;
            MapMenu.SetActive(_selectMap);
        }

        StartCoroutine(ShowSelectMessage());          //운동자세 선택 메세지 출력

        _selectInfo = true;
        InfoExercise.SetActive(_selectInfo);

        Info.SetActive(false);
        
        return;
    }

    //운동자세 선택안내 메세지
    IEnumerator ShowSelectMessage()
    {
        Info.SetActive(false);
        Info2.SetActive(true);
        yield return new WaitForSecondsRealtime(3.5f);
        Info2.SetActive(false);
        yield break;
    }

    //손메뉴 중 운동목록 선택 시
    public void SelectInfoExercise()
    {
        if(_selectMap == true)                      //배경 설정창이 켜져있는 경우
        {
            _selectMap = false;                     //배경 설정창 끄기
            MapMenu.SetActive(_selectMap);          //////////////////
        }

        MapMenu.SetActive(false);
        DataMenu.SetActive(false);
        _selectMap = false;
        _selectData = false;

        _selectInfo = !_selectInfo;
        InfoExercise.SetActive(_selectInfo);        //운동목록창이 켜져있으면 끄고 꺼져있으면 켜기
    }

    //손메뉴 중 배경설정 선택 시(SelectInfoExercise함수와 동일)
    public void SelectMapClick()
    {
        if(_selectInfo == true)
        {
            _selectInfo = false;
            InfoExercise.SetActive(_selectInfo);
        }

        if(StartMenu.activeSelf == true)
        {
            MapMenu.transform.SetParent(StartMenu.transform.GetChild(0).transform);
            MapMenu.transform.localPosition = new Vector3(0.05f, 0, 0);
            MapMenu.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        else if(RuntimeMenu.activeSelf == true)
        {
            MapMenu.transform.SetParent(RuntimeMenu.transform.GetChild(0).transform);
            MapMenu.transform.localPosition = new Vector3(0.05f, 0, 0);
            MapMenu.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }


        DataMenu.SetActive(false);
        TrainerMenu.SetActive(false);
        MapMenu.SetActive(false);
        _selectTrainer = false;
        _selectData = false;

        _selectMap = !_selectMap;
        MapMenu.SetActive(_selectMap);             //배경창이 켜져있으면 끄고 꺼져있으면 켜기
    }

    //손메뉴 중 트레이너 선택 메뉴
    public void SelectTrainerClick()
    {
        if (_selectInfo == true)
        {
            _selectInfo = false;
            InfoExercise.SetActive(_selectInfo);
        }

        if (StartMenu.activeSelf == true)
        {
            TrainerMenu.transform.SetParent(StartMenu.transform.GetChild(0).transform);
            TrainerMenu.transform.localPosition = new Vector3(0.05f, 0, 0);
            TrainerMenu.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        else if (RuntimeMenu.activeSelf == true)
        {
            TrainerMenu.transform.SetParent(RuntimeMenu.transform.GetChild(0).transform);
            TrainerMenu.transform.localPosition = new Vector3(0.05f, 0, 0);
            TrainerMenu.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        DataMenu.SetActive(false);
        TrainerMenu.SetActive(false);
        MapMenu.SetActive(false);
        _selectData = false;
        _selectMap = false;

        _selectTrainer = !_selectTrainer;
        TrainerMenu.SetActive(_selectTrainer);             //배경창이 켜져있으면 끄고 꺼져있으면 켜기
    }

    //Data 메뉴 클릭시
    public void SelectDataClick()
    {
        if (_selectInfo == true)
        {
            _selectInfo = false;
            InfoExercise.SetActive(_selectInfo);
        }

        if (StartMenu.activeSelf == true)
        {
            DataMenu.transform.SetParent(StartMenu.transform.GetChild(0).transform);
            DataMenu.transform.localPosition = new Vector3(0.09f, 0, 0);
            DataMenu.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        else if (RuntimeMenu.activeSelf == true)
        {
            DataMenu.transform.SetParent(RuntimeMenu.transform.GetChild(0).transform);
            DataMenu.transform.localPosition = new Vector3(0.09f, 0, 0);
            DataMenu.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        DataMenu.SetActive(false);
        TrainerMenu.SetActive(false);
        MapMenu.SetActive(false);
        _selectTrainer = false;
        _selectMap = false;

        _selectData = !_selectData;
        DataMenu.SetActive(_selectData);             //배경창이 켜져있으면 끄고 꺼져있으면 켜기
    }

    //화면에 ID 출력
    void ShowPlayerID()
    {
        if (nameText.text.Length > 0)
        {
            PlayerIdText.text = "ID: " + nameText.text;
        }
        else
        {
            PlayerIdText.text = "Guest";
        }

        PlayerID.SetActive(true);
    }

    //운동 시작 카운트
    public void ExerciseTimer()
    {
        StartCoroutine(StartTimer());
    }

    //운동 시작 카운트
    IEnumerator StartTimer()
    {
        timerText.text = "3초후에 시작합니다";
        yield return new WaitForSeconds(1f);
        timerText.text = "2초후에 시작합니다";
        yield return new WaitForSeconds(1f);
        timerText.text = "1초후에 시작합니다";
        yield return new WaitForSeconds(1f);
        timerText.text = "운동자세를 보고 따라하세요";

        SelectTrainer.Exercise_Start(); //***

        //L_Menu.SetActive(true);                         //운동중 손메뉴 활성화
        yield return new WaitForSeconds(2f);
        timerText.gameObject.SetActive(false);
    }

    //T포즈 자세 잡기
    public void FixPosture()
    {
        StartCoroutine(StartFixPosture());
    }

    //T포즈 자세 잡기
    IEnumerator StartFixPosture()
    {
        F_Menu.SetActive(false);

        //캐릭터 몸통고정 ***
        Player.Player_Fix();
        postureText.text = "3초간 자세를 유지하세요";
        yield return new WaitForSeconds(1f);
        postureText.text = "2초간 자세를 유지하세요";
        yield return new WaitForSeconds(1f);
        postureText.text = "1초간 자세를 유지하세요";
        yield return new WaitForSeconds(1f);
        
        //Info6.SetActive(true);          //운동 시작 확인 메세지
        // Check.SetActive(true);          ///////////////////////
        //***
        postureText.text = "운동자세를 보고 따라하세요";
        SelectTrainer.Exercise_Start();
        ActiveCount.gameObject.SetActive(true);
        ActiveTimer.gameObject.SetActive(true);

        //L_Menu.SetActive(true);                         //운동중 손메뉴 활성화
        yield return new WaitForSeconds(2f);
        postureText.gameObject.SetActive(false);
    }

    //연습모드
    public void SelectPractice()
    {
        StartCoroutine(Practice());
    }

    //연습모드
    IEnumerator Practice()
    {
        Info4_P.SetActive(true);
        yield return new WaitForSeconds(2f);
        Info4_P.SetActive(false);
    }

    //운동 자세 선택 메뉴로 돌아가기
    public void ReturnExercise()
    {
        InfoExercise.transform.SetParent(null);
        _selectInfo = true;
        InfoExercise.SetActive(true);

        for (int i = 0; i < 5; i++)
        {
            ani[i].SetBool("isExercise", false);  //트레이너 애니메이션 idle
        }

        StartCoroutine(ShowSelectMessage()); //안내 메세지 활성화
    }

    public void ReturnAni()
    {
        for (int i = 0; i < 5; i++)
        {
            ani[i].SetBool("isExercise", false);
        }
    }

    //운동 종료시 트레이너 위치 설정
    public void ExitExercise()
    {
        PTRoom.transform.GetChild(0).gameObject.SetActive(false);   //플레이어 앞에서 움직이는 트레이너 비활성화
        PTRoom.transform.GetChild(1).gameObject.SetActive(false);
        PTRoom.transform.GetChild(2).gameObject.SetActive(false);
        PTRoom.transform.GetChild(3).gameObject.SetActive(false);
        PTRoom.transform.GetChild(4).gameObject.SetActive(false);
        PTRoom.transform.GetChild(5).gameObject.SetActive(false);

        PTRoom.transform.parent = Camera.main.transform;                    //트레이너 위치를 메인 카메라와 같이 움직이도록 설정 
        PTRoom.transform.rotation = new Quaternion(0, 0, 0, 0);             
        PTRoom.transform.localPosition = new Vector3(0, -1.743f, 3.16f);    //카메라와 일정거리 유지
        PTRoom.GetComponent<Billboard>().enabled = true;                    //트레이너가 카메라를 바라보도록 설정
        PT.SetActive(true);                                                 //운동자세 트레이너 활성화
    }

    //운동목록 선택
    public void SelectExerciseList()
    {
        InfoExercise.transform.SetParent(Camera.main.transform);

        _selectInfo = false;
        InfoExercise.SetActive(_selectInfo);

       // F_Menu.SetActive(true);
        ExerciseCheck.SetActive(true);
    }

    //
    public void SelectExerciseCheckOk()
    {
        ExerciseCheck.SetActive(false);
    }

    public void SelectExerciseCheckNo()
    {
        ExerciseCheck.SetActive(false);
        _selectInfo = true;
        InfoExercise.SetActive(_selectInfo);
    }

    public void PracticeExercise()
    {
        Invoke("Exercise", 0.5f);
    }

    public void StartExercise()
    {
        Invoke("Exercise", 5.0f);
    }
    void Exercise()
    {
        for (int i = 0; i < 6; i++)
        {
            if (ani[i].gameObject.activeSelf == true)
            {
                ani[i].SetBool("isExercise", true);
                break;
            }
        }
    }

    public void Easy()
    {
        _level = 10;
    }
    public void Nomal()
    {
        _level = 20;
    }
    public void Hard()
    {
        _level = 30;
    }
    public void Reset()
    {
        _selectTrainer = false;
        _selectMap = false;
        _selectInfo = false;
        _selectData = false;
    }
}

