using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionMgr : MonoBehaviour
{
    // ui�ν��� ���� ���ӿ�����Ʈ ü�°� ���¹̳ʿ��� ���� â���� �ϴ� Ŭ����
    // Condition�� ��������Value�� health, stamina�� �߻������� �����ؼ� ����ų �� �ְ� ��.

    private Condition _health;
    public Condition Health {  get { return _health; } set { _health = value; } }
    private Condition _stamina;
    public Condition Stamina { get {  return _stamina; } set {  _stamina = value; } }

    private void Awake()
    {
        _health = transform.GetChild(0).GetComponent<Condition>();
        _stamina = transform.GetChild(1).GetComponent<Condition>();
    }

    private void Start()
    {
        
    }

}
