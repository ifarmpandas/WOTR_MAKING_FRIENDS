﻿using Newtonsoft.Json;
using System;
using System.IO;
using Microsoft.CSharp;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json.Linq;
using static UnityModManagerNet.UnityModManager;
using System.Linq;

namespace WOTR_MAKING_FRIENDS.GUIDs
{
    public static class GetGUID
    {
        public static ModEntry ModEntry;
        public static string GUIDByName(string s)
        {
            var filePath = Path.Combine(ModEntry.Path, @"GUIDs\Guids.json");

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);

                var oba = JArray.Parse(json).ToList();
                var value = (string)oba.FirstOrDefault(j => (string)j["name"] == s)?["guid"] ?? string.Empty;

                if (value != string.Empty)
                {
                    return value;
                }

                var newGuid = Guid.NewGuid().ToString().Replace(" ", "");
                var newObject = new JObject();
                newObject["name"] = s;
                newObject["guid"] = newGuid;

                oba.Add(newObject); 
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };
                var newJson = JsonConvert.SerializeObject(oba, settings);

                File.WriteAllText(filePath, newJson);

                return newGuid;
            }
            Main.Log("File : " + filePath + "not found.");
            return string.Empty;
        }


    }
}

