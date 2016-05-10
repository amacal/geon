using System;
using System.Collections.Generic;
using System.IO;

namespace Geon.Readers
{
    public class CsvReader : GeoReader
    {
        public IEnumerable<GeoEntry> GetEntries(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                while (reader.EndOfStream == false)
                {
                    yield return GetEntryFromLine(reader.ReadLine());
                }
            }
        }

        private static GeoEntry GetEntryFromLine(string line)
        {
            string[] parts = line.Split(new[] { ',' }, 6, StringSplitOptions.RemoveEmptyEntries);

            return new GeoEntry
            {
                From = UInt32.Parse(parts[2].Trim('\"')),
                To = UInt32.Parse(parts[3].Trim('\"')),
                Code = parts[4].Trim('\"'),
                Name = parts[5].Trim('\"')
            };
        }
    }
}