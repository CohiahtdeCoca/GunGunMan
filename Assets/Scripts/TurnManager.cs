using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public int totalTurns = 5;
    private int currentTurn;
    public Image[] turnIcons; // Array of UI Images representing turns

    void Start()
    {
        currentTurn = totalTurns;
        UpdateTurnIcons();
    }

    public void UseTurn()
    {
        if (currentTurn > 0)
        {
            currentTurn--;
            UpdateTurnIcons();

            if (currentTurn == 0)
            {
                GameOver();
            }
        }
    }

    public void ResetTurns()
    {
        currentTurn = totalTurns;
        UpdateTurnIcons();
    }

    void UpdateTurnIcons()
    {
        for (int i = 0; i < turnIcons.Length; i++)
        {
            if (i < currentTurn)
            {
                turnIcons[i].color = Color.white; // Active turn
            }
            else
            {
                turnIcons[i].color = Color.gray; // Used turn
            }
        }
    }

    void GameOver()
    {
        // Show fail popup
        // FindObjectOfType<UIManager>().ShowFailPopup();
    }
}
