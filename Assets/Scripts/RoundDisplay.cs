using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class RoundDisplay : MonoBehaviour
{
    public TMP_Text roundText; // The text component where the round will be displayed
    private int currentRound = 1; // Starting round

    // Call this method to update the round display whenever a new round starts
    public void UpdateRound(int round)
    {
        currentRound = round;
        roundText.text = "Round: " + currentRound.ToString();
    }
}
