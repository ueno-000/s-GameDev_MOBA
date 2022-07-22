using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveAction
{
    AdvanceMove = 1,//�O�i
    Attack = 2,//�U��
    //Chase = 2,//�Ǐ]
    //RecessionMove = -1,//���

}
public class BaseMoveController : MonoBehaviour
{
    /// <summary>�ړ����x</summary>
    [SerializeField] protected float _speed = 5;

    /// <summary>HP</summary>
    protected int _helthPoint = 5;

    /// <summary>Action��Type</summary>
    [SerializeField] public MoveAction _ActionType = MoveAction.AdvanceMove;

    [SerializeField] protected GameObject _target; 
    
    void Start()
    {
        TargetSerch();

    }

    private void TargetSerch()
    {
        _target = GameObject.FindWithTag("BlueCore");
    }

    void Update()
    {
        ActionChange();
    }

    private void ActionChange()
    {
        switch (_ActionType)
        {
            case MoveAction.AdvanceMove:

                Vector3 _targetPos = _target.transform.position;
                //y���̓v���C���[�Ɠ����ɂ���
                _targetPos.y = transform.position.y;
                // �v���C���[�Ɍ�������
                transform.LookAt(_targetPos);

                //�I�u�W�F�N�g��O�����Ɉړ�����
                transform.position = transform.position + transform.forward * _speed * Time.deltaTime;

                break;
            case MoveAction.Attack:
                Debug.Log("�U��");
                break;
        }
    }
}
