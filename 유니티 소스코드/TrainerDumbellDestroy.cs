using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerDumbellDestroy : MonoBehaviour
{
    #region 아령 포인트
    //운동1
    public GameObject EquipPoint1;
    public GameObject EquipPoint2;

    //운동2
    public GameObject EquipPoint3;
    public GameObject EquipPoint4;

    //운동3
    public GameObject EquipPoint5;
    public GameObject EquipPoint6;

    //운동4
    public GameObject EquipPoint7;
    public GameObject EquipPoint8;

    //운동5
    public GameObject EquipPoint9;
    public GameObject EquipPoint10;

    //운동6
    public GameObject EquipPoint11;
    public GameObject EquipPoint12;
    #endregion

    public GameObject Trainer1;
    public GameObject Trainer2;
    public GameObject Trainer3;
    public GameObject Trainer4;
    public GameObject Trainer5;
    public GameObject Trainer6;

    public void DestroyDumbel()
    {
        if(Trainer1.activeSelf == true)
        {
            for(int i = 0; i < 4; i++)
            {
                EquipPoint1.transform.GetChild(i).gameObject.SetActive(false);
                EquipPoint2.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if(Trainer2.activeSelf == true)
        {
            for (int i = 0; i < 4; i++)
            {
                EquipPoint3.transform.GetChild(i).gameObject.SetActive(false);
                EquipPoint4.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (Trainer3.activeSelf == true)
        {
            for (int i = 0; i < 4; i++)
            {
                EquipPoint5.transform.GetChild(i).gameObject.SetActive(false);
                EquipPoint6.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (Trainer4.activeSelf == true)
        {
            for (int i = 0; i < 4; i++)
            {
                EquipPoint7.transform.GetChild(i).gameObject.SetActive(false);
                EquipPoint8.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (Trainer5.activeSelf == true)
        {
            for (int i = 0; i < 4; i++)
            {
                EquipPoint9.transform.GetChild(i).gameObject.SetActive(false);
                EquipPoint10.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else if (Trainer6.activeSelf == true)
        {
            for (int i = 0; i < 4; i++)
            {
                EquipPoint11.transform.GetChild(i).gameObject.SetActive(false);
                EquipPoint12.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void EquipDumbel1()
    {
        if(Trainer1.activeSelf == true)
        {
            EquipPoint1.transform.GetChild(0).gameObject.SetActive(true);
            EquipPoint2.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(Trainer2.activeSelf == true)
        {
            EquipPoint3.transform.GetChild(0).gameObject.SetActive(true);
            EquipPoint4.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (Trainer3.activeSelf == true)
        {
            EquipPoint5.transform.GetChild(0).gameObject.SetActive(true);
            EquipPoint6.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (Trainer4.activeSelf == true)
        {
            EquipPoint7.transform.GetChild(0).gameObject.SetActive(true);
            EquipPoint8.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (Trainer5.activeSelf == true)
        {
            EquipPoint9.transform.GetChild(0).gameObject.SetActive(true);
            EquipPoint10.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (Trainer6.activeSelf == true)
        {
            EquipPoint12.transform.GetChild(0).gameObject.SetActive(true);
            EquipPoint11.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void EquipDumbel3()
    {
        if (Trainer1.activeSelf == true)
        {
            EquipPoint1.transform.GetChild(1).gameObject.SetActive(true);
            EquipPoint2.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Trainer2.activeSelf == true)
        {
            EquipPoint3.transform.GetChild(1).gameObject.SetActive(true);
            EquipPoint4.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Trainer3.activeSelf == true)
        {
            EquipPoint5.transform.GetChild(1).gameObject.SetActive(true);
            EquipPoint6.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Trainer4.activeSelf == true)
        {
            EquipPoint7.transform.GetChild(1).gameObject.SetActive(true);
            EquipPoint8.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Trainer5.activeSelf == true)
        {
            EquipPoint9.transform.GetChild(1).gameObject.SetActive(true);
            EquipPoint10.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (Trainer6.activeSelf == true)
        {
            EquipPoint11.transform.GetChild(1).gameObject.SetActive(true);
            EquipPoint12.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void EquipDumbel5()
    {
        if (Trainer1.activeSelf == true)
        {
            EquipPoint1.transform.GetChild(2).gameObject.SetActive(true);
            EquipPoint2.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Trainer2.activeSelf == true)
        {
            EquipPoint3.transform.GetChild(2).gameObject.SetActive(true);
            EquipPoint4.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Trainer3.activeSelf == true)
        {
            EquipPoint5.transform.GetChild(2).gameObject.SetActive(true);
            EquipPoint6.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Trainer4.activeSelf == true)
        {
            EquipPoint7.transform.GetChild(2).gameObject.SetActive(true);
            EquipPoint8.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Trainer5.activeSelf == true)
        {
            EquipPoint9.transform.GetChild(2).gameObject.SetActive(true);
            EquipPoint10.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (Trainer6.activeSelf == true)
        {
            EquipPoint11.transform.GetChild(2).gameObject.SetActive(true);
            EquipPoint12.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void EquipDumbel7()
    {
        if (Trainer1.activeSelf == true)
        {
            EquipPoint1.transform.GetChild(3).gameObject.SetActive(true);
            EquipPoint2.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (Trainer2.activeSelf == true)
        {
            EquipPoint3.transform.GetChild(3).gameObject.SetActive(true);
            EquipPoint4.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (Trainer3.activeSelf == true)
        {
            EquipPoint5.transform.GetChild(3).gameObject.SetActive(true);
            EquipPoint6.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (Trainer4.activeSelf == true)
        {
            EquipPoint7.transform.GetChild(3).gameObject.SetActive(true);
            EquipPoint8.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (Trainer5.activeSelf == true)
        {
            EquipPoint9.transform.GetChild(3).gameObject.SetActive(true);
            EquipPoint10.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (Trainer6.activeSelf == true)
        {
            EquipPoint11.transform.GetChild(3).gameObject.SetActive(true);
            EquipPoint12.transform.GetChild(3).gameObject.SetActive(true);
        }
    }
}
