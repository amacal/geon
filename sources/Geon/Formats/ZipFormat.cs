using System;
using System.IO;
using System.IO.Compression;

namespace Geon.Formats
{
    public class ZipFormat : GeoFormat
    {
        public Stream Convert(Stream source)
        {
            using (ZipArchive archive = new ZipArchive(source))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    using (Stream stream = entry.Open())
                    {
                        MemoryStream memory = new MemoryStream();

                        stream.CopyTo(memory);
                        memory.Seek(0, SeekOrigin.Begin);
                        source.Dispose();

                        return memory;
                    }
                }
            }

            throw new InvalidOperationException();
        }
    }
}