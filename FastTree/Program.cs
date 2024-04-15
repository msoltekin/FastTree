using System;

namespace FastTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new[] { "afaerwerwerewrww", "fbawersdbadhaeg", "abfabzbvzdd", "bffazvadfvzvd", "afb", "bbb" };
            var manager = new TreeManager();
            foreach (var item in list)
            {
                manager.AddItem(item);
            }
            
            manager.SearchItem("bffazvadfvzvd");
            manager.SearchItem("bbb");
            manager.SearchItem("2222222222");

            Console.WriteLine($"Found item count:{manager.FoundItemCount}");
            Console.ReadLine();
        }
    }
}
