using UnityEngine;

public class RoadController : MonoBehaviour
{
    public int cost = 10;

    public Sprite road;
    public Sprite mud;

    public bool unlockedRoad;

    private bool mouseOver;

    private void Start()
    {
        LockRoad();
    }

    private void LockRoad()
    {
        unlockedRoad = false;

        ChangeAllSpriteChilds(mud);
    }

    public void UnlockRoad()
    {
        GameManager.s_instance.DecMoney(cost);

        unlockedRoad = true;

        ChangeAllSpriteChilds(road);
    }

    public void ChangeAllSpriteChilds(Sprite newSprite)
    {
        foreach (var spriteRenderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
