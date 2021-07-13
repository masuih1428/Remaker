using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public struct SaveData {
  public List<string> deck;
  public int money;
}

public static class SaveManager {

  public static SaveData sd;
  const string SAVE_FILE_PATH = "save.json";

  public static void saveDeck(List<string> _deck){
    sd.deck = _deck;
    save();
  }

  public static void saveMoney(int _money){
    sd.money = _money;
    save();
  }

  public static void save(){
      string json = JsonUtility.ToJson (sd);
      #if UNITY_EDITOR
        string path = Directory.GetCurrentDirectory();
      #else
        string path = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
      #endif
      path +=  ("/" + SAVE_FILE_PATH);
      StreamWriter writer = new StreamWriter (path, false);
      writer.WriteLine (json);
      writer.Flush ();
      writer.Close ();
  }

  public static void load(){
    try
    {
      #if UNITY_EDITOR
        string path = Directory.GetCurrentDirectory();
      #else
        string path = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
      #endif
      FileInfo info = new FileInfo(path + "/" + SAVE_FILE_PATH);
      StreamReader reader = new StreamReader (info.OpenRead ());
      string json = reader.ReadToEnd ();
      sd = JsonUtility.FromJson<SaveData>(json);
    }
    catch (Exception e)
    {
      sd = new SaveData();
    }
  }
}