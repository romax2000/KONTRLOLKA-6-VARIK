using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    public class SuperString<T> : List<T>
    {
        List<string> ammo = new List<string>();
        List<string> army = new List<string>();

        public SuperString(List<string> ammo, List<string> army)
        {
            this.ammo = ammo;
            this.army = army;
        }

        public string Finding(SuperString<List<string>> o, string value)
        {
            List<string> NEW = new List<string>();
            NEW.AddRange(ammo);
            NEW.AddRange(army);
            if (NEW.Contains(value))
            {
                return value;
            }
            else throw new Exception("Введённоe значение отсутствует");
        }

    }

    public class Game
    {
        public delegate void GOL(string message);
        public event GOL OR;
        public void ComandOR()
        {
            if (OR != null)
            {
                Console.WriteLine("ГОООООООЛ!!!");
            }
        }
    }

    class Gamer : Game
    {
        public string name;
        public Gamer(string name)
        {
            this.name = name;
        }

    }
    class Program
    {
        static void Main()
        {
            try
            {
                List<string> ammo = new List<string>();
                ammo.Add("rifle");
                ammo.Add("gun");
                ammo.Add("shotgun");
                ammo.Add("RPG");
                ammo.Add("tank");
                List<string> army = new List<string>();
                army.Add("sniper");
                army.Add("killer");
                army.Add("comander");
                army.Add("SPY");
                SuperString<List<string>> first = new SuperString<List<string>>(army, ammo);
                Console.WriteLine("Введите искомый элемент");
                string s = Console.ReadLine();
                Console.WriteLine(first.Finding(first, s));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Строки с 4-мя символами на букву F");
            string[] cars = new string[] { "Audi", "Aston Martin", "Austin", "Alfa Romeo", "BMW", "Ford", "Chevrolet", "Fiat", "Seat" };
            var FINDmyCAR = from n in cars
                            where n.Length == 4 && n.First() == 'F'
                            select n;
            foreach (var n in FINDmyCAR)
                Console.WriteLine(n);


            Gamer firsts = new Gamer("ИГОРЬ НИКОЛАЕВИЧ");
            Gamer second = new Gamer("ВИТАЛЯ");
            firsts.OR += ComandOR;
            second.OR += ComandOR;
            firsts.ComandOR();
            second.ComandOR();
           
        }
        public static void ComandOR(string message)
        {
            Console.WriteLine(message);
        }
    }
}
