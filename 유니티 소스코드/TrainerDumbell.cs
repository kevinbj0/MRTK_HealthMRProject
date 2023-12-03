using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerDumbell : MonoBehaviour
{
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

    //아령
    GameObject Dumbell;

    public void EquipDumbell1()
    {
        if(this.gameObject.activeSelf == true)
        {
            if (this.gameObject.name == "TrainningDumbell_Raises_M")
            {
                EquipPoint1.transform.GetChild(0).gameObject.SetActive(true);
                EquipPoint2.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Raises_W")
            {
                EquipPoint3.transform.GetChild(0).gameObject.SetActive(true);
                EquipPoint4.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_M")
            {
                EquipPoint5.transform.GetChild(0).gameObject.SetActive(true);
                EquipPoint6.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_W")
            {
                EquipPoint9.transform.GetChild(0).gameObject.SetActive(true);
                EquipPoint10.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_M")
            {
                EquipPoint7.transform.GetChild(0).gameObject.SetActive(true);
                EquipPoint8.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_W")
            {
                EquipPoint11.transform.GetChild(0).gameObject.SetActive(true);
                EquipPoint12.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        
    }

    public void EquipDumbell3()
    {
        if(this.gameObject.activeSelf == true)
        {
            if (this.gameObject.name == "TrainningDumbell_Raises_M")
            {
                EquipPoint1.transform.GetChild(1).gameObject.SetActive(true);
                EquipPoint2.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Raises_W")
            {
                EquipPoint3.transform.GetChild(1).gameObject.SetActive(true);
                EquipPoint4.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_M")
            {
                EquipPoint5.transform.GetChild(1).gameObject.SetActive(true);
                EquipPoint6.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_W")
            {
                EquipPoint9.transform.GetChild(1).gameObject.SetActive(true);
                EquipPoint10.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_M")
            {
                EquipPoint7.transform.GetChild(1).gameObject.SetActive(true);
                EquipPoint8.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_W")
            {
                EquipPoint11.transform.GetChild(1).gameObject.SetActive(true);
                EquipPoint12.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    public void EquipDumbell5()
    {
        if (this.gameObject.activeSelf == true)
        {
            if (this.gameObject.name == "TrainningDumbell_Raises_M")
            {
                EquipPoint1.transform.GetChild(2).gameObject.SetActive(true);
                EquipPoint2.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Raises_W")
            {
                EquipPoint3.transform.GetChild(2).gameObject.SetActive(true);
                EquipPoint4.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_M")
            {
                EquipPoint5.transform.GetChild(2).gameObject.SetActive(true);
                EquipPoint6.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_W")
            {
                EquipPoint9.transform.GetChild(2).gameObject.SetActive(true);
                EquipPoint10.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_M")
            {
                EquipPoint7.transform.GetChild(2).gameObject.SetActive(true);
                EquipPoint8.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_W")
            {
                EquipPoint11.transform.GetChild(2).gameObject.SetActive(true);
                EquipPoint12.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    public void EquipDumbell7()
    {
        if (this.gameObject.activeSelf == true)
        {
            if (this.gameObject.name == "TrainningDumbell_Raises_M")
            {
                EquipPoint1.transform.GetChild(3).gameObject.SetActive(true);
                EquipPoint2.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Raises_W")
            {
                EquipPoint3.transform.GetChild(3).gameObject.SetActive(true);
                EquipPoint4.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_M")
            {
                EquipPoint5.transform.GetChild(3).gameObject.SetActive(true);
                EquipPoint6.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_W")
            {
                EquipPoint9.transform.GetChild(3).gameObject.SetActive(true);
                EquipPoint10.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_M")
            {
                EquipPoint7.transform.GetChild(3).gameObject.SetActive(true);
                EquipPoint8.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_W")
            {
                EquipPoint11.transform.GetChild(3).gameObject.SetActive(true);
                EquipPoint12.transform.GetChild(3).gameObject.SetActive(true);
            }
        }
    }

    public void InvisibleDumbel()
    {
        if(this.gameObject.activeSelf == true)
        {
            if (this.gameObject.name == "TrainningDumbell_Raises_M")
            {
                EquipPoint1.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint2.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint1.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint2.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint1.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint2.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint1.transform.GetChild(3).gameObject.SetActive(false);
                EquipPoint2.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if (this.gameObject.name == "TrainningDumbell_Raises_W")
            {
                EquipPoint3.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint4.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint3.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint4.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint3.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint4.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint3.transform.GetChild(3).gameObject.SetActive(false);
                EquipPoint4.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_M")
            {
                EquipPoint5.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint6.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint5.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint6.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint5.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint6.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint5.transform.GetChild(3).gameObject.SetActive(false);
                EquipPoint6.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if (this.gameObject.name == "TrainningDumbell_Biceps_W")
            {
                EquipPoint9.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint10.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint9.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint10.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint9.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint10.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint9.transform.GetChild(3).gameObject.SetActive(false);
                EquipPoint10.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_M")
            {
                EquipPoint7.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint8.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint7.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint8.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint7.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint8.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint7.transform.GetChild(3).gameObject.SetActive(false);
                EquipPoint8.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if (this.gameObject.name == "TrainningDumbell_ShoulderPress_W")
            {
                EquipPoint11.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint12.transform.GetChild(0).gameObject.SetActive(false);
                EquipPoint11.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint12.transform.GetChild(1).gameObject.SetActive(false);
                EquipPoint11.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint12.transform.GetChild(2).gameObject.SetActive(false);
                EquipPoint11.transform.GetChild(3).gameObject.SetActive(false);
                EquipPoint12.transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }
}
