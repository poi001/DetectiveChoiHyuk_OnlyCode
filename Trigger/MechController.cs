using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechController : MonoBehaviour, IInteractable, INumPadable
{
    // Mech��Ʈ�ѷ��� ĳ�̵Ǵ� ��ũ��Ʈ.//
    [SerializeField] private NumPad MechPanelUI; // �ν����� ĳ��
    public Mech mech;
    public MechColor mechColor;

    public GameObject door;

    public string GetInteractPrompt()
    {
        string str = $"�κ� ��Ʈ�ѷ�";
        return str ;
    }

    public void OnInteract()
    {
        // UIȰ��ȭ, ���콺 Ȱ��ȭ
        MechPanelUI.gameObject.SetActive(true);
        CharacterManager.Instance.Player.controller.ToggleCursor();

        // ��Ʈ�ѷ��� ��ȣ�ۿ��ϸ� ������ NumPad UI�� �ڽ��� �ֱ�
        MechPanelUI.numPadable = this;
    }

    // ȿ���� �߻� ���� ��(���� ��ٸ���) UI �ݱ�
    // �κ��ൿ ���� ( ������ ����, �����̼� ������� ������)
    
    public void OnDone()
    {
        //mechColor.onBlinkEvent -= null;
        mechColor.StopBlinkColor();
        mech.DefaultRotation();
        MechPanelUI.CloseButton();
        // �κ������� �����ϸ� ���� ����.
        if(door.TryGetComponent<ILock>(out ILock lockedDoor))
        {
            lockedDoor.Unlock();
        }
    }

    public void OnFail()
    {
    }
}

public interface INumPadable
{
    public void OnDone();
    public void OnFail();
}