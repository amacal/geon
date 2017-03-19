using System;
using System.Collections.Generic;
using System.IO;

namespace Geon.Readers
{
    public class CsvReader : GeoReader
    {
        public IEnumerable<GeoEntry> GetEntries(Stream stream)
        {
            Dictionary<string, string> keys = new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(stream))
            {
                while (reader.EndOfStream == false)
                {
                    yield return GetEntryFromLine(keys, reader.ReadLine());
                }
            }
        }

        private static GeoEntry GetEntryFromLine(Dictionary<string, string> keys, string line)
        {
            string[] parts = line.Split(new[] { ',' }, 6, StringSplitOptions.RemoveEmptyEntries);

            string code = parts[4].Trim('\"');
            string name = parts[5].Trim('\"');

            if (keys.ContainsKey(code) == false)
                keys.Add(code, code);

            if (keys.ContainsKey(name) == false)
                keys.Add(name, name);

            return new GeoEntry
            {
                From = UInt32.Parse(parts[2].Trim('\"')),
                To = UInt32.Parse(parts[3].Trim('\"')),
                Code = keys[code],
                Name = keys[name]
            };
        }
    }
}