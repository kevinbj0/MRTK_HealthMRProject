using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ServerRead : MonoBehaviour
{
    MySqlConnection sqlconn = null;
    private string sqlDBip = "chanwoodb.cq7zcrulgls7.ap-northeast-2.rds.amazonaws.com";
    private string sqlDBname = "esp32";
    private string sqlDBid = "chanwoo";
    private string sqlDBpw = "loveyou905";

    public void sqlConnect()
    {
        //DB���� �Է�
        string sqlDatabase = "Server=" + sqlDBip + ";Database=" + sqlDBname + ";UserId=" + sqlDBid + ";Password=" + sqlDBpw + "";

        //���� Ȯ���ϱ�
        try
        {
            sqlconn = new MySqlConnection(sqlDatabase);
            sqlconn.Open();
            //Debug.Log("SQL�� ���� ���� : " + sqlconn.State); //������ �Ǹ� OPEN�̶�� ��Ÿ��
        }
        catch (Exception msg)
        {
            Debug.Log(msg); //��Ÿ�ٸ������� ��Ÿ���� ������ ���� ������ ��Ÿ��
        }
    }

    public void sqldisConnect()
    {
        sqlconn.Close();
        Debug.Log("SQL�� ���� ���� : " + sqlconn.State); //������ ����� Close�� ��Ÿ�� 
    }

    public void sqlcmdall(string allcmd) //�Լ��� �ҷ��ö� ��ɾ ���� String�� ���ڷ� �޾ƿ�
    {
        //sqlConnect(); //����

        MySqlCommand dbcmd = new MySqlCommand(allcmd, sqlconn); //��ɾ Ŀ�ǵ忡 �Է�
        dbcmd.ExecuteNonQuery(); //��ɾ SQL�� ����

        //sqldisConnect(); //��������
    }

    public DataTable selsql(string sqlcmd)  //���� ������ DataTable�� ������
    {
        
        DataTable dt = new DataTable(); //������ ���̺��� ������

        //sqlConnect();
        MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcmd, sqlconn);
        adapter.Fill(dt); //������ ���̺�  ä���ֱ⸦��
        //sqldisConnect();

        return dt; //������ ���̺��� ������
    }
}
