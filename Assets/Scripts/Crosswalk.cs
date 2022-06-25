using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosswalk : MonoBehaviour, IWalkable
{
    public EnumObjectType curentType = EnumObjectType.Human;

    public float timeToEachType = 3f;

    private float _restTimeToEachType;

    private void Start()
    {
        _restTimeToEachType = 0;
    }

    private void Update()
    {
        _restTimeToEachType += Time.deltaTime;

        if (_restTimeToEachType > timeToEachType)
        {
            _restTimeToEachType = 0;

            ChangeType();
        }
    }

    private void ChangeType()
    {
        switch (curentType)
        {
            case EnumObjectType.Car:
                curentType = EnumObjectType.Human;
                break;
            default:
                curentType = EnumObjectType.Car;
                break;
        }
    }

    public bool CanWalk(GameObject _gameObject, EnumObjectType _type)
    {
        return _type == curentType;
    }
}
