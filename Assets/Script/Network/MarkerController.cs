using UnityEngine;

/// <summary>
/// �N���b�N�� Ray ���΂��āARay �� Scene �E�B���h�E�ɕ\������R���|�[�l���g
/// �K���� GameObject �ɒǉ����Ďg��
/// </summary>
public class MarkerController : MonoBehaviour
{
    // [SerializeField] Camera _mapCamera;
    /// <summary>Ray �����ɂ�������Ȃ��������AScene �ɕ\������ Ray �̒���</summary>
    [SerializeField] float _debugRayLength = 100f;
    /// <summary>Ray �������ɓ����������� Scene �ɕ\������ Ray �̐F</summary>
    [SerializeField] Color _debugRayColorOnHit = Color.red;
    /// <summary>������ GameObject ��ݒ肷��ƁA��΂��� Ray �������ɓ����������ɂ����� m_marker �I�u�W�F�N�g���ړ�����</summary>
    [SerializeField] public GameObject _marker;
    /// <summary>��΂��� Ray �������������W�� m_marker ���ړ�����ہARay �������������W����ǂꂭ�炢���炵���ꏊ�Ɉړ����邩��ݒ肷��</summary>
    [SerializeField] Vector3 _markerOffset = Vector3.up * 0.01f;

   // Animator _anim;

    private void Start()
    {
    //    _anim = GetComponent<Animator>();
    }
    void Update()
    {
        // �N���b�N�� Ray ���΂�
        if (Input.GetButtonDown("Fire2"))
        {
          //  _anim.SetTrigger("ClickTrigger");

            // �J�����̈ʒu �� �}�E�X�ŃN���b�N�����ꏊ�� Ray ���΂��悤�ɐݒ肷��
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Ray �������������ǂ����ňقȂ鏈��������iPhysics.Raycast() �ɂ͂�������I�[�o�[���[�h������̂Œ��ӂ��邱�Ɓj
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Ray �������������́A�����������W�܂ŐԂ���������
                Debug.DrawLine(ray.origin, hit.point, _debugRayColorOnHit);
                // _marker ���A�T�C������Ă�����A������ړ�����
                if (_marker)
                {
                    _marker.transform.position = hit.point + _markerOffset;
                }
            }
            else
            {
                // Ray ��������Ȃ������ꍇ�́ARay �̕����ɔ�����������
                Debug.DrawRay(ray.origin, ray.direction * _debugRayLength);
            }
        }
    }


}


