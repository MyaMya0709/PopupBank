using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    GameManager gameManager;
    [Header("UserInfo")]
    public TMP_InputField TMP_ID;
    public TMP_InputField TMP_PW;
    public TMP_Text TMP_Name;
    public TMP_Text TMP_Balance;
    public TMP_Text TMP_Cash;

    [Header("UI")]
    public GameObject Buttons;
    public GameObject Deposit;
    public GameObject Withdraw;
    public GameObject ATM;
    public GameObject LoginMenu;

    [Header("Popup")]
    public GameObject ErrorPopup;
    public GameObject SignUpPopup;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        StartBank();
        Refresh();
    }

    //현재 유저데이터를 가져온다. 
    public void Refresh()
    {
        TMP_Name.text = gameManager.UserData.UserName;
        TMP_Balance.text = gameManager.UserData.BalanceMoney.ToString("N0");
        TMP_Cash.text = gameManager.UserData.Cash.ToString("N0");
    }

    //지정 입금 버튼
    public void InputCash(int cash)
    {

        if (gameManager.UserData.Cash >= cash)
        {
            gameManager.UserData.BalanceMoney += cash;
            gameManager.UserData.Cash -= cash;
            gameManager.SaveUserData(gameManager.UserData);
            Refresh();
        }
        else
        {
            OnErrorPopup();
        }
        
    }

    //입력 입금 버튼
    public void InputCustomCash(TMP_InputField InputCustom)
    {
        if (InputCustom.text != null && int.TryParse(InputCustom.text, out int result))
        {
            InputCash(result);
            InputCustom.text = null;
        }
        else
        {
            OnErrorPopup();
        }
    }

    //지정 출금 버튼
    public void OutputCash(int cash)
    {
        if (gameManager.UserData.BalanceMoney >= cash)
        {
            gameManager.UserData.BalanceMoney -= cash;
            gameManager.UserData.Cash += cash;
            gameManager.SaveUserData(gameManager.UserData);
            Refresh();
        }
        else
        {
            OnErrorPopup();
        }
    }

    //입력 출금 버튼
    public void OutputCustomCash(TMP_InputField OutputCustom)
    {
        if (OutputCustom.text != null && int.TryParse(OutputCustom.text, out int result))
        {
            OutputCash(result);
            OutputCustom.text = null;
        }
        else
        {
            OnErrorPopup();
        }
    }

    //시작시 로그인 메뉴
    public void StartBank()
    {
        LoginMenu.SetActive(true);
        ATM.SetActive(false);
        Buttons.SetActive(false);
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
        ErrorPopup.SetActive(false);
        SignUpPopup.SetActive(false);

    }

    //로그인 버튼
    public void OnLogin()
    {
        OnMainWindow();
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
        ATM.SetActive(true);
        Buttons.SetActive(true);
        LoginMenu.SetActive(false);
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
    }

    //금액 오류 팝업창 띄우고 내리기
    public void OnErrorPopup()
    {
        ErrorPopup.SetActive(!ErrorPopup.activeSelf);
    }

    //회원가입 팝업창 띄우고 내리기
    public void OnSignUpPopUp()
    {
        SignUpPopup.SetActive(!SignUpPopup.activeSelf);
    }

    //회원가입 하기
    public void SignUp()
    {
        gameManager.UserData.UserID = TMP_ID.text;
        gameManager.UserData.UserPW = TMP_PW.text;
        gameManager.SaveUserData(gameManager.UserData);
        OnSignUpPopUp();
    }
}
