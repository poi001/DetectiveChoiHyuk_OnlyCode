
using UnityEngine;

public class Mech : MonoBehaviour
{
    // Mech�� �÷��̾ �ٶ󺸰� �ϴ� �޼���.
    // Cockpit�� ĳ�̵ȴ�.
    public Player player;
    public bool isActive = false;

    private Quaternion defaultQuaternion;
    private bool isReturningToDefault = false;
    private float rotationSpeed = 1.0f; // ȸ�� �ӵ�


    private void Start()
    {
        player = CharacterManager.Instance.Player;
        defaultQuaternion = transform.rotation;
    }

    private void Update()
    {
        if(isActive)
        RotationCockpit();
        else if (isReturningToDefault)
        {
            ReturnToDefaultRotation();
        }
    }

    public void RotationCockpit()
    {        
        transform.LookAt(player.transform);
        transform.Rotate(0, 90, 0);
    }

    // �����̼� ������� �ǵ�����
    public void DefaultRotation()
    {
        isActive = false;
        isReturningToDefault = true;
        // �κ� ������ ȿ���� ���
    }
    private void ReturnToDefaultRotation()
    {
        // Slerp�� ����Ͽ� �ε巴�� ȸ��
        transform.rotation = Quaternion.Slerp(transform.rotation, defaultQuaternion, Time.deltaTime * rotationSpeed);

        // ȸ���� ���� �Ϸ�Ǹ� �÷��׸� ����
        if (Quaternion.Angle(transform.rotation, defaultQuaternion) < 0.1f)
        {
            transform.rotation = defaultQuaternion;
            isReturningToDefault = false;
        }
    }

    public void ToggleBoolisActive()
    {
        isActive = !isActive;
    }
}
