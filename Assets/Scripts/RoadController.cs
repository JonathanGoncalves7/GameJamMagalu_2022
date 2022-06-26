using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public int cost = 10;

    public Sprite road;
    public Sprite mud;

    public List<GameObject> road1;
    public List<GameObject> road2;
    public List<GameObject> road3;
    public List<GameObject> road4;

    private bool mouseOver;

    private void Start()
    {
        LockRoad();
    }

    private void LockRoad()
    {
        // ChangeAllSpriteChilds(mud);
    }

    public void UnlockRoad(GameObject _gameObject)
    {
        GameManager.s_instance.DecMoney(cost);

        foreach (var item in road1)
        {
            if (item == _gameObject)
            {
                ChangeAllSpriteChilds(road1, road);
                return;
            }
        }

        foreach (var item in road2)
        {
            if (item == _gameObject)
            {
                ChangeAllSpriteChilds(road2, road);
                return;
            }
        }

        foreach (var item in road3)
        {
            if (item == _gameObject)
            {
                ChangeAllSpriteChilds(road3, road);
                return;
            }
        }

        foreach (var item in road4)
        {
            if (item == _gameObject)
            {
                ChangeAllSpriteChilds(road4, road);
                return;
            }
        }
    }

    public void ChangeAllSpriteChilds(List<GameObject> roadList, Sprite newSprite)
    {
        foreach (var road in roadList)
        {
            road.GetComponent<RoadSprite>().Unlock(newSprite);
        }
    }
}
