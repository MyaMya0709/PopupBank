using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //userdata �ν��Ͻ�
        UserData = new UserData("�ֵ�ȣ", 50000, 100000);
    }
    public void Start()
    {

    }
}
