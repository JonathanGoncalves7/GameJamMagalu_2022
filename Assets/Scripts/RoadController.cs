using UnityEngine;

public class RoadController : MonoBehaviour
{
    public int cost = 10;

    public GameObject road;
    public GameObject mud;

    public bool unlockedRoad;

    private bool mouseOver;

    private void Start()
    {
        LockRoad();
    }

    private void LockRoad()
    {
        unlockedRoad = false;

        road.SetActive(false);
        mud.SetActive(true);
    }

    public void UnlockRoad()
    {
        GameManager.s_instance.DecMoney(cost);

        unlockedRoad = true;

        road.SetActive(true);
        mud.SetActive(false);
    }
}
