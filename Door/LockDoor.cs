using System.Collections;
using System.Collections.Generic;
using SojaExiles;
using UnityEngine;
using UnityEngine.InputSystem;



public class LockDoor : MonoBehaviour, IInteractable, ILock
{
    // �������� ���� ��װ� ������ ���� �� ��ũ��Ʈ�� ĳ���Ѵ�.

    public opencloseDoor door;
    public Animator animator;
    SojaExiles.opencloseDoor _opencloseDoor;
    AudioSource _audioSource;

    public bool isLock { get; protected set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
        door = GetComponent<opencloseDoor>();
        _opencloseDoor = GetComponent<SojaExiles.opencloseDoor>();
        _audioSource = GetComponent<AudioSource>();

        //���̾ ������ �����Ѵ�
        gameObject.layer = 9;
    }


    public void Lock()
    {
        if (isLock == true) return;
        isLock = true;
        if (door.open)
        {
            StartCoroutine(door.closing());
        }
        //door.Player = null;
    }

    public void Unlock()
    {
        if (isLock == false) return;
        door.Player = CharacterManager.Instance.Player.transform;
        isLock = false;
    }


    // ��� ���� ��ȣ�ۿ�� ���ٴ� ȿ������ �����Ⱦִϸ��̼� ���
    public void LockedDoorOpen()
    {
        Debug.Log("LockedDoorOpen");
        StartCoroutine(TryOpen());
        _audioSource.Play();
    }
    IEnumerator TryOpen()
    {
        print("you are trying open locked door");
        _opencloseDoor.openandclose.Play("TryOpen");
        yield return new WaitForSeconds(.5f);
        _opencloseDoor.openandclose.Play("Idle");
    }

    public string GetInteractPrompt()
    {
        if (isLock)
        {
            string str = $"�� ���� ����ִ�.";
            return str;
        }
        return "";
    }

    public void OnInteract()
    {
        //if(isLock) LockedDoorOpen();
    }
}
