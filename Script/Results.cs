using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public static class Results{
    private static Dictionary<string, Dictionary<string, string>> results;

    public static string GetScore(string scene, string type){
        Init();

        if (results.ContainsKey(scene) == false)
            return "0";

        if (results[scene].ContainsKey(type) == false)
            return "0";

        return results[scene][type];
    }

    public static void SetScore(string scene, string type, string value){
        Init();

        if (results.ContainsKey(scene) == false)
            results[scene] = new Dictionary<string, string>();

        results[scene][type] = value;
    }

    public static void Init(){
        if (results != null)
            return;

        results = new Dictionary<string, Dictionary<string, string>>();
    }
}