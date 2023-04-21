namespace Fry
{
    class _main
    {
        static void Main(string[] args)
        {
            //System.Diagnostics.Process.Start("https://bothax.com/");
            bool check = ConsoleApp1.Func.checkPer();
            if (!check) {
                ConsoleApp1.Func._printf("Pls run me with admin!", 1, ConsoleColor.DarkRed);
                ConsoleApp1.Func._printf("Press any key exit", 1, ConsoleColor.DarkMagenta);
                Console.ReadKey();
                return;
            }
            ConsoleApp1.Func._mySign();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConsoleApp1.Func._printf("Dev by FrySimpl3",1,ConsoleColor.DarkRed);
            string path = ConsoleApp1.Func.FindAppDataFolder();
            Console.WriteLine(path +"fry.ini");
            ConsoleApp1.Func._printf(path == string.Empty ? "Không Tìm Thấy Thư Mục":"Đã Tìm Thấy Thư Mục : "+ path, 1, ConsoleColor.DarkGreen);
            if (path ==null)
            {
                ConsoleApp1.Func._printf("Press any key exit", 1, ConsoleColor.DarkMagenta);
                Console.ReadKey();
                return;
            }
            string urlOfConfig = "https://api.pastecode.io/anon/raw-snippet/i2t2zxh7?raw=inline&ticket=5fdd97f7-7a1c-42bf-99b9-54a2d8551582";
            Uri uriResult;
            string Url = string.Empty;
            if (Uri.TryCreate(urlOfConfig, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                Url = ConsoleApp1.Func.getUrl(urlOfConfig);
                System.Threading.Thread.Sleep(1000);
                ConsoleApp1.Func.dowlaodFile(Url, "Fry.Config");
                File.Copy("Fry.Config", path + "\\config.bin", true);
            }
            Console.ReadKey();
        }
    }
}