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
    public TMP_InputField InputCustom;
    public TMP_InputField OutputCustom;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        Refresh();
    }
    //���� ���������͸� �����´�. 
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
        else
        {
            OnPopup();
        }
        
    }

    public void InputCustomCash()
    {
        if (InputCustom.text != null && int.TryParse(InputCustom.text, out int result))
        {
            InputCash(result);
            InputCustom.text = null;
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

    public void OutputCustomCash()
    {
        if (OutputCustom.text != null && int.TryParse(OutputCustom.text, out int result))
        {
            OutputCash(result);
            OutputCustom.text = null;
        }
        else
        {
            OnPopup();
        }
    }

    //�Ա�â ��ư
    public void OninputWindow()
    {
        Buttons.SetActive(false);
        Deposit.SetActive(true);
    }

    //���â ��ư
    public void OnOutputWindow()
    {
        Buttons.SetActive(false);
        Withdraw.SetActive(true);
    }

    //����â ��ư
    public void OnMainWindow()
    {
        Buttons.SetActive(true);
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
    }

    //�˾�â ���� ������
    public void OnPopup()
    {
        ErrorPopup.SetActive(!ErrorPopup.activeSelf);
    }

}
