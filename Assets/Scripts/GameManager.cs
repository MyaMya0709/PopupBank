using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    //���Ӹ޴��� �̱��� �ν��Ͻ�
    public static GameManager Instance { get; private set; }

    public UserData UserData { get; set; }

    // Start is called before the first frame update
    public void Awake()
    {
        //�̹� �ν��Ͻ��� �����ϸ� �ı�
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        //�ν��Ͻ��� ������ ���� �ν��Ͻ� ����
        Instance = this;
        LoadUserData("chlehdgh96");

        if (UserData == null)
        {
            //userdata �ν��Ͻ�
            UserData = new UserData("chlehdgh96","0000","�ֵ�ȣ", 50000, 100000);
            SaveUserData(UserData);
        }
    }
    public void Start()
    {
        
    }

    private string GeneratePath(string userID)
    {
        //return Application.persistentDataPath + "/" + userName + ".json";
        return Application.dataPath + "/" + userID + ".json";
    }

    public void SaveUserData(UserData userData)
    {
        string Json_UserData = JsonUtility.ToJson(userData);
        File.WriteAllText(GeneratePath(userData.UserID), Json_UserData);

        //PlayerPrefs.SetString("UserName", userData.UserName);
        //PlayerPrefs.SetInt("BalanceMoney", userData.BalanceMoney);
        //PlayerPrefs.SetInt("Cash", userData.Cash);
        //PlayerPrefs.Save();

        Debug.Log("������ ���� �Ϸ�");
    }

    public void LoadUserData(string userID)
    {
        if (File.Exists(GeneratePath(userID)))
        {
            string Json_UserData = File.ReadAllText(GeneratePath(userID));
            UserData = JsonUtility.FromJson<UserData>(Json_UserData);
            Debug.Log($"�ҷ��� ������ - �̸�: {UserData.UserName}, �����ܾ�: {UserData.BalanceMoney}, ����: {UserData.Cash}");
        }
        else
        {
            UserData = null;
        }
        //string LoadName = PlayerPrefs.GetString("UserName");
        //int LoadBalance = PlayerPrefs.GetInt("BalanceMoney");
        //int LoadCash = PlayerPrefs.GetInt("Cash");
    }
}
