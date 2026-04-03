using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CSVReader
{
    public string delimiter = ",";
    public bool headerLine = true;

    public List<Dictionary<string, string>> Data = new();
    public List<string> headers = new();

    public void Import(string src)
    {
        Data.Clear();

        string[] rows = src.Split('\n');
        if (headerLine)
        {
            headers = rows[0].Split(delimiter).ToList();

            for ( var i = 1; i < rows.Length; i++)
            {
                var row = rows[i].Split(delimiter);

                var rowData = new Dictionary<string, string>();

                for (var j = 0; j < row.Length; j++)
                {
                    rowData[headers[j]] = row[j];
                }
                    
                Data.Add(rowData);
            }
        }
        else
        {
            for (var i = 0; i < rows.Length; i++)
            {
                var row = rows[i].Split(delimiter);

                var rowData = new Dictionary<string, string>();

                for (var j = 0; j < row.Length; j++)
                {
                    rowData[j.ToString()] = row[j];
                }
                
                Data.Add(rowData);
            }
        }
    }

    public CSVReader(string delimiter = ",",  bool headerLine = true)
    {
        this.delimiter = delimiter;
        this.headerLine = headerLine;
    }
}
