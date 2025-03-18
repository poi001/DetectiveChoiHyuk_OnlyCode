using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechColor : MonoBehaviour
{
    // Mech�� ���� �ٲٴ� ��ũ��Ʈ

    public MeshRenderer[] meshRenderers;

    public Color color1 = Color.white; // ù ��° ����
    public Color color2 = Color.red; // �� ��° ����
    public float transitionDuration = 1.0f; // ���� ��ȯ �ð�

    public event Action onBlinkEvent;

    public IEnumerator coroutine;

    public bool isActive;

    private void Start()
    {       
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        coroutine = BlinkMaterial();
        // �����
        onBlinkEvent += StartBlinkColor;

    }

    private void Update()
    {
        if(isActive)
        CallBlinkEvent();
    }

    private IEnumerator BlinkMaterial()
    {
        while (true)
        {
            yield return StartCoroutine(TransitionColor(color1, color2, transitionDuration));
            yield return StartCoroutine(TransitionColor(color2, color1, transitionDuration));
        }
    }
    public void StartBlinkColor()
    {
        StartCoroutine(coroutine);
    }
    public void StopBlinkColor()
    {

        StopAllCoroutines();   // �ڷ�ƾ ����
        StartCoroutine(TransitionColor(color2, color1, transitionDuration * 2));
        isActive = false;
    }

    private IEnumerator TransitionColor(Color fromColor, Color toColor, float _transitionDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < _transitionDuration)
        {
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].material.color = Color.Lerp(fromColor, toColor, elapsedTime / _transitionDuration);
                elapsedTime += Time.deltaTime;
                yield return null; // ���� �����ӱ��� ���
            }
        }
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = toColor; // ��Ȯ�� ���� ���� ����
        }
    }      

    private void CallBlinkEvent()
    {
        onBlinkEvent?.Invoke();
    }

    public void ToggleBoolisActive()
    {
        isActive = !isActive;
    }
}
