using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    GameManager gameManager;
    public TMP_Text TMP_Name;
    public TMP_Text TMP_Balance;
    public TMP_Text TMP_Cash;
    public GameObject Buttons;
    public GameObject Deposit;
    public GameObject Withdraw;
    public GameObject ErrorPopup;
    public TMP_Text InputComstom;
    public TMP_Text OutputComstom;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        Refresh();
    }
    //현재 유저데이터를 가져온다. 
    public void Refresh()
    {
        TMP_Name.text = gameManager.UserData.UserName;
        TMP_Balance.text = gameManager.UserData.BalanceMoney.ToString("N0");
        TMP_Cash.text = gameManager.UserData.Cash.ToString("N0");
    }

    public void InputCash(int cash)
    {

        if (gameManager.UserData.Cash >= cash)
        {
            gameManager.UserData.BalanceMoney += cash;
            gameManager.UserData.Cash -= cash;
            Refresh();
        }
        else if (InputComstom != null && int.TryParse(InputComstom.text))
        {
            cash = int.TryParse(InputComstom.text);
        }
        else
        {
            OnPopup();
        }
        
    }

    public void OutputCash(int cash)
    {
        if (gameManager.UserData.BalanceMoney >= cash)
        {
            gameManager.UserData.BalanceMoney -= cash;
            gameManager.UserData.Cash += cash;
            Refresh();
        }
        else
        {
            OnPopup();
        }
    }

    //입금창 버튼
    public void OninputWindow()
    {
        Buttons.SetActive(false);
        Deposit.SetActive(true);
    }

    //출금창 버튼
    public void OnOutputWindow()
    {
        Buttons.SetActive(false);
        Withdraw.SetActive(true);
    }

    //메인창 버튼
    public void OnMainWindow()
    {
        Buttons.SetActive(true);
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
    }

    //팝업창 띄우고 내리기
    public void OnPopup()
    {
        ErrorPopup.SetActive(!ErrorPopup.activeSelf);
    }

}
