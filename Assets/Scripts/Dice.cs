using UnityEngine;

public class Dice : MonoBehaviour
{
    public int value;
    public Sprite[] faces;
    public Sprite placeHolder;
    private SpriteRenderer diceImage;
    private bool isToggle;
    public GameObject diceLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diceImage = GetComponent<SpriteRenderer>();
        isToggle = false;
    }

    public void RollDice()
    {
        if (!isToggle)
        {
            int result = Random.Range(0, 6);
            value = result + 1;
            diceImage.sprite = faces[result];
        }
    }

    public void Toggle()
    {
        isToggle = !isToggle;
        if (isToggle)
        {
            diceImage.color = Color.yellow;
        }
        else
        {
            diceImage.color = Color.white;
        }
    }
    public void resetDice()
    {
        diceImage.sprite = placeHolder;
        value = 0;
        if (isToggle)
        {
            Toggle();
        }
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        box.enabled = false;
    }
    public void TurnOnLight()
    {
        diceLight.SetActive(true);
    }
    public void TurnOffLight()
    {
        diceLight.SetActive(false);
    }
}
