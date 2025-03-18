using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanGetKey
{
    void CompletPuzzle();

}

public class GetKey : MonoBehaviour
{
    public GameObject prefab;   // ¿­¼è ÇÁ¸®ÆÕ

    //private bool keyActive = false;

    public void CanGetKey()
    {
        Debug.Log("Å° È¹µæ");
        prefab.SetActive(true);
    }
}
