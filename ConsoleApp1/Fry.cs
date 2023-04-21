

namespace ConsoleApp1
{
    internal static class Func
    {
        public static bool checkPer()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            bool isAdmin = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            if (isAdmin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void _printf(string msg="",int sleep=0,System.ConsoleColor consoleColor = System.ConsoleColor.White)
        {
            Console.ForegroundColor = consoleColor;
            string _out = DateTime.Now.ToString("[ HH:mm:ss dd/MM/yyyy ]\t") + msg;
            foreach (var item in _out)
            {
                Console.Write(item);
                System.Threading.Thread.Sleep(sleep);
            }
            Console.ForegroundColor = System.ConsoleColor.White;
            Console.WriteLine();
        }
        public static void _mySign()
        {
            string _out = DateTime.Now.ToString("[ HH:mm:ss dd/MM/yyyy ]      ");
            string txt = $"{_out}Code By Fry\n{_out}Discord : Frysimpl3#7958";
            System.IO.File.AppendAllText("Fry.ini", txt);
        }
        public static string FindAppDataFolder()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string[] directories = Directory.GetDirectories(appDataPath);
            foreach (string dir in directories)
            {
                string path = Path.GetRelativePath(appDataPath, dir);
                if (path.Length == 32)
                {
                    if (System.IO.File.Exists(dir+"\\config.bin") && System.IO.File.Exists(dir + "\\session.dat"))
                    {
                        return dir;
                    }
                    else
                    {
                        ConsoleApp1.Func._printf("Press any key exit", 1, ConsoleColor.DarkMagenta);
                        Console.ReadKey();
                        System.Environment.Exit(0);
                    }
                }
            }
            return null;
        }
        public static string getUrl(string url)
        {
            string result = string.Empty;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                result = client.DownloadString(url);
            }
            Uri uriResult;
            if (Uri.TryCreate(result, UriKind.Absolute, out uriResult) &&(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                _printf("Url hợp lệ");
                return uriResult.ToString();
            }
            else
            {
                Console.WriteLine("Chuỗi không phải là URL hợp lệ.");
                return null;
            }
        }
        public static bool dowlaodFile(string url, string localPath) 
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.DownloadFile(url, localPath);
            }
            System.Threading.Thread.Sleep(1000);
            if (File.Exists(localPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
