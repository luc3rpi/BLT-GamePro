
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class CustomCSV : MonoBehaviour
{
    public Dictionary<string,string> ToDict(TextAsset asset)
    {
        string indexer = "";
        bool inQuotes = false;
        bool firstWord = true; ;
        Dictionary<string, string> returner = new Dictionary<string, string>();
        string file = asset.ToString();
        string tempStore = "";
        foreach (char i in file) {
            if (i == '\"')
            {
                inQuotes = !inQuotes;
            }
            else {
                if (!inQuotes && i == ',' && firstWord)
                {
                    indexer = tempStore;
                    firstWord = false;
                }
                else if (!inQuotes && i == '\n' && !firstWord)
                {
                    returner[indexer] = tempStore;
                    tempStore = "";
                    firstWord = true;
                }
                else if (!inQuotes && i == ',') {
                    returner[indexer] = tempStore;
                    tempStore = "";
                } 
                else
                {
                    tempStore += i;
                }
                
            }
        }
        return returner;
    }
}
    /*
    public delegate void ReadLineDelegate(int line_index, List<string> line);

    public static void LoadFromFile(string file_name, ReadLineDelegate line_reader)
    {
        LoadFromString(File.ReadAllText(file_name), line_reader);
    }

    public static Dictionary<string, string> ReadMyCSV(TextAsset Docy)
    {
        string file_contents = Docy.ToString();
        Dictionary<string, string> values = new Dictionary<string, string>();
        int file_length = Docy.ToString().Length;
        int cur_file_index = 0; // index in the file
        List<string> cur_line = new List<string>(); // current line of data
        int cur_line_number = 0;
        StringBuilder cur_item = new StringBuilder("");
        bool inside_quotes = false; // managing quotes
        while (cur_file_index < file_length)
        {
            char c = file_contents[cur_file_index++];

            switch (c)
            {
                case '"':
                    if (!inside_quotes)
                    {
                        inside_quotes = true;
                    }
                    else
                    {
                        if (cur_file_index == file_length)
                        {
                            // end of file
                            inside_quotes = false;
                            goto case '\n';
                        }
                        else if (file_contents[cur_file_index] == '"')
                        {
                            // double quote, save one
                            cur_item.Append("\"");
                            cur_file_index++;
                        }
                        else
                        {
                            // leaving quotes section
                            inside_quotes = false;
                        }
                    }
                    break;
                case '\r':
                    // ignore it completely
                    break;
                case ',':
                    goto case '\n';
                case '\n':
                    if (inside_quotes)
                    {
                        // inside quotes, this characters must be included
                        cur_item.Append(c);
                    }
                    else
                    {
                        // end of current item
                        cur_line.Add(cur_item.ToString());
                        cur_item.Length = 0;
                        if (c == '\n' || cur_file_index == file_length)
                        {
                            // also end of line, call line reader
                            line_reader(cur_line_number++, cur_line);
                            cur_line.Clear();
                        }
                    }
                    break;
                default:
                    // other cases, add char
                    cur_item.Append(c);
                    break;
            }
            while (true)
            {
                break;
            }
        }
        return values;
    }
}
*/