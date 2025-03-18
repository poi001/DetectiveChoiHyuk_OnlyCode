using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

// 이거 어디에 부착..? -> 테이블
// 아니면 부착하지 않게 수정

public class Four_Duck : MonoBehaviour, ICanGetKey
{
    public GetKey getKey { get; private set; }

    // 식탁 위의 오리 오브젝트
    public GameObject tableDuckFront;
    public GameObject tableDuckBack;
    public GameObject tableDuckLeft;
    public GameObject tableDuckRight;

    // 활성화 상태
    private bool frontActive = false;
    private bool backActive = true;
    private bool leftActive = true;
    private bool rightActive = true;

    // 현재 들고 있는 아이템
    // TODO : 캐릭터 관련 스크립트로 옮기기
    public GameObject curItem;

    private void Start()
    {
        getKey = GetComponent<GetKey>();
    }

    void Update()   // 클릭 감지
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

    // 클릭한 오브젝트와 놓인 오브젝트, 들고 있는 오브젝트 비교해서 모두 동일하면 해당 오브젝트 가시화
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

    private bool ActivateObject(GameObject obj, bool isActive)  // 가시화 실제 수행 코드
    {
        Debug.Log("ActivateObject() 호출");
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            Debug.Log("mesh renderer 있음");
            meshRenderer.enabled = true;
            CompletPuzzle();
            return true;
        }
        return isActive;
    }

    public void CompletPuzzle() // 퍼즐 완성 조건 확인
    {
        Debug.Log("퍼즐 해결 조건 확인");
        
        //bool frontActive = CheckRendererEnable(tableDuckFront);
        //bool backActive = CheckRendererEnable(tableDuckBack);
        //bool leftActive = CheckRendererEnable(tableDuckLeft);
        //bool rightActive = CheckRendererEnable(tableDuckRight);

        if (frontActive && backActive && leftActive && rightActive)
        {
            Debug.Log("키 획득 조건 달성");
            getKey.CanGetKey();    // 열쇠 획득
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
    //    // 들고 있는 오브젝트와 놓인 오브젝트가 같다면 활성화 및 true 반환
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
