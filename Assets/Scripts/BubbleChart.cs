using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Mathematics.Geometry;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class BubbleChart : MonoBehaviour
{
    [SerializeField] TextAsset dataFile;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] GameObject visuals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var csv = new CSVReader();
        csv.Import(dataFile.text);

        var xPos = -0.2f;
        var yPos = 0.4f;
        var zPos = 0f;

        float maxValue = csv.GetMaxValue("Monthly Commuters");
        float maxSize = 0.5f;

        for (int i = 0; i < csv.GetRowCount(); i++)
        {
            var bar = Instantiate(bubblePrefab, Vector3.zero, Quaternion.identity);
            var bubble = bar.GetComponent<DataBubble>();

            bar.transform.SetParent(visuals.transform);
            bar.transform.localRotation = Quaternion.identity;

            var cellValue = csv.GetCell(i, "Monthly Commuters");
            var normalizedValue = int.Parse(cellValue) / maxValue;

            bubble.SetPosition(new Vector3(xPos,yPos,zPos));
            bubble.SetSize(normalizedValue * maxSize);
            bubble.SetLabel(csv.GetCell(i, "Transport Type") + ": " + cellValue);

            xPos += 0.2f;
            yPos += 0.3f;
            zPos += 0.1f;
        }
    }

}
