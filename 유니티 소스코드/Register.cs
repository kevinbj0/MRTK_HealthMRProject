using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField UserInput2;
    public InputField NameInput;

    public void OnClickRegister()
    {
        StartCoroutine(WebCn.Register(UserInput2.text, NameInput.text));
    }
}
