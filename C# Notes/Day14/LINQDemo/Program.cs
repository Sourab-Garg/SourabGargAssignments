namespace LINQDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employee1 = repo.Retrive();

            //var londonAbove40k = employee1.Select(x => new { FullName = x.FirstName+" "+x.LastName, x.City, x.Sal}).Where(x => x.City == "London").Where(x => x.Sal > 40000);

            var londonAbove40k = employee1.Where(x=> x.Sal > 40000 && x.City == "London")
                                 .OrderByDescending(x=> x.FirstName)
                                 .Select(x=> new 
                                        { 
                                            FullName = x.FirstName + " " + x.LastName,
                                            x.Sal
                                        });

            foreach(var emp in londonAbove40k)
            {
                Console.WriteLine(emp.FullName+ " "+ emp.Sal);
            }

            var maxSalInCity = employee1.GroupBy(x => x.City);

            foreach (var group in maxSalInCity)
            {
                Console.WriteLine(group.Key + " "+ group.Count());
                //var maxSal = group.OrderByDescending(x => x.Sal).FirstOrDefault();
                //Console.WriteLine(maxSal.Sal);

                var maxSal = group.Max(x => x.Sal);
                Console.WriteLine(maxSal);
            }

            Console.ReadLine();
        }
    }
}
