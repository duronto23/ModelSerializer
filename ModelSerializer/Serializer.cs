using System.Collections.Generic;

namespace ModelSerializer
{
    public class Serializer
    {
        public List<string> GetSerializedData(object dictionary)
        {
            return GetKeysWithLevel(dictionary, 1);            
        }

        private static List<string> GetKeysWithLevel(object value, int level)
        {
            var result = new List<string>();
            if (value is Person)
            {
                result.Add($"first_name: {level}");
                result.Add($"last_name: {level}");
                result.Add($"father: {level}");
                var person = (Person)value;
                if (person._father is Person)                
                    result.AddRange(GetKeysWithLevel(person._father, level + 1));                
                return result;
            }

            if (value is Dictionary<string, object>)
            {
                var dictionary = (Dictionary<string, object>) value;
                foreach (var pair in dictionary)
                {
                    result.Add($"{pair.Key}: {level}");
                    if (pair.Value is Dictionary<string, object> || pair.Value is Person)
                        result.AddRange(GetKeysWithLevel(pair.Value, level + 1));
                }
            }

            return result;
        }
    }
}
