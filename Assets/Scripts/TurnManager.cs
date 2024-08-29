using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int currentTurn;
    private int totalTurns;

    public void InitializeTurns(int turns)
    {
        totalTurns = turns;
        currentTurn = 0;
    }

    public void NextTurn()
    {
        currentTurn++;
        if (currentTurn >= totalTurns)
        {
            EndTurns();
        }
    }

    public void ResetTurns()
    {
        currentTurn = 0;
    }

    private void EndTurns()
    {
        // Logic to handle end of turns
    }
}
