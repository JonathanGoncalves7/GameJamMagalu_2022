using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSprite : MonoBehaviour, IWalkable
{
    public bool unlock;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        unlock = false;
    }

    public void Unlock(Sprite asphaltSprite)
    {
        _spriteRenderer.sprite = asphaltSprite;
        unlock = true;
    }

    public bool CanWalk(GameObject _gameObject, EnumObjectType _type)
    {
        return unlock;
    }
}
