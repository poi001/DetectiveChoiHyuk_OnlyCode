using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject[] players;  // �÷��̾� ������Ʈ �迭
    public Transform[] spawnLocations;  // �� �÷��̾��� ���� ��ġ �迭

    private int currentPlayerIndex = 0;

    private Vector3[] initialPositions; // �� �÷��̾��� �ʱ� ��ġ �迭

    void Start()
    {
        // �ʱ� ��ġ ����
        initialPositions = new Vector3[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            initialPositions[i] = players[i].transform.position;
            players[i].SetActive(i == currentPlayerIndex);  // �ʱ⿡�� ù ��° �÷��̾ Ȱ��ȭ
        }
    }

    public void SwitchPlayer(int playerIndex)
    {
        // ���� Ȱ��ȭ�� �÷��̾� ��Ȱ��ȭ
        players[currentPlayerIndex].SetActive(false);

        // ���ο� �÷��̾� �ε����� ��ȯ
        currentPlayerIndex = playerIndex;

        // ���ο� �÷��̾ �ʱ� ���� ��ġ�� �̵���Ű�� Ȱ��ȭ
        players[currentPlayerIndex].transform.position = spawnLocations[currentPlayerIndex].position;
        players[currentPlayerIndex].SetActive(true);

        // Player_Modify�� ������ ������ �÷��̾��� ��ġ �ʱ�ȭ
        for (int i = 1; i < players.Length; i++) // Player_Modify�� 0��° �ε���
        {
            if (i != currentPlayerIndex)
            {
                players[i].transform.position = initialPositions[i];
            }
        }
    }
}



