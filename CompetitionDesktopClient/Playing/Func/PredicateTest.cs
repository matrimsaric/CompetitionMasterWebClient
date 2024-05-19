using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.Func
{
    public class PredicateTest
    {
        Usr[] users =
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

        public void TestThis()
        {
            int age = 40;
            Predicate<Usr> olderThan = e => GetAge(e) > age;


            var res = Array.FindAll(users, olderThan);

            foreach (var e in res)
            {
                Console.WriteLine(e);
            }

        }

        public int GetAge(Usr user)
        {
            var dob = DateTime.Parse(user.dob);
            return (int)Math.Floor((DateTime.Now - dob).TotalDays / 365.25D);
        }

    }
}
