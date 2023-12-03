using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField UserInput;

    //***
    public string InputText;

    //***
    public void OnClickLogin()
    {
        StartCoroutine(WebCn.Login(UserInput.text));
        InputText = UserInput.text;
    }
}