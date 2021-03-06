using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentIA : MonoBehaviour
{
    public EnumObjectType type;

    public int money;

    public GameObject Points;
    public float speedMin;
    public float speedMax;

    public float rayCastDistance = .5f;

    private List<Transform> pointsList = new List<Transform>();
    private int index;

    private BoxCollider2D _boxCollider;

    private float speedSelected;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();

        speedSelected = UnityEngine.Random.Range(speedMin, speedMax);

        pointsList.Clear();
        for (var i = 0; i < Points.transform.childCount; i++)
        {
            pointsList.Add(Points.transform.GetChild(i));
        }

        index = 0;
    }

    private void Update()
    {
        if (!AgentCanMove()) return;

        MoveAgent();
    }
    private bool AgentCanMove()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, GetDirection(), rayCastDistance);
        Debug.DrawRay(transform.position, GetDirection() * rayCastDistance);

        foreach (RaycastHit2D item in hits)
        {
            IWalkable walkable;
            item.transform.TryGetComponent<IWalkable>(out walkable);

            if (walkable != null)
            {
                if (!walkable.CanWalk(gameObject, type))
                    return false;
            }
            else
            {
                switch (type)
                {
                    case EnumObjectType.Car:
                        if (item.transform.CompareTag("Human"))
                        {
                            return false;
                        }
                        break;
                    case EnumObjectType.Person:
                        if (item.transform.CompareTag("Car"))
                        {
                            return false;
                        }
                        break;
                }
            }
        }

        return true;
    }

    private void MoveAgent()
    {
        if (Vector2.Distance(transform.position, pointsList[index].position) < 0.1f)
        {
            index++;

            if (index == Points.transform.childCount)
            {
                GameManager.s_instance.IncMoney(money);
                Destroy(gameObject);
                return;
            }
        }

        transform.Translate(GetDirection() * speedSelected * Time.deltaTime);
    }

    private Vector3 GetDirection()
    {

        if (index == Points.transform.childCount)
            return Vector2.zero;
        else
        {
            Vector3 direction = pointsList[index].position - transform.position;
            return direction.normalized;
        }


    }
}
