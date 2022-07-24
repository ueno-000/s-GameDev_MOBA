using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColor
{
    Blue = 0,
    Red = 1
}
//public enum SerchCoreType
//{
    
//}
public class TargetSerchScript : MonoBehaviour
{
    [SerializeField] protected GameObject[] _targets;

    /// <summary>Player��Type</summary>
    [SerializeField] public PlayerColor _playerType = PlayerColor.Blue;
    
    /// <summary>�R�A�̃^�O</summary>
    private string[] _coreTag = {"BlueSubCore","RedSubCore", "BlueMainCore", "RedMainCore" };

    /// <summary>�����w�n�T�u�R�A�̔z��</summary>
    [SerializeField] private GameObject[] _alliesSubCores;

    /// <summary>�G�w�n�T�u�R�A�̔z��</summary>
    [SerializeField] private GameObject[] _enemySubCores;

    void Start()
    {
        TargetSerch();

        //�����̃T�u�R�A��z��Ɋi�[����
        _alliesSubCores = GameObject.FindGameObjectsWithTag(_coreTag[0]);
        //�G�̃T�u�R�A��z��Ɋi�[����
        _alliesSubCores = GameObject.FindGameObjectsWithTag(_coreTag[1]);
    }

    // Update is called once per frame
    void Update()
    {
        var isBreakSubCore = false;
        if (isBreakSubCore)
        {
            
        }
    }

    private void TargetSerch()
    {
        switch (_playerType)
        {
            case 0://Blue
                //�����̃T�u�R�A��z��Ɋi�[����
                _alliesSubCores = GameObject.FindGameObjectsWithTag(_coreTag[0]);//Blue
                //�G�̃T�u�R�A��z��Ɋi�[����
                _alliesSubCores = GameObject.FindGameObjectsWithTag(_coreTag[1]);//Red
                break;
            case (PlayerColor)1://Red
                //�����̃T�u�R�A��z��Ɋi�[����
                _alliesSubCores = GameObject.FindGameObjectsWithTag(_coreTag[1]);//Red
                //�G�̃T�u�R�A��z��Ɋi�[����
                _alliesSubCores = GameObject.FindGameObjectsWithTag(_coreTag[0]);//Blue
                break;
        }
        //foreach (var obj in _targets)
        //{
        //    _targetPos = obj.transform.position;
        //}
    }

}
