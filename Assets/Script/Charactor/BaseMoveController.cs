using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveAction
{
    AdvanceMove = 1,//�O�i
    Attack = 2,//�U��
    //Chase = 2,//�Ǐ]
    RecessionMove = -1,//���
}
public enum PlayerColor
{
    Blue = 0,
    Red = 1
}
public class BaseMoveController : MonoBehaviour
{
    /// <summary>�ړ����x</summary>
    [SerializeField] protected float _speed = 5;

    /// <summary>Level</summary>
    protected int _level = 1;

    /// <summary>Action��Type</summary>
    [SerializeField] public MoveAction _actionType = MoveAction.AdvanceMove;
    /// <summary>Player��Type</summary>
    [SerializeField] public PlayerColor _playerType = PlayerColor.Blue;

    [SerializeField] protected GameObject[] _targets;

    private Vector3 _thisPos;
    private Vector3 _targetPos;

    private float _currentTargetDistance = 0f;

    void Start()
    {
        TargetSerch();
    }

    private void TargetSerch()
    {
        switch (_playerType)
        {
            case 0:
                _targets = GameObject.FindGameObjectsWithTag("Red");
                break;
            case (PlayerColor)1:
                _targets = GameObject.FindGameObjectsWithTag("Blue");
                break;
        }
        foreach (var obj in _targets)
        {
            _targetPos =  obj.transform.position;
        }
    }

    void Update()
    {
        ActionChange();
    }

    private void ActionChange()
    {
        switch (_actionType)
        {
            case MoveAction.AdvanceMove:

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

    private void FixedUpdate()
    {
        LookDistanse(2);
    }

    /// <summary>
    /// �^�[�Q�b�g�Ƃ̋������w�肵���l�ɒB������Action��ς���
    /// </summary>
    /// <param name="value"></param>
    private void LookDistanse(float value)
    {
        _thisPos = this.gameObject.transform.position;

        _currentTargetDistance = Mathf.Sqrt(Mathf.Pow(_thisPos.x - _targetPos.x, 2) + Mathf.Pow(_thisPos.z - _targetPos.z, 2));

        if (_currentTargetDistance <= value)
        {
            _actionType = MoveAction.Attack;
        }
        else
        {
            _actionType = MoveAction.AdvanceMove;
        }
    }

}
