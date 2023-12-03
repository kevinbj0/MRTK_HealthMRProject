using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll_Count : MonoBehaviour
{
    
    public delegate void Ex3_Count();
    public static event Ex3_Count CountUP;

    float _recentRot;
    float _preRot;
    bool first = false;

    public GameObject Arm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(first == false)
        {
            _recentRot = Arm.transform.rotation.eulerAngles.z;
            _preRot = Arm.transform.rotation.eulerAngles.z;
            first = true;
        }

        _recentRot = Arm.transform.rotation.eulerAngles.z;

        if(_recentRot - _preRot > 50f || _recentRot - _preRot < -50f)
        {
            //카운트업
            CountUP();
            _preRot = _recentRot;  
        }
    }
}
