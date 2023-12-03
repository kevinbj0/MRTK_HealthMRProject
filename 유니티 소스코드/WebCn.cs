using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Diagnostics;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class WebCn : MonoBehaviour
{
    public static string _id;
    public static string _name;
    public static string _suc;


    public static float _dbcount;

    public static string _curlcount;
    public static string _reversecount;
    public static string _rollingcount;

    public IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    static public IEnumerator Login(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        //form.AddField("loginPass", realname);

        using (UnityWebRequest www = UnityWebRequest.Post("http://43.200.102.24/login/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                ToastMsg.Instrance.showMessage(www.downloadHandler.text, 1.0f);
                Debug.Log(username);
                _id = username;
                _suc = www.downloadHandler.text;
            }
        }
        if (_suc == "로그인 성공")
        {
            MenuManager.Login_Action();
        }
    }

    static public IEnumerator Register(string username, string realname)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("realname", realname);

        using (UnityWebRequest www = UnityWebRequest.Post("http://43.200.102.24/login/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                ToastMsg.Instrance.showMessage(www.downloadHandler.text, 1.0f);
                _id = username;
                _name = realname;
                _suc = www.downloadHandler.text;
            }
        }
    }


    //***
    static public IEnumerator Data_Update(string username, int Data_Set)
    {
        yield return new WaitForSeconds(2f);

        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("Data_Set", Data_Set);
        //form.AddField("loginPass", realname);

        using (UnityWebRequest www = UnityWebRequest.Post("http://43.200.102.24/login/countupdate.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    static public IEnumerator Data_Update2(string username, int Data_Set)
    {
        yield return new WaitForSeconds(2f);

        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("Data_Set2", Data_Set);
        //form.AddField("loginPass", realname);

        using (UnityWebRequest www = UnityWebRequest.Post("http://43.200.102.24/login/countupdate2.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    static public IEnumerator Data_Update3(string username, int Data_Set)
    {
        yield return new WaitForSeconds(2f);

        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("Data_Set3", Data_Set);
        //form.AddField("loginPass", realname);

        using (UnityWebRequest www = UnityWebRequest.Post("http://43.200.102.24/login/countupdate3.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    static public IEnumerator Data_Read(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://43.200.102.24/login/countread.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                _curlcount = www.downloadHandler.text;

                MenuManager.Curl_Num = _curlcount; //Curl값 저장 ***
                int.TryParse(_curlcount, out MenuManager.Curl_Grade);
  
                //_dbcount = float.Parse(_datacount);
                //Debug.Log(_dbcount);
            }
        }
    }

    static public IEnumerator Data_Read2(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://43.200.102.24/login/countread2.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                _reversecount = www.downloadHandler.text;

                MenuManager.Reverse_Num = _reversecount; //Reverse값 저장 ***
                int.TryParse(_reversecount, out MenuManager.Reverse_Grade);

                //_dbcount = float.Parse(_datacount);
                //Debug.Log(_dbcount);
            }
        }
    }

    static public IEnumerator Data_Read3(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://43.200.102.24/login/countread3.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                _rollingcount = www.downloadHandler.text;

                MenuManager.Rolling_Num = _rollingcount; //Rolling값 저장 ***
                int.TryParse(_rollingcount, out MenuManager.Rolling_Grade);

                //_dbcount = float.Parse(_datacount);
                //Debug.Log(_dbcount);
            }
        }
    }
}