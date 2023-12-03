using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    #region ������Ʈ
    public static System.Action Login_Action;
    public static System.Action Reset_Action;

    //�ȳ� �ؽ�Ʈ Panel
    public GameObject Info0;    
    public GameObject MiniMenu; //�� �ڼ� �ȳ�
    public GameObject Info;     //////////////
    public GameObject Info2;
    public GameObject Info4_P;
    public GameObject Info6;
    public TextMeshPro timerText;   //� ���� �ð� ī��Ʈ
    public TextMeshPro postureText; //T���� �ð�
    public TextMeshPro ActiveCount;
    public TextMeshPro ActiveTimer;

    //���(�����ͺ���)***
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

    //����� IDǥ�� �ؽ�Ʈ
    public MRTKUGUIInputField IdInputField; //Ŀ�� ����

    public Text nameText;
    public static string nt;
    public TextMeshPro welcomname;
    public GameObject welcomeboard;
    string username;
    public GameObject PlayerID;
    public TextMeshPro PlayerIdText;

    //� ������
    public GameObject F_Menu; //� ���� �� �ո޴�
    public GameObject L_Menu; //� �� �ո޴�
    public GameObject Check;

    //�ڼ� ���� �� Ʈ���̳� & �ڼ� ���� �� Ʈ���̳�
    public GameObject PT; //���� ��
    public GameObject PTRoom; //���� ��

    //� �ִϸ��̼�
    public Animator[] ani;

    //ȸ�� ����
    public GameObject SelectLogIn;
    public GameObject LoginMenu;

    //���� �ո޴�
    public GameObject StartMenu;
    public GameObject RuntimeMenu;

    //���� �ո޴�(��� ����)
    public GameObject MapMenu;
    public GameObject TrainerMenu;

    //��� �޴�
    public GameObject DataMenu;

    //� �ڼ� ���� �ո޴�
    public GameObject InfoExercise;

    //���� ����
    public GameObject ExerciseCheck;

 
    #endregion


    #region ����
    //ù ���� ���̵� �� �ƿ� ����
    float _fade_in_time = 0;
    float _fade_out_time = 2f;
    float _time;
    bool _welcome = true;

    //ȯ�� �޼��� ���̵� �� �ƿ� ����
    float _w_fade_in_time = 0;
    float _w_fade_out_time = 2f;
    float _w_time;
    bool _member = false;

    //�޴� ����
    bool _selectTrainer = false;
    bool _selectMap = false;
    bool _selectInfo = false;
    bool _selectData = false;

    //����� int�� ��ȯ�Ͽ� ����
    public static int Curl_Grade = 0;
    public static int Reverse_Grade = 0;
    public static int Rolling_Grade = 0;
    public static int _level;

    //�α��� or �Խ�Ʈ ***
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
            StartCoroutine(FadeInOut()); //ȯ�� �޼��� ����
        }

        if (_member)
        {
            StartCoroutine(WelcomeFade()); //ȸ�� or �Խ�Ʈ ȯ�� �޼��� ����
        }

        //����� ������Ʈ
        //Curl_Board.text = "���� : " + Curl_Num + "ȸ";
        //Reverse_Board.text = "���� : " + Reverse_Num + "ȸ";
        //Rolling_Board.text = "���� : " + Rolling_Num + "ȸ";
        Curl_Board.text = "���� : " + Curl_Grade.ToString() + "ȸ";
        Reverse_Board.text = "���� : " + Reverse_Grade.ToString() + "ȸ";
        Rolling_Board.text = "���� : " + Rolling_Grade.ToString() + "ȸ";


        //������ �޾� �Թ���, ���, ��� ��ް���(int ����, TextMeshPro)
        Rating(Curl_Grade, Curl_GR);
        Rating(Reverse_Grade, Reverse_GR);
        Rating(Rolling_Grade, Rolling_GR);
    }

    public void Rating(int C, TextMeshPro Rate)
    {
        if (C >= 0 && C < 11)
            Rate.text = "�Թ���";
        else if (C>=11 && C<21)
            Rate.text = "���";
        else
            Rate.text = "���";
    }

    //ó�� ���� ȯ�� �޼��� ���̵� �� �ƿ� ����
    IEnumerator FadeInOut() 
    {
        if (_fade_in_time <= 0)
            yield return new WaitForSeconds(1.5f); //1.5�� �� ����
        
        if (_fade_in_time < 2f) //���̵� �� ��
        {                       //2�ʿ� ���� ���� ���̵� ��
            Info0.GetComponent<TextMeshPro>().color = new Color(1, 1, 1, _fade_in_time / 2);
            _fade_in_time += Time.deltaTime;
        }
        else //���̵� �� ��
        {
            if (_time <= 0)
                yield return new WaitForSeconds(1.5f); //1.5�� �� ����

            if (_time < _fade_out_time) //���̵� �ƿ� ��
            {                           //_fade_out_time�ʿ� ���� ���� ���̵� �ƿ�
                Info0.GetComponent<TextMeshPro>().color = new Color(1, 1, 1, 1f - _time / _fade_out_time);
                _time += Time.deltaTime;
            }
            else //���̵� �ƿ� ��
            {
                _welcome = false; //Update���� �ٽ� �ݺ����� �ʵ��� ���� ����
                Info0.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                SelectLogIn.SetActive(true); //ȸ�� or �Խ�Ʈ ����ȭ�� Ȱ��ȭ
                yield break;
            }
        }
    }

    //ȸ�� or �Խ�Ʈ ȯ�� (FadeInOut�Լ��� ����)
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
                Info.SetActive(true);       //�յ��� �ȳ��� Ȱ��ȭ
                StartMenu.SetActive(true);  //���� �ո޴� Ȱ��ȭ
                //ShowPlayerID();             //�÷��̾� ID ȭ�� ���� �ϴܿ� ���
                yield break;
            }
        }
    }

    public void J_Login()
    {
        LoginMenu.gameObject.SetActive(false);
        Debug.Log("����");
    }
  
    //�Էµ� ID����
    public void SelectMember()
    {
        _loginMode = true;
        nameText.text = WebCn._id;
        Debug.Log(WebCn._id);
        username = nameText.text + "�� ȯ���մϴ�";
        nt = nameText.text;
        Debug.Log("nt : " + nt);

        //�ī��Ʈ �о��
        StartCoroutine(WebCn.Data_Read(WebCn._id));
        StartCoroutine(WebCn.Data_Read2(WebCn._id));
        StartCoroutine(WebCn.Data_Read3(WebCn._id));
        //StartCoroutine(WebCn.Data_Read(MenuManager.nt));

        Invoke("J_Login", 1.0f);

        _member = true;
        //else if(WebCn._suc == "�������� �ʴ� ���̵��Դϴ�")
        //{
        //    Debug.Log("�α��� ����");
        //}
        //else
        //{
        //    username = nameText.text + "Guest�� ȯ���մϴ�";
        //}
        welcomname.text = username;

        Name_Board.text = nt + "��";
    }

    public void GuestClick()
    {
        _loginMode = false;
        nameText.text = "Guest";
        nt = nameText.text;
        Debug.Log("nt : " + nt);
        username = nameText.text + "�� ȯ���մϴ�";
        _member = true;
        welcomname.text = username;

        Name_Board.text = nt + "��";
    }

    //ȸ�� ���
    public void SelectLoginClick()
    {
        LoginMenu.SetActive(true);
        IdInputField.ActivateInputField();
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);

        Debug.Log("�α��� / ȸ������ ����");
        return;
    }

    //�ո޴� �� ��ϱ� ���� ��
    public void SelectExercise()
    {
        InfoExercise.transform.parent = null;

        if (_selectMap == true) //��漳��â�� ���ִ� ��� ����
        {
            _selectMap = false;
            MapMenu.SetActive(_selectMap);
        }

        StartCoroutine(ShowSelectMessage());          //��ڼ� ���� �޼��� ���

        _selectInfo = true;
        InfoExercise.SetActive(_selectInfo);

        Info.SetActive(false);
        
        return;
    }

    //��ڼ� ���þȳ� �޼���
    IEnumerator ShowSelectMessage()
    {
        Info.SetActive(false);
        Info2.SetActive(true);
        yield return new WaitForSecondsRealtime(3.5f);
        Info2.SetActive(false);
        yield break;
    }

    //�ո޴� �� ���� ���� ��
    public void SelectInfoExercise()
    {
        if(_selectMap == true)                      //��� ����â�� �����ִ� ���
        {
            _selectMap = false;                     //��� ����â ����
            MapMenu.SetActive(_selectMap);          //////////////////
        }

        MapMenu.SetActive(false);
        DataMenu.SetActive(false);
        _selectMap = false;
        _selectData = false;

        _selectInfo = !_selectInfo;
        InfoExercise.SetActive(_selectInfo);        //����â�� ���������� ���� ���������� �ѱ�
    }

    //�ո޴� �� ��漳�� ���� ��(SelectInfoExercise�Լ��� ����)
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
        MapMenu.SetActive(_selectMap);             //���â�� ���������� ���� ���������� �ѱ�
    }

    //�ո޴� �� Ʈ���̳� ���� �޴�
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
        TrainerMenu.SetActive(_selectTrainer);             //���â�� ���������� ���� ���������� �ѱ�
    }

    //Data �޴� Ŭ����
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
        DataMenu.SetActive(_selectData);             //���â�� ���������� ���� ���������� �ѱ�
    }

    //ȭ�鿡 ID ���
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

    //� ���� ī��Ʈ
    public void ExerciseTimer()
    {
        StartCoroutine(StartTimer());
    }

    //� ���� ī��Ʈ
    IEnumerator StartTimer()
    {
        timerText.text = "3���Ŀ� �����մϴ�";
        yield return new WaitForSeconds(1f);
        timerText.text = "2���Ŀ� �����մϴ�";
        yield return new WaitForSeconds(1f);
        timerText.text = "1���Ŀ� �����մϴ�";
        yield return new WaitForSeconds(1f);
        timerText.text = "��ڼ��� ���� �����ϼ���";

        SelectTrainer.Exercise_Start(); //***

        //L_Menu.SetActive(true);                         //��� �ո޴� Ȱ��ȭ
        yield return new WaitForSeconds(2f);
        timerText.gameObject.SetActive(false);
    }

    //T���� �ڼ� ���
    public void FixPosture()
    {
        StartCoroutine(StartFixPosture());
    }

    //T���� �ڼ� ���
    IEnumerator StartFixPosture()
    {
        F_Menu.SetActive(false);

        //ĳ���� ������� ***
        Player.Player_Fix();
        postureText.text = "3�ʰ� �ڼ��� �����ϼ���";
        yield return new WaitForSeconds(1f);
        postureText.text = "2�ʰ� �ڼ��� �����ϼ���";
        yield return new WaitForSeconds(1f);
        postureText.text = "1�ʰ� �ڼ��� �����ϼ���";
        yield return new WaitForSeconds(1f);
        
        //Info6.SetActive(true);          //� ���� Ȯ�� �޼���
        // Check.SetActive(true);          ///////////////////////
        //***
        postureText.text = "��ڼ��� ���� �����ϼ���";
        SelectTrainer.Exercise_Start();
        ActiveCount.gameObject.SetActive(true);
        ActiveTimer.gameObject.SetActive(true);

        //L_Menu.SetActive(true);                         //��� �ո޴� Ȱ��ȭ
        yield return new WaitForSeconds(2f);
        postureText.gameObject.SetActive(false);
    }

    //�������
    public void SelectPractice()
    {
        StartCoroutine(Practice());
    }

    //�������
    IEnumerator Practice()
    {
        Info4_P.SetActive(true);
        yield return new WaitForSeconds(2f);
        Info4_P.SetActive(false);
    }

    //� �ڼ� ���� �޴��� ���ư���
    public void ReturnExercise()
    {
        InfoExercise.transform.SetParent(null);
        _selectInfo = true;
        InfoExercise.SetActive(true);

        for (int i = 0; i < 5; i++)
        {
            ani[i].SetBool("isExercise", false);  //Ʈ���̳� �ִϸ��̼� idle
        }

        StartCoroutine(ShowSelectMessage()); //�ȳ� �޼��� Ȱ��ȭ
    }

    public void ReturnAni()
    {
        for (int i = 0; i < 5; i++)
        {
            ani[i].SetBool("isExercise", false);
        }
    }

    //� ����� Ʈ���̳� ��ġ ����
    public void ExitExercise()
    {
        PTRoom.transform.GetChild(0).gameObject.SetActive(false);   //�÷��̾� �տ��� �����̴� Ʈ���̳� ��Ȱ��ȭ
        PTRoom.transform.GetChild(1).gameObject.SetActive(false);
        PTRoom.transform.GetChild(2).gameObject.SetActive(false);
        PTRoom.transform.GetChild(3).gameObject.SetActive(false);
        PTRoom.transform.GetChild(4).gameObject.SetActive(false);
        PTRoom.transform.GetChild(5).gameObject.SetActive(false);

        PTRoom.transform.parent = Camera.main.transform;                    //Ʈ���̳� ��ġ�� ���� ī�޶�� ���� �����̵��� ���� 
        PTRoom.transform.rotation = new Quaternion(0, 0, 0, 0);             
        PTRoom.transform.localPosition = new Vector3(0, -1.743f, 3.16f);    //ī�޶�� �����Ÿ� ����
        PTRoom.GetComponent<Billboard>().enabled = true;                    //Ʈ���̳ʰ� ī�޶� �ٶ󺸵��� ����
        PT.SetActive(true);                                                 //��ڼ� Ʈ���̳� Ȱ��ȭ
    }

    //���� ����
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

