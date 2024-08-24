using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameOverManager gameOverManager;
    private int turnsLeft = 3; // Số lượt chơi còn lại

    void Update()
    {
        if (turnsLeft <= 0)
        {
            gameOverManager.ShowGameOverPopup();
        }
    }

    public void UseTurn()
    {
        turnsLeft--;
    }
}
