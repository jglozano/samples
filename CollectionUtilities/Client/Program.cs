namespace Client
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using CollectionUtilities;

    internal class Program
    {
        public static void Main()
        {
            var customers = new List<Customer>();

            for (int i = 0; i < 10; i++)
            {
                var c = new Customer { Id = i, Name = "Customer " + i };

                customers.Add(c);
            }

            var table = PrintTable(customers);
            PrintCollection(table);

            Console.ReadLine();
        }

        private static void PrintCollection(DataTable table)
        {
            Console.WriteLine("Printing a DataTable to an IList");
            Console.WriteLine("---------------------------");

            var list = table.ToList<Customer>();
            foreach (var customer in list)
            {
                Console.WriteLine("Customer");
                Console.WriteLine("---------------");

                Console.WriteLine("Id: {0} - Name: {1}", customer.Id, customer.Name);
            }

            Console.WriteLine();
        }

        private static DataTable PrintTable(IList<Customer> customers)
        {
            Console.WriteLine("Printing an IList to a DataTable");
            Console.WriteLine("---------------------------");

            DataTable table = customers.ToDataTable();

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("Customer");
                Console.WriteLine("---------------");

                foreach (DataColumn column in table.Columns)
                {
                    object value = row[column.ColumnName];
                    Console.WriteLine("{0}: {1}", column.ColumnName, value);
                }
            }
            Console.WriteLine();

            return table;
        }
    }
}