using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //userdata 인스턴스
        UserData = new UserData("최동호", 50000, 100000);
    }
    public void Start()
    {

    }
}
