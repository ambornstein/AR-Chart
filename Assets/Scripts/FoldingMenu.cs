using UnityEngine;

public class FoldingMenu : MonoBehaviour
{

    [SerializeField] int expandedSize;
    [SerializeField] int foldedSize;
    [SerializeField] bool folded;

    RectTransform rect_transform;

    private void Awake()
    {
        TryGetComponent(out rect_transform);
        ToggleFolded();
    }

    public void ToggleFolded()
    {
        rect_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, folded ? expandedSize : foldedSize);
        folded = !folded;
    }
}
