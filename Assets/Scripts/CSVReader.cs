using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            headers = rows[0].Split(delimiter, System.StringSplitOptions.RemoveEmptyEntries).Select(s => Regex.Replace(s, @"\t|\n|\r", "")).ToList();

            for ( var i = 1; i < rows.Length; i++)
            {
                var row = rows[i].Split(delimiter);

                var rowData = new Dictionary<string, string>();

                for (var j = 0; j < row.Length; j++)
                {
                    rowData[headers[j]] = Regex.Replace(row[j], @"\t|\n|\r", "");
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
                    rowData[j.ToString()] = Regex.Replace(row[j], @"\t|\n|\r", "");
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

    public int GetRowCount()
    {
        return Data.Count;
    }

    public int GetMaxValue(int colIndex)
    {
        if (colIndex >= headers.Count) return 0;
        return Data.Max(s => int.Parse(s[headers[colIndex]]));
    }

    public int GetMaxValue(string colKey)
    {
        if (!headers.Contains(colKey)) return 0;
        return Data.Max(s => int.Parse(s.GetValueOrDefault(colKey, "0")));
    }

    public string GetCell(int rowIndex, string label)
    {
        return Data[rowIndex].GetValueOrDefault(label);
    }
}
