using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using YK.Enums;

namespace YK.Utils
{
    /// <summary>
    /// jquery.i18n.properties-*.js
    /// resource file extension must be .txt。
    /// </summary>
    public class I18nUtil
    {

        private static readonly string ResourcePath = ConfigurationManager.AppSettings["I18nLangPath"];

        public static void Initial()
        {
            CacheResourceSet();
        }

        private static MemoryCache i18nCache = new MemoryCache("i18nCache");

        private static void CacheResourceSet()
        {
            var resourceSet = i18nCache["i18n"] as IDictionary<string, IDictionary<string, string>>;
            if (resourceSet == null)
            {
                lock (lockObj)
                {
                    if (resourceSet != null)
                    {
                        return;
                    }
                }
            }

            var loadedResourceSet = LoadResourceSet();
            CacheItemPolicy p = new CacheItemPolicy();
            p.Priority = CacheItemPriority.NotRemovable;
            p.ChangeMonitors.Add(new HostFileChangeMonitor(loadedResourceSet.Item2));
            i18nCache.Add(new CacheItem("i18n", loadedResourceSet.Item1), p);
        }

        private static object lockObj = new object();

        public static string Prop(string key, params string[] args)
        {
            if (key == null)
            {
                return "[NULL]";
            }

            var tgtLang = CurrentUILang.ToLower();
            var resSet = i18nCache["i18n"] as IDictionary<string, IDictionary<string, string>>;
            if (resSet == null)
            {
                CacheResourceSet();
                return Prop(key);
            }

            var defaultResDict = resSet.ContainsKey("") ? resSet[""] : new Dictionary<string, string>();
            var resDict = resSet.ContainsKey(tgtLang) ? resSet[tgtLang] : defaultResDict;
            var msg = resDict.ContainsKey(key) ? resDict[key] : string.Format("[{0}]", key); // if not found then return [key]
            if (args.Length > 0)
            {
                msg = string.Format(msg, args);
            }

            return msg;
        }

        public static IList<string> ErrMsg(DataOperationResult result, string para)
        {
            var list = new List<string>();
            foreach (DataOperationResult r in Enum.GetValues(typeof(DataOperationResult)))
            {
                if ((int)r == 0)
                {
                    continue;
                }

                if ((result & r) == r)
                {
                    list.Add(Prop("ErrMsg." + r.ToString(), para));
                }
            }

            return list;
        }

        private static string path = null;

        private static Tuple<IDictionary<string, IDictionary<string, string>>, IList<string>> LoadResourceSet()
        {
            IDictionary<string, IDictionary<string, string>> resourceSet = new Dictionary<string, IDictionary<string, string>>();
            if (path == null)
            {
                path = HttpContext.Current.Server.MapPath(ResourcePath);
            }

            // /i18n/*.txt
            string[] files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var spIndex = fileName.IndexOf('_');
                var key = string.Empty;
                if (spIndex > 0)
                {
                    key = fileName.Substring(spIndex + 1).ToLower();
                }

                IDictionary<string, string> resDict = new Dictionary<string, string>();
                resourceSet.Add(key, resDict);
                var resLines = File.ReadAllLines(file);
                var lineNumber = 0;
                foreach (var line in resLines)
                {
                    lineNumber++;
                    var idx = line.IndexOf('=');
                    if (idx <= 0 || line.StartsWith("//"))
                    {
                        continue;
                    }

                    var k = line.Substring(0, idx);
                    try
                    {
                        resDict.Add(k, line.Substring(idx + 1));
                    }
                    catch (ArgumentException ex)
                    {
                        throw new Exception(string.Format("The item(key=\"{0}\") already exist, please check i18n resource file({1} line:{2}).", k, Path.GetFileName(file), lineNumber), ex);
                    }
                }
            }

            return new Tuple<IDictionary<string, IDictionary<string, string>>, IList<string>>(resourceSet, files);
        }

        public static string CurrentUILang
        {
            get
            {
                var request = HttpContext.Current.Request;
                var cookieLang = request.Cookies["lang"];
                var cookieLangValue = cookieLang == null ? string.Empty : cookieLang.Value;
                var httpAcceptLanguage = request.Params["HTTP_ACCEPT_LANGUAGE"];
                var defaultUILang = ConfigurationManager.AppSettings["I18nDefaultLang"];
                var currentThreadLang = Thread.CurrentThread.CurrentUICulture.Name;
                string lang = null;
                foreach (var str in new string[]{
                        cookieLangValue,
                        request == null ? default(string) : (httpAcceptLanguage.Split(",;".ToCharArray()).First()),
                        defaultUILang,
                        currentThreadLang
                    })
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        lang = str.ToLower();
                        break;
                    }
                }

                return lang;
            }
            set
            {
                var cookie = HttpContext.Current.Response.Cookies["lang"];
                if (cookie == null)
                {
                    cookie = new HttpCookie("lang", value ?? string.Empty);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }

                cookie.Expires = string.IsNullOrEmpty(value) ? DateTime.Now.Subtract(new TimeSpan(100)) : DateTime.Now.AddYears(1);
            }
        }
    }
}
