using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWalkable
{
    public bool CanWalk(GameObject _gameObject, EnumObjectType _type);
}
