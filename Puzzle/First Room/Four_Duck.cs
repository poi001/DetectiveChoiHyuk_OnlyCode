using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

// �̰� ��� ����..? -> ���̺�
// �ƴϸ� �������� �ʰ� ����

public class Four_Duck : MonoBehaviour, ICanGetKey
{
    public GetKey getKey { get; private set; }

    // ��Ź ���� ���� ������Ʈ
    public GameObject tableDuckFront;
    public GameObject tableDuckBack;
    public GameObject tableDuckLeft;
    public GameObject tableDuckRight;

    // Ȱ��ȭ ����
    private bool frontActive = false;
    private bool backActive = true;
    private bool leftActive = true;
    private bool rightActive = true;

    // ���� ��� �ִ� ������
    // TODO : ĳ���� ���� ��ũ��Ʈ�� �ű��
    public GameObject curItem;

    private void Start()
    {
        getKey = GetComponent<GetKey>();
    }

    void Update()   // Ŭ�� ����
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = CharacterManager.Instance.Player.controller.maincamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5.0f))
            {
                Debug.Log($"{hit.collider.gameObject.name}");
                CheckAndActive(hit.collider.gameObject);
            }
        }
    }

    //private bool MeshRendererCheck(GameObject gameObject)
    //{
    //    MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
    //}

    // Ŭ���� ������Ʈ�� ���� ������Ʈ, ��� �ִ� ������Ʈ ���ؼ� ��� �����ϸ� �ش� ������Ʈ ����ȭ
    private void CheckAndActive(GameObject hitObject)
    {
        if (hitObject.name == curItem.name)
        {
            Debug.Log("hitObject.name == curItem.name");    
            if (hitObject.name == tableDuckFront.name)    
            {
                Debug.Log("hitObject == tableDuckFront");
                frontActive = ActivateObject(tableDuckFront, frontActive);
                
            }
            else if (hitObject == tableDuckBack)
            {
                backActive = ActivateObject(tableDuckBack, backActive);
            }
            else if (hitObject == tableDuckLeft)
            {
                leftActive = ActivateObject(tableDuckLeft, leftActive);
            }
            else if (hitObject == tableDuckRight)
            {
                rightActive = ActivateObject(tableDuckRight, rightActive);
            }
        }
    }

    private bool ActivateObject(GameObject obj, bool isActive)  // ����ȭ ���� ���� �ڵ�
    {
        Debug.Log("ActivateObject() ȣ��");
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            Debug.Log("mesh renderer ����");
            meshRenderer.enabled = true;
            CompletPuzzle();
            return true;
        }
        return isActive;
    }

    public void CompletPuzzle() // ���� �ϼ� ���� Ȯ��
    {
        Debug.Log("���� �ذ� ���� Ȯ��");
        
        //bool frontActive = CheckRendererEnable(tableDuckFront);
        //bool backActive = CheckRendererEnable(tableDuckBack);
        //bool leftActive = CheckRendererEnable(tableDuckLeft);
        //bool rightActive = CheckRendererEnable(tableDuckRight);

        if (frontActive && backActive && leftActive && rightActive)
        {
            Debug.Log("Ű ȹ�� ���� �޼�");
            getKey.CanGetKey();    // ���� ȹ��
        }
    }

    private bool CheckRendererEnable(GameObject obj)
    {
        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        return renderer != null && renderer.enabled;
    }


    //private void CheckAndActive1(GameObject hitObject)
    //{
    //    if (hitObject.name == curItem.name)
    //    {
    //        MeshRenderer meshRenderer;

    //        if (hitObject.name == "Duck_Front")
    //        {
    //            meshRenderer = tableDuckFront.GetComponent<MeshRenderer>();
    //            if (meshRenderer != null )
    //            {
    //                meshRenderer.enabled = true;
    //            }
    //            CompletPuzzle();
    //        }
    //        else if (hitObject.name == "Duck_Back")
    //        {
    //            tableDuckBack.SetActive(true);
    //            CompletPuzzle();
    //        }
    //        else if (hitObject.name == "Duck_Left")
    //        {
    //            tableDuckLeft.SetActive(true);
    //            CompletPuzzle();
    //        }
    //        else if (hitObject.name == "Duck_Right")
    //        {
    //            tableDuckRight.SetActive(true);
    //            CompletPuzzle();
    //        }
    //    }
    //}


    //public bool objectEqual()
    //{
    //    // ��� �ִ� ������Ʈ�� ���� ������Ʈ�� ���ٸ� Ȱ��ȭ �� true ��ȯ
    //    // curItem.name = objectName;
        
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = CharacterManager.Instance.Player.controller.maincamera.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit, 5.0f))
    //        {
    //            if (hit.collider.gameObject.name == curItem.name && hit.collider.gameObject.CompareTag("PuzzleObject"))
    //            {
    //                Debug.Log($"{hit.collider.gameObject.name}");
    //                directionCheck(curItem.name);
    //                return true;
    //            }
    //        }
    //    }
    //    return false;
    //}

    //private bool directionCheck(string objectName)
    //{
        
        
    //    if (objectEqual())
    //    {
    //        if (objectName == "Duck_Front")
    //        {
    //            tableDuckFront.SetActive(true);
    //            return true;
    //        }
    //        else if (objectName == "Duck_Back")
    //        {
    //            tableDuckBack.SetActive(true);
    //            return true;
    //        }
    //        else if (objectName == "Duck_Left")
    //        {
    //            tableDuckLeft.SetActive(true);
    //            return true;
    //        }
    //        else if (objectName == "Duck_Right")
    //        {
    //            tableDuckRight.SetActive(true);
    //            return true;
    //        }
    //    }
    //    return false;



    //}

    //public bool frontEqual()
    //{
    //    if (objectEqual("Duck_Front"))
    //    {
    //        tableDuckFront.SetActive(true);
    //        return true;
    //    }
    //    return false;
    //}

    //public bool backEqual()
    //{
    //    if (objectEqual("Duck_Back"))
    //    {
    //        tableDuckBack.SetActive(true);
    //        return true;
    //    }
    //    return false;
    //}

    //public bool leftEqual()
    //{
    //    if (objectEqual("Duck_Left"))
    //    {
    //        tableDuckLeft.SetActive(true); 
    //        return true;
    //    }
    //    return false;
    //}

    //public bool rightEqual()
    //{
    //    if (objectEqual("Duck_Right"))
    //    {
    //        tableDuckRight.SetActive(true); 
    //        return true;
    //    }
    //    return false;
    //}
}
