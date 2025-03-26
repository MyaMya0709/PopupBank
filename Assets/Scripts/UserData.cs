using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class UserData
{
    public string UserID;
    public string UserPW;
    public string UserName;
    public int BalanceMoney;
    public int Cash;

    public UserData(string ID, string PW, string name, int balance, int cash)
    {
        UserID = ID;
        UserPW = PW;
        UserName = name;
        BalanceMoney = balance;
        Cash = cash;
    }
}
