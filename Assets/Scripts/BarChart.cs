using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Mathematics.Geometry;
using UnityEditor;
using UnityEngine;

//[ExecuteInEditMode]
public class BarChart : MonoBehaviour
{
    [SerializeField] TextAsset dataFile;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] GameObject barPrefab;
    [SerializeField] GameObject visuals;
    [SerializeField] float maxHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var csv = new CSVReader();
        csv.Import(dataFile.text);

        var xPos = -0.40f;
        var yPos = 0.40f;

        float max = csv.GetMaxValue("Quantity Sold");

        for (int i = 0; i < csv.GetRowCount(); i++)
        {
            var bar = Instantiate(barPrefab, new Vector3(xPos, 0.5f, yPos), Quaternion.identity);
            var dataBar = bar.GetComponent<DataBar>();

            bar.transform.SetParent(visuals.transform);

            var cellValue = csv.GetCell(i, "Quantity Sold");
            var normalizedValue = int.Parse(cellValue) / max;
            Debug.Log(normalizedValue * maxHeight);

            dataBar.SetHeight(normalizedValue * maxHeight);
            dataBar.SetLabel(csv.GetCell(i, "Product Name") + ": " + cellValue);

            xPos += 0.25f;
            yPos -= 0.15f;
        }
    }

}
