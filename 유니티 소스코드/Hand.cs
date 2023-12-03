using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject MiniMenu;

    public void VaildHand()
    {
        MiniMenu.SetActive(true);
    }

    public void InVaildHand()
    {
        MiniMenu.SetActive(false);
    }
}
