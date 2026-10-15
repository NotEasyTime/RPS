using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RPS : MonoBehaviour
{
    public enum OPTIONS
    {
        ROCK,
        PAPER,
        SCISSORS
    }

    public TMP_Text playerSelectionLabel;
    public TMP_Text cpuSelectionLabel;
    public TMP_Text outcomeLabel;
    public GameObject outcomeDisplay;


    public string playerSelectionDefaultLabel = "You Chose: ";
    public string cpuSelectionDefaultLabel = "CPU Chose: ";

    private int playerChoice = -1;
    private int cpuChoice = 0;

    private bool canPlay = true;

    private void Start()
    {
        outcomeDisplay.SetActive(false);
    }

    private void Update()
    {
       
        if (Input.GetKey("c") && canPlay)
        {
            canPlay = false;
            CpuSelect();
            DetermineOutcome();
        }


        if (Input.GetKey("r") && canPlay == false)
        {
            canPlay = true;
            playerSelectionLabel.text = playerSelectionDefaultLabel;
            cpuSelectionLabel.text = cpuSelectionDefaultLabel;
            outcomeDisplay.SetActive(false);
        }
    }

    private void CpuSelect()
    {
        cpuChoice = Random.Range((int)OPTIONS.ROCK, (int)OPTIONS.SCISSORS + 1);
        cpuSelectionLabel.text = cpuSelectionDefaultLabel + ((OPTIONS)cpuChoice).ToString();
    }

    private void DetermineOutcome()
    {
        string outcome;

        if (playerChoice == -1)
        {
            outcome = "No Input Entered";
        }
        else if (playerChoice == cpuChoice)
        {
            outcome = "IT'S A TIE!";
        }
        else if (
            (playerChoice == (int)OPTIONS.ROCK && cpuChoice == (int)OPTIONS.SCISSORS) || 
            (playerChoice == (int)OPTIONS.PAPER && cpuChoice == (int)OPTIONS.ROCK) || 
            (playerChoice == (int)OPTIONS.SCISSORS && cpuChoice == (int)OPTIONS.PAPER)
            )
        {
            outcome = "YOU WIN!";
        }
        else
        {
            outcome = "YOU LOSE.";
        }

        outcomeDisplay.SetActive(true);
        outcomeLabel.text = outcome;
    }

    public void OnRockButtonClicked()
    {
        if(canPlay == false) { return; }
        playerChoice = (int)OPTIONS.ROCK;
        playerSelectionLabel.text = playerSelectionDefaultLabel + "ROCK";
    }

    public void OnPaperButtonClicked()
    {
        if (canPlay == false) { return; }
        playerChoice = (int)OPTIONS.PAPER;
        playerSelectionLabel.text = playerSelectionDefaultLabel + "PAPER";
    }

    public void OnScissorsButtonClicked()
    {
        if (canPlay == false) { return; }
        playerChoice = (int)OPTIONS.SCISSORS;
        playerSelectionLabel.text = playerSelectionDefaultLabel + "SCISSORS";
    }
}