using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public PlayerSwitcher playerSwitcher;
    public int playerIndex;  // ��ȯ�� �÷��̾� �ε���

    void OnMouseDown()
    {
        playerSwitcher.SwitchPlayer(playerIndex);
    }
}



