using System.IO;
using TMPro;
using UnityEngine;

public class Chart : MonoBehaviour
{

    [SerializeField] TextAsset dataFile;
    [SerializeField] TextMeshProUGUI title;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var csv = new CSVReader();
        csv.Import(dataFile.text);

        foreach (var header in csv.headers)
        {
            Debug.Log(header);
        }
    }

}
