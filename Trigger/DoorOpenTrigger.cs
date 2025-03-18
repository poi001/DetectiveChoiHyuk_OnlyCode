using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour, IInteractable, ITrigger
{
    // ���� ������ Ʈ���Ű� �۵��Ѵ�.
    public MechController mechController;   // �ν�����ĳ��
    SojaExiles.opencloseDoor _opencloseDoor;

    private bool isTrigger = false;

    private void Start()
    {
        _opencloseDoor = GetComponent<SojaExiles.opencloseDoor>();
    }

    private void Update()
    {
        if(_opencloseDoor.open && !isTrigger)
        {
            Execute();
            isTrigger = true;
        }
    }
    public void Execute()
    {
        mechController.mech.ToggleBoolisActive();
        mechController.mechColor.ToggleBoolisActive();
    }


    public void TriggerOn()
    {
        throw new System.NotImplementedException();
    }
    public string GetInteractPrompt()
    {
        string str = $"ħ��";
        return str;
    }

    public void OnInteract()
    {
        Execute();
    }
}
