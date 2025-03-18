using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData itemData;
    public ItemData equipItem;
    public Action addItem;
    public Action OnEquipItem;
    public Action OffEquipItem;

    public Transform dropPosition;
    public GameObject equipCamera;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;   //ĳ���͸Ŵ����� �÷��̾ �� �ڽ��� ����־��ش�
        controller = GetComponent<PlayerController>();  //��������Ʈ�� �÷��̾���Ʈ�ѷ��� ã�ƿͼ� ����־���
        condition = GetComponent<PlayerCondition>();
    }
}
