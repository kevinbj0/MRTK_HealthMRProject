using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Curl_Count : MonoBehaviour
{
    public GameObject Point1;
    public GameObject Point2;

    public delegate void Ex1_Count();
    public static event Ex1_Count CountUP;

    private void Start()
    {
        GetComponent<BoxCollider>();
        //Debug.Log("Curl ����");
    }
    private void OnTriggerEnter(Collider other)
    {
         if (Point1.activeSelf) {
            //Debug.Log("Point1 �浹 -> Point2 ����");
            Point1.SetActive(false);
            Point2.SetActive(true);
            CountUP();
        }
        else
        {
            //Debug.Log("Point2 �浹 -> Point1 ����");
            Point1.SetActive(true);
            Point2.SetActive(false);
            CountUP();
        }
    }
}
