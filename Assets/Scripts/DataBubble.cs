using TMPro;
using UnityEngine;

public class DataBubble : MonoBehaviour
{
    [SerializeField] GameObject bubbleObject;
    [SerializeField] TextMeshProUGUI labelText;
    [SerializeField] Canvas canvas;

    public void SetSize(float sizeValue)
    {
        bubbleObject.transform.localScale = new Vector3(sizeValue,sizeValue,sizeValue);
        canvas.transform.localPosition = new Vector3(canvas.transform.localPosition.x, canvas.transform.localPosition.y, -(sizeValue / 2) - 0.02f);
    }

    public void SetPosition(Vector3 positionValue)
    {
        transform.localPosition = positionValue;
    }

    public void SetLabel(string text)
    {
        labelText.text = text;
    }
}
