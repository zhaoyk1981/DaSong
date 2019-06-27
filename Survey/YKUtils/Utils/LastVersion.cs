using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YK.Utils
{
    public class LastVersion
    {
        public static long GetLastWrite(IList<string> dirs)
        {
            var dict = dirs.ToDictionary(m => m, m => "*.*");
            return GetLastWrite(dict);
        }

        public static long GetLastWrite(IDictionary<string, string> dirs)
        {
            var lastVer = 0L;

            if (dirs == null)
            {
                return lastVer;
            }
            
            foreach (KeyValuePair<string, string> dir in dirs)
            {
                var searchPattern = dir.Value ?? "*.*";
                var filePath = Directory.GetFiles(dir.Key, searchPattern, SearchOption.TopDirectoryOnly);
                foreach (var path in filePath)
                {
                    var ver = File.GetLastWriteTimeUtc(path).GetTime();
                    if (ver > lastVer)
                    {
                        lastVer = ver;
                    }
                }
            }

            return lastVer;
        }
    }

    
}
