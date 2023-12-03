using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExerciseManager : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        SelectTrainer.IdleON += Idle;
        SelectTrainer.CurlON += Curl;
        SelectTrainer.ReverseON += Reverse;
        SelectTrainer.RollingON += Rolling;
    }
    public void Idle()
    {
        //애니메이터의 모든 Bool 변수를 false
        AnimatorControllerParameter[] parameters = anim.parameters;

        foreach (AnimatorControllerParameter parameter in parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Bool)
            {
                anim.SetBool(parameter.name, false);
            }
        }
    }

    public void Curl()
    {
        anim.SetBool("isCurls", true);
    }

    public void Reverse()
    {
        anim.SetBool("isReverse", true);
    }
    public void Rolling()
    {
        anim.SetBool("isRolling", true);
    }
}
