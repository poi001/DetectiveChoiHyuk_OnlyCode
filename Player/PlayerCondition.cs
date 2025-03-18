using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour, IDamageable
{
    // ���ӿ�����Ʈ Player�� ĳ�̵� Ŭ����
    // �÷��̾ ���� ��ġ�� ����. �����
    // ui�� �ٿ� ����Ǿ��ִ� value�� ������ ����.


    [SerializeField] private ConditionMgr conditionMgr; // ����Ƽ �ν����Ϳ��� ���� ĳ���ؾ���

    public Condition health
    {
        get { return conditionMgr.Health; }
    }
    public Condition stamina
    {
        get { return conditionMgr.Stamina; }
    }

    private event Action onTakeDamage;  // �÷��̾ �������� ���� �ð�ȿ���� �����ϴ� �׼�. 



    public void TakeDamage(int damage)
    {
        health.MinusCurrent(damage);
        onTakeDamage?.Invoke();
    }
}
