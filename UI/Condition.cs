using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    // UI�ν��� ����ǹ��� ����ؾ��� ���������� �ް� ����� ������ Ŭ����.
    // Health, Hunger, Stamina �� �ٿ� ĳ�̵Ǵ� Ŭ���� ��ũ��Ʈ.
    // �÷��̾�� Condition�� �����ϴ°� PlayerConditionŬ�������� ��.

    // Hunger�� ����ó�� ���¹̳��� �ִ�ġ�� ��������.

    // �� ������� ���� �Ӽ���. playerCondition�� ��������� ��� private�ϱ�
    private float curValue;      // ���� ��ġ
    public float CurValue { get { return curValue; } set { curValue = value; } }
    [SerializeField] private float startValue;    // �ʱⰪ
    public float StartValue { get { return startValue; } set { startValue = value; } }
    private float maxValue = 100f;      // �ִ� ��ġ
    public float MaxValue { get { return maxValue; } set { maxValue = value; } }
    private float limitHighValue = 250f;
    private float curScale;
    private float limitLowValue = 30f;
    public float passiveValue;  // �ð��� ������ ���� ������ ��ġ
    [SerializeField] private Image maxUIBar;      // �ִ�ü�¹�
    [SerializeField] private Image curUIBar;      // ü�¹ٳ� ���¹̳���

    private void Awake()
    {
        maxUIBar = GetComponent<Image>();
        curUIBar = transform.GetChild(0).GetComponent<Image>();
    }

    private void Start()
    {
        curValue = startValue;
    }

    private void LateUpdate()
    {
        curUIBar.fillAmount = GetPercentage();
    }

    // Image Fill Amount�� ����� 0 ~ 1 ��. �� ������ Ȯ���Ѵ�.
    private float GetPercentage()
    {
        return curValue / maxValue;
    }


    // ����� ��ġ ��ȭ���� ȣ��� �Լ�
    public void PlusCurrent(float value)
    {
        // curValue + value�� MaxValue�� �ʰ��Ѵٸ� �� ���� Min���� MaxValue�� ����ɰ�.
        curValue = Mathf.Min(curValue + value, maxValue); 
    }
    public void MinusCurrent(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);  // �� ���� ū ���� ��ȯ.
    }

    // �ִ��ġ�� �ö� ���
    public void PlusMax(float value)
    {
        maxValue = Mathf.Min(maxValue + value, limitHighValue);
        ConditionScale();
    }    
    public void MinusMax(float value)
    {
        maxValue = Mathf.Max(maxValue - value, limitLowValue);  // �� ���� ū ���� ��ȯ.
        ConditionScale();
    }

    // MaxValue�� ���ϸ� ����� �Լ�
    private void ConditionScale()
    {
        curScale = maxUIBar.transform.localScale.x;
        curScale *= maxValue * 0.01f;
    }
}
