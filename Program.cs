using System.Drawing;

namespace CA221010_3
{
    public class Allat { }

    public class Macska : Allat, ILogable, ITudKoszosszonni
    {
        public ConsoleColor Szin { get; set; }
        public string Nev { get; set; }
        public Point Pozicio { get; set; } = new Point(0, 0);

        public string GetLogEntry() =>
            $"macska neve: {Nev}\n" +
            $"macska színe: {Szin}\n" +
            $"jelenlegi pozíció: [{Pozicio.X};{Pozicio.Y}]\n\n";

        public void Koszon(string nev)
        {
            Console.WriteLine($"Szia {nev}!");
        }

        public void Nyavog()
        {
            Console.ForegroundColor = this.Szin;
            Console.WriteLine("miaú - miaú");
            Console.ResetColor();
        }
    }

    public class Vaza : ILogable
    {
        private int _x;
        private int _y;
        public bool Torott { get; set; } = false;
        public string Anyag { get; set; }
        public Point Pozicio 
        {
            get => new Point(_x, _y);
            set
            {
                _x = value.X;
                _y = value.Y;
            }
        }

        public string GetLogEntry()
        {
            return 
                $"váza anyagy: {Anyag}\n" +
                $"váza {(Torott ? "összetört" : "még egyben van")}\n\n";
        }
    }

    public interface ILogable
    {
        Point Pozicio { get; set; }
        string GetLogEntry();
    }

    public interface ITudKoszosszonni
    {
        public void Koszon(string nev);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vaza v1 = new Vaza()
            {
                Anyag = "agyag",
                Torott = true,
            };
            Vaza v2 = new Vaza()
            {
                Anyag = "kerámia",
            };
            Macska m1 = new Macska()
            {
                Szin = ConsoleColor.Red,
                Nev = "Bálint",
            };

            Console.Write("kell log? ");

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                string log = string.Empty;

                List<ILogable> dolgojk = new List<ILogable>() { v1, v2, m1};
                foreach (var d in dolgojk)
                {
                    log += d.GetLogEntry();
                    //if (d is Macska) (d as Macska).Koszon("Béla");
                }

                Console.WriteLine('\n' + log);
            }

        }
    }
}