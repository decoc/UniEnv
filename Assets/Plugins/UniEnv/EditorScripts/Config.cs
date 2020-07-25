using System;

namespace UniEnvs
{
    /// <summary>
    /// Config has key value pair of environments values.
    /// </summary>
    [Serializable]
    public sealed class Config : SerializableDictionary<string, string>
    {
        public bool GetBool(string key, bool fallback = default) => 
            bool.TryParse(this[key], out var value) ? value : fallback;
        
        public int GetInt(string key, int fallback = default) => 
            int.TryParse(this[key], out var value) ? value : fallback;

        public float GetFloat(string key, float fallback = default) => 
            float.TryParse(this[key], out var value) ? value : fallback;
        
        public double GetDouble(string key, double fallback = default) => 
            double.TryParse(this[key], out var value) ? value : fallback;
        
        public string GetString(string key, string fallback = default) => 
            this.TryGetValue(key, out var value) ? value : fallback;
    }
}