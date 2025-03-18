using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour
{
    public TextMeshProUGUI tmp; //�ν����� ĳ��
    public INumPadable numPadable;
    public string correctNum;   // �� ���е��� �����ȣ

    public Button[] numButtons = new Button[12];    // 0~9 : ����, 10 : �����, 11 : �Ϸ�

    bool isActive = true;

    int remainTime = 3;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        numButtons = GetComponentsInChildren<Button>();
        for (int i = 0; i < 10; i++)
        {
            int index = i; // ĸó�� ����??
            numButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = index.ToString();
            numButtons[i].onClick.AddListener( () => BtnAppend(index) );    //�ν����Ϳ��� ��ư�Լ� �Ҵ��ϴ��� �ڵ�� �ϴ°�
        }
        //10
        numButtons[10].GetComponentInChildren<TextMeshProUGUI>().text = "Erase";
        numButtons[10].onClick.AddListener(ReActive);
        //11
        numButtons[11].GetComponentInChildren<TextMeshProUGUI>().text = "Enter";
        numButtons[11].onClick.AddListener(Done);
    }

    private void Update()
    {
        if (isActive && tmp.text.Length == 4)
        {
            isActive = false;
            for (int i = 0; i < 10; i++)
            {
                int index = i; // ĸó�� ����??
                numButtons[i].GetComponent<Image>().color = Color.gray;
                numButtons[i].enabled = false;
            }
        }

        if (remainTime == 0)
        {
            // UI���� �� �����̺�Ʈ ����
            // ī�޶� �κ��� �ָ�, �÷��̾� �Է� ��� �ȵ�, �κ� �� ���� ����, 2�� ����� �ѹ߻� ȿ����, ȭ�� ������, ���ӿ���
        }
    }

    public void BtnAppend(int i)
    {
        tmp.text += i.ToString();
    }


    // ����� �Ǵ� �Ϸ�� ��ư ��Ȱ��ȭ �� �ؽ�Ʈ �����
    void ReActive()
    {
        isActive = true;
        for (int i = 0; i < 10; i++)
        {
            int index = i; // ĸó�� ����??
            numButtons[i].GetComponent<Image>().color = Color.white;
            numButtons[i].enabled = true;
        }
        tmp.text = "";
    }

    // �Ϸ�� ����� ��
    void Done()
    {
        if(correctNum == tmp.text)
        {
            // ���� ȿ���� �߻�
            numPadable.OnDone();    // ����ȿ��
        }
        else
        {
            remainTime--;
            Debug.Log($"���������� ����Ƚ�� : {remainTime}");
        }
    }

    public void CloseButton()
    {
        ReActive();
        gameObject.SetActive(false);
        CharacterManager.Instance.Player.controller.ToggleCursor();
    }

}
