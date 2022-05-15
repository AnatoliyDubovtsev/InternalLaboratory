using System;
using System.Text;

namespace Module7.Task3
{
    public static class WorkWithUrl
    {
        public static string AddOrChangeUrlParameter(string url, string keyValueParameter)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url), "URL is null or empty");
            }
            else if (string.IsNullOrEmpty(keyValueParameter))
            {
                throw new ArgumentNullException(nameof(keyValueParameter), "KeyValue parameter is null or empty");
            }

            if (url.StartsWith(' ') || url.EndsWith(' '))
            {
                url = url.Trim();
            }

            if (keyValueParameter.StartsWith(' ') || keyValueParameter.EndsWith(' '))
            {
                keyValueParameter = keyValueParameter.Trim();
            }

            string keys = null;
            if (url.Contains("?"))
            {
                keys = url[(url.IndexOf('?') + 1)..];
                url = url[..(url.IndexOf('?') + 1)];
            }

            string[] existingKeys = Array.Empty<string>();
            bool isThereExistingKeys = false;
            if (!string.IsNullOrEmpty(keys))
            {
                existingKeys = keys.Split("&&");
                isThereExistingKeys = true;
            }

            bool isKeyChanged = false;
            for (int i = 0; i < existingKeys.Length; i++)
            {
                int indexOfEqualSymbolInExistingKey = existingKeys[i].IndexOf('=');
                int indexOfEqualSymbolInKeyValueParameter = keyValueParameter.IndexOf('=');
                if (existingKeys[i][..indexOfEqualSymbolInExistingKey] == keyValueParameter[..indexOfEqualSymbolInKeyValueParameter])
                {
                    existingKeys[i] = existingKeys[i][..indexOfEqualSymbolInExistingKey] + keyValueParameter[indexOfEqualSymbolInKeyValueParameter..];
                    isKeyChanged = true;
                    break;
                }
            }

            StringBuilder result = new(url);
            if (result[^1] != '?')
            {
                result.Append('?');
            }

            for (int i = 0; i < existingKeys.Length; i++)
            {
                result.Append(existingKeys[i]);
                if (i < existingKeys.Length - 1)
                {
                    result.Append("&&");
                }
            }

            if (isThereExistingKeys && !isKeyChanged)
            {
                result.Append($"&&");
            }

            if (!isKeyChanged)
            {
                result.Append(keyValueParameter);
            }
            
            return result.ToString();
        }
    }
}
