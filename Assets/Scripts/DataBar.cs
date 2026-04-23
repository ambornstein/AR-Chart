using TMPro;
using UnityEngine;

public class DataBar : MonoBehaviour
{
    [SerializeField] GameObject barObject;
    [SerializeField] TextMeshProUGUI labelText;
    [SerializeField] float width;

    public void SetHeight(float heightValue) {
        barObject.transform.localScale = new Vector3(width, heightValue, width);
        barObject.transform.position = new Vector3(transform.position.x, heightValue / 2, transform.position.z); 
    }

    public void SetLabel(string text)
    {
        labelText.text = text;
    }
}
