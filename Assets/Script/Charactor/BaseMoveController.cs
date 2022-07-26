using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveAction
{
    Idle = 0,//�Î~
    AdvanceMove = 1,//�O�i
    CoreAttack = 2,//�R�A�ɑ΂��Ă̍U��
    CaraAttack = 3,//�L�����N�^�[�ɑ΂��Ă̍U��
    Chase = 4,//�Ǐ]
    EvasionMove = -1,//���
    Return = -2//���_�ɖ߂�
}

public class BaseMoveController : MonoBehaviour
{
    /// <summary>�ړ����x</summary>
    [SerializeField] protected float _speed = 5;

    /// <summary>�U������</summary>
    [SerializeField] protected float _attackTransitionDistance = 2;


    /// <summary>Level</summary>
    protected int _level = 1;

    /// <summary>Action��Type</summary>
    [SerializeField] public MoveAction _actionType = MoveAction.AdvanceMove;

 
    private Vector3 _targetPos;

    private Vector3 _thisPos;

    private float _currentTargetDistance = 0f;

    private bool _isMoving = false;

    void Start()
    {
        StartCoroutine(MoveStart(5));
        _targetPos = GetComponent<TargetSerchScript>()._target.transform.position;
        _actionType = MoveAction.AdvanceMove;
    }

    void  Update()
    {
        if(_isMoving)
            ActionChange();
    }

    /// <summary>
    /// Acrion�̐ؑ�
    /// </summary>
    protected virtual void ActionChange()
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
            case MoveAction.CoreAttack:
                Debug.Log("�U��");
               
                break;
        }
    }

    protected virtual void FixedUpdate()
    {
        LookDistanse(2);
    }

    /// <summary>
    /// �R�A�Ƃ̋������w�肵���l�ɒB������Action��ς���
    /// </summary>
    /// <param name="value"></param>
    protected virtual void LookDistanse(float value)
    {
        _thisPos = this.gameObject.transform.position;

        _currentTargetDistance = Mathf.Sqrt(Mathf.Pow(_thisPos.x - _targetPos.x, 2) + Mathf.Pow(_thisPos.z - _targetPos.z, 2));

        if (_currentTargetDistance <= _attackTransitionDistance)
        {
            _actionType = MoveAction.CoreAttack;
        }
        else
        {
            _actionType = MoveAction.AdvanceMove;
        }
    }

    /// <summary>
    /// Game�J�n�܂ł̏���
    /// </summary>
    /// <param name="second">�b���w��</param>
    /// <returns></returns>
    protected IEnumerator MoveStart(float second)
    {
        Debug.Log("�ҋ@�^�[��");
        _isMoving = false;
        yield return new WaitForSeconds(second);
        Debug.Log("�s���J�n");
        _isMoving = true;
        yield break;
    }
}
