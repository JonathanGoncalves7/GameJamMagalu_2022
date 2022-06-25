using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSprite : MonoBehaviour, IWalkable
{
    public bool CanWalk(GameObject _gameObject, EnumObjectType _type)
    {
        return GetComponentInParent<RoadController>().unlockedRoad;
    }
}
