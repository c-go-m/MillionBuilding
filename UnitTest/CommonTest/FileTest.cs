using Newtonsoft.Json.Linq;

namespace UnitTest.CommonTest
{
    public class FileTest
    {
        public static StreamReader GetFile(string nameFile)
        {
            var urlBase = ReplacePath(Directory.GetCurrentDirectory());

            var result = new StreamReader(urlBase + nameFile);

            return result;
        }

        public static List<T> Deserialize<T>(string path, string type)
        {
            try
            {
                StreamReader jsonFile = GetFile(path);
                JObject jsonObject = JObject.Parse(jsonFile.ReadToEnd());
                var list = new List<T>();
                foreach (var item in jsonObject[Constants.ListData])
                {
                    list.Add(item[type].ToObject<T>());
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ReplacePath(string path)
        {
            var result = "";
            var url = path.Split(Constants.CharPath);
            for (int i = 0; i < url.Length - 3; i++)
            {
                result = result + url[i] + Constants.CharPath;
            }
            return (result + Constants.BaseUrl);
        }
    }
}
