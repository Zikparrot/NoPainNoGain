using UnityEngine;

public class AttackAction : MonoBehaviour
{
    public int baseCost = 5;
    public bool isPlayer = true;

    public void Execute()
    {
        GameManager.Instance.ExecuteAction(isPlayer, baseCost);
        Debug.Log("Mods, crush his skull.");
    }
}