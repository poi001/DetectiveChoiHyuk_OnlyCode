using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanGetKey
{
    void CompletPuzzle();

}

public class GetKey : MonoBehaviour
{
    public GameObject prefab;   // ���� ������

    //private bool keyActive = false;

    public void CanGetKey()
    {
        Debug.Log("Ű ȹ��");
        prefab.SetActive(true);
    }
}
