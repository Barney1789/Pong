using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Existing GameManager properties
    public static string baseURI = "http://localhost:3000";

    // Reference to the RoundDisplay script component
    public RoundDisplay roundDisplay;

    private int currentRound = 1; // Starting round

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // Initialize the round display at the start of the game
        UpdateRoundDisplay();
    }

    // Call this method to update the round display whenever a new round starts
    public void StartNewRound()
    {
        currentRound++; // Increment the round
        UpdateRoundDisplay(); // Update the display
    }

    // This method updates the round display with the current round number
    private void UpdateRoundDisplay()
    {
        if(roundDisplay != null)
        {
            roundDisplay.UpdateRound(currentRound);
        }
        else
        {
            Debug.LogError("RoundDisplay reference not set in the GameManager.");
        }
    }
}
