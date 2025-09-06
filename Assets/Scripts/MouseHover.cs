using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameManager gameManager;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject enteredObject = eventData.pointerEnter;
        if (enteredObject.ToString() != "Text (TMP) (UnityEngine.GameObject)")
        {
            int ButtonNum = int.Parse(enteredObject.name);
            gameManager.TurnOnLights(ButtonNum);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameManager.TurnOffLights();
    }
}
