using System.Collections.Generic;
using AlexTools.Hash;
using AlexTools.Random;
using Newtonsoft.Json;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        List<StringKey> keys = new();
        
        for (var i = 0; i < 10; i++)
            keys.Add(IRandom.Default.GetString());

        var json = JsonConvert.SerializeObject(keys);
        print(json);
    }
    
    
}
