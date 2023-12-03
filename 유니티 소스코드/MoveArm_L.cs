using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class MoveArm_L : MonoBehaviour
{
    bool firstTimeReading = true;

    Vector3 offset;
    Vector3 error;
    Vector3 lastInput;

    float qw;
    float qx;
    float qy;
    float qz;

    public GameObject cube1;
    ServerRead dt;
    void Start()
    {
        dt = new ServerRead();

        dt.sqlConnect();

        dt.sqlcmdall("delete from mpu2");
        dt.sqlcmdall("ALTER TABLE mpu2 AUTO_INCREMENT = 1;");
    }

    private void OnEnable()
    {
        dt.sqlConnect();
    }

    private void OnDisable()
    {
        dt.sqldisConnect();
    }

    void Update()
    {
        DataTable data = dt.selsql("select * from mpu2 order by id desc limit 1");

        string msg0 = data.Rows[data.Rows.Count - 1]["Q_W2"].ToString();
        string msg1 = data.Rows[data.Rows.Count - 1]["Q_X2"].ToString();
        string msg2 = data.Rows[data.Rows.Count - 1]["Q_Y2"].ToString();
        string msg3 = data.Rows[data.Rows.Count - 1]["Q_Z2"].ToString();

        qw = float.Parse(msg0);
        qx = float.Parse(msg1);
        qy = float.Parse(msg2);
        qz = float.Parse(msg3);


        Vector3 inputVector = new Vector3(-qz, qx, -qy);

        if (firstTimeReading)
        {
            offset = inputVector;
            lastInput = inputVector;
            firstTimeReading = false;
            error = Vector3.zero;
        }
        if (Mathf.Abs(inputVector.y - lastInput.y) <= 0.1f)
            error.y += inputVector.y - lastInput.y;
        transform.rotation = Quaternion.Euler(inputVector - offset - error);
        lastInput = inputVector;
    }
}
