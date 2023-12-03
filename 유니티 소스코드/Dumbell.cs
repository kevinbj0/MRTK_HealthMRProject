using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumbell : MonoBehaviour
{
    public GameObject DumbellUI;
    public GameObject playerEquipPoint1;
    public GameObject playerEquipPoint2;
    GameObject playerDumbell;

    /* 아령을 선택하여 캐릭터에 아령을 장착하는 함수 */
    public void OnClick()
    {
        if (this.gameObject.name == "MRTK_Dumbbell10")
        {
            playerDumbell = Resources.Load("Dumbbell10") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D10";
            obj2.name = "D10 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
        else if (this.gameObject.name == "MRTK_Dumbbell9")
        {
            playerDumbell = Resources.Load("Dumbbell9") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D9";
            obj2.name = "D9 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
        else if (this.gameObject.name == "MRTK_Dumbbell8")
        {
            playerDumbell = Resources.Load("Dumbbell8") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D8";
            obj2.name = "D8 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
        else if (this.gameObject.name == "MRTK_Dumbbell7")
        {
            playerDumbell = Resources.Load("Dumbbell7") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D7";
            obj2.name = "D7 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
        else if (this.gameObject.name == "MRTK_Dumbbell6")
        {
            playerDumbell = Resources.Load("Dumbbell6") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D6";
            obj2.name = "D6 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
        else if (this.gameObject.name == "MRTK_Dumbbell5")
        {
            playerDumbell = Resources.Load("Dumbbell5") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D5";
            obj2.name = "D5 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
        else if (this.gameObject.name == "MRTK_Dumbbell4")
        {
            playerDumbell = Resources.Load("Dumbbell4") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D4";
            obj2.name = "D4 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
        else if (this.gameObject.name == "MRTK_Dumbbell3")
        {
            playerDumbell = Resources.Load("Dumbbell3") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D3";
            obj2.name = "D3 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
        else if (this.gameObject.name == "MRTK_Dumbbell2")
        {
            playerDumbell = Resources.Load("Dumbbell2") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D2";
            obj2.name = "D2 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
        else if (this.gameObject.name == "MRTK_Dumbbell1")
        {
            playerDumbell = Resources.Load("Dumbbell1") as GameObject;

            GameObject obj1 = MonoBehaviour.Instantiate(playerDumbell);
            GameObject obj2 = MonoBehaviour.Instantiate(playerDumbell);

            obj1.name = "D1";
            obj2.name = "D1 (1)";

            obj1.transform.SetParent(playerEquipPoint1.transform);
            obj2.transform.SetParent(playerEquipPoint2.transform);
            obj1.transform.localPosition = Vector3.zero;
            obj2.transform.localPosition = Vector3.zero;
            obj1.transform.rotation = new Quaternion(0, 0, 0, 0);
            obj2.transform.rotation = new Quaternion(0, 0, 0, 0);

            DumbellUI.transform.parent = Camera.main.transform;
        }
    }
}
