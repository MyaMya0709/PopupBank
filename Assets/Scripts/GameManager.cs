using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    //게임메니저 싱글톤 인스턴스
    public static GameManager Instance { get; private set; }

    public UserData UserData { get; set; }

    // Start is called before the first frame update
    public void Awake()
    {
        //이미 인스턴스가 존재하면 파괴
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        //인스턴스가 없으면 현재 인스턴스 설정
        Instance = this;
        LoadUserData("chlehdgh96");

        if (UserData == null)
        {
            //userdata 인스턴스
            UserData = new UserData("chlehdgh96","0000","최동호", 50000, 100000);
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

        Debug.Log("데이터 저장 완료");
    }

    public void LoadUserData(string userID)
    {
        if (File.Exists(GeneratePath(userID)))
        {
            string Json_UserData = File.ReadAllText(GeneratePath(userID));
            UserData = JsonUtility.FromJson<UserData>(Json_UserData);
            Debug.Log($"불러온 데이터 - 이름: {UserData.UserName}, 통장잔액: {UserData.BalanceMoney}, 현금: {UserData.Cash}");
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
