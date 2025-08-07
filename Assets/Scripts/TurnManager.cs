using UnityEngine;

public class TurnManager : MonoBehaviour{
    public bool isPlayerTurn = true;
    public int turnCount = 0;

public void ForceTurn(bool playerTurn){
    isPlayerTurn = playerTurn;
    GameManager.Instance.uiManager.UpdateTurnDisplay(isPlayerTurn);
    Debug.Log("Forced turn: " + (isPlayerTurn ? "Player" : "Opponent"));
}

    public void EndTurn(){
        isPlayerTurn = !isPlayerTurn;
        GameManager.Instance.uiManager.UpdateTurnDisplay(isPlayerTurn);
    }

}