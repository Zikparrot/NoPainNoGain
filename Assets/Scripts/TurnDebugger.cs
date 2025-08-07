using UnityEngine;

public class TurnDebugger : MonoBehaviour
{
    public void ForcePlayerTurn(){
        GameManager.Instance.turnManager.ForceTurn(true);
    }

    public void ForceOpponentTurn(){
        GameManager.Instance.turnManager.ForceTurn(false);
    }
}