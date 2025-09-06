using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Dice[] allDices;
    public Transform P1Buttons;
    public Transform P2Buttons;
    public GameObject GGwindow;
    public TextMeshProUGUI pontTextP1;
    public TextMeshProUGUI pontTextP2;
    public TextMeshProUGUI rollsText;
    private int pontP1 = 0;
    private int pontP2 = 0;
    private int round = 0;
    private int rolls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        round += 1;
        rolls = 3;
        rollsText.text = rolls.ToString();
        foreach (Transform child in P2Buttons)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void rollAllDices()
    {
        if (rolls > 0)
        {
            foreach (Dice dice in allDices)
            {
                BoxCollider2D box = dice.GetComponent<BoxCollider2D>();
                box.enabled = true;
                dice.RollDice();
            }
            rolls--;
            rollsText.text = rolls.ToString();
        }
    }
    public void play(Button button)
    {
        int buttonNum = int.Parse(button.name);
        int sum = 0;
        foreach (Dice dice in allDices)
        {
            if (dice.value == buttonNum)
            {
                sum += dice.value;
            }
        }
        if (round % 2 != 0)
        {
            pontP1 += sum;
            pontTextP1.text = pontP1.ToString();
        }
        else
        {
            pontP2 += sum;
            pontTextP2.text = pontP2.ToString();
        }
        round += 1;
        swapButtons();
        foreach (Dice dice in allDices)
        {
            dice.resetDice();
        }
        button.interactable = false;
        button.GetComponentInChildren<TextMeshProUGUI>().text = sum.ToString();
        rolls = 3;
        rollsText.text = rolls.ToString();
        TurnOffLights();
        if (round == 13)
        {
            GGwindow.SetActive(true);
        }
    }

    private void swapButtons()
    {
        if (round % 2 != 0)
        {
            foreach (Transform child in P1Buttons)
            {
                child.gameObject.SetActive(true);
            }
            foreach (Transform child in P2Buttons)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in P2Buttons)
            {
                child.gameObject.SetActive(true);
            }
            foreach (Transform child in P1Buttons)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    public void TurnOnLights(int ButtonNum)
    {
        foreach (Dice dice in allDices)
        {
            if (dice.value == ButtonNum)
            {
                dice.TurnOnLight();
            }
        }
    }
    public void TurnOffLights()
    {
        foreach (Dice dice in allDices)
        {
            dice.TurnOffLight();
        }
    }


}
