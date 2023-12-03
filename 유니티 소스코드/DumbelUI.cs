using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbelUI : MonoBehaviour
{
    Transform dumbelTr;

    private void Awake()
    {
        dumbelTr = this.gameObject.GetComponent<Transform>();
    }
    public void CancelDumbell()
    {
        this.gameObject.transform.parent = Camera.main.transform;
        this.gameObject.transform.position = new Vector3(dumbelTr.position.x, dumbelTr.position.y, dumbelTr.position.z);
        this.gameObject.SetActive(false);
    }
}
