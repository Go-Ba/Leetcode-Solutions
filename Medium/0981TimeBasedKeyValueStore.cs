using System.Collections.Generic;

public class TimeBasedKeyValueStore
{
    //https://leetcode.com/problems/time-based-key-value-store
    public class TimeMap
    {
        Dictionary<string, List<(int, string)>> keyMap;
        public TimeMap()
        {
            keyMap = new Dictionary<string, List<(int, string)>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            //new key
            if (!keyMap.ContainsKey(key))            
                keyMap.Add(key, new List<(int, string)>() { (timestamp, value) });  
            //replace if same timestamp
            else if (keyMap[key][^1].Item1 == timestamp)
                keyMap[key][^1] = (timestamp, value);
            //add new timestamp
            else
                keyMap[key].Add((timestamp, value));
        }

        public string Get(string key, int timestamp)
        {
            if (!keyMap.TryGetValue(key, out var timestampList))
                return "";
            if (timestampList[0].Item1 > timestamp)
                return "";

            //get min timestamp
            string result = "";
            int l = 0, r = timestampList.Count - 1, mid = 0;
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (timestampList[mid].Item1 <= timestamp)
                {
                    result = timestampList[mid].Item2;
                    l = mid + 1;
                }
                else
                    r = mid - 1;
            }
            return result;
        }
    }

}