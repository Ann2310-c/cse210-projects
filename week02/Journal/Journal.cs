using System;
using System.Collections.Generic;
using System.IO;

public class Journal{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry){
        _entries.Add(newEntry);
    }

    public void DisplayAll(){
        foreach (Entry entry in _entries){
            entry.Display();
        }
    }

    //Writing files
    public void SaveToFile(string file){
        using (StreamWriter writer = new StreamWriter(file)){
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }Console.WriteLine("Journal saved successfully.");
    }

    //Reading files
    public void LoadFromFile(string file){
        if(File.Exists(file)){
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines){
                string[] parts = line.Split('|');
                if(parts.Length == 3){
                    _entries.Add(new Entry(parts[0], parts[1], parts[2]));
                }
            }Console.WriteLine("Journal loaded successfully.");
        }else{
            Console.WriteLine("File not found.");
        }
    }
}