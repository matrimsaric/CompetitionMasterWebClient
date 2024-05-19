using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.Func
{
    public class FuncTest
    {
        public void Test()
        {
            Func<string> sayHello = GetMessage;
            MessageBox.Show(sayHello());
        }

        public string GetMessage()
        {
            return "Hello there!";
        }

    }

    public class Usr
    {
        public int id = 0;
        public string firstName = "";
        public string city = "";
        public string dob = "";

        public Usr(int id1, string fn1, string c, string dob1)
        {
            id = id1;
            firstName = fn1;
            city = c;
            dob = dob1;
        }
    }

    public class Dragon
    {
        public string name = "";
        public string color = "";


        public Dragon(string n1, string c1)
        {
            name = n1;
            color = c1;
        }
    }

    public class FuncTest2
    {
        List<Usr> users =
            [
                new (1, "John","London", "2001-04-01"),
                new (2, "Lenny", "New York", "1997-12-11"),
                new (3, "Andrew","Boston", "1987-02-22"),
                new (4, "Peter","Prague", "1936-03-24"),
                new (5, "Anna","Bratislava", "1973-11-18"),
                new (6, "Albert","Bratislava", "1940-12-11"),
                new (7, "Adam","Poland", "1983-12-01"),
                new (8, "Robert","Bratislavia", "1935-05-15"),
                new (9, "Robert","Prague", "1998-03-14")
            ];


        public void Test()
        {
            string city = "Bratislava";
            Func<Usr, bool> livesIn = e => e.city == city;

            var res = users.Where(livesIn);

            foreach(Usr e in res)
            {
                Console.WriteLine(e);
            }

            int age = 60;

            Func<Usr, bool> olderThan = e => GetAge(e) > age;

            var res2 = users.Where(olderThan);

            foreach (var e in res2)
            {
                Console.WriteLine(e);
            }
        }

        int GetAge(Usr user)
        {
            DateTime dob = DateTime.Parse(user.dob);
            return (int)Math.Floor((DateTime.Now - dob).TotalDays / 365.25D);
        }

    }

    

    public class FuncTest3
    {
        List<Dragon> data = [
                new ("Dozy", "green"),
                new ("Hot", "red"),
                new ("Basted", "blue"),
                new ("Chilled", "iceblue")
            ];


        public void Test()
        {
            ShowOutput(data, r => r.color == "red" || r.color == "green");
        }

        public void ShowOutput(List<Dragon> list, Func<Dragon, bool> condition)
        {
            var data = list.Where(condition);

            foreach( var dragon in data)
            {
                Console.WriteLine(dragon.name);
            }
        }
    }


}
