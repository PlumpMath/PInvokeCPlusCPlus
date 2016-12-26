namespace Managed
{
    using System;
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main(string[] args)
        {
            Add();

            Sum();

            GetParameters();

            GetGreeting();

            GetCost();

            GetTotalCost();

            GetCustomers();

            GetColumnTotal();

            GetRowTotals();

            Console.Read();
        }

        static void Add()
        {
            var parm1 = 1;
            var parm2 = 2;

            var result = UnmanagedProxy.Add(1, 2);

            Console.WriteLine("Add({0}, {1})", parm1, parm2);
            Console.WriteLine("Result: {0}", result);
            Console.WriteLine("------------------------------");
        }

        static void Sum()
        {
            var parameters = new Parameters { Parm1 = 3, Parm2 = 4 };

            var result = UnmanagedProxy.Sum(parameters);

            Console.WriteLine("Sum({0}, {1})", parameters.Parm1, parameters.Parm2);
            Console.WriteLine("Result: {0}", result);
            Console.WriteLine("------------------------------");
        }

        static void GetParameters()
        {
            var result = UnmanagedProxy.GetParameters();

            Console.WriteLine("Parm1: {0}", result.Parm1);
            Console.WriteLine("Parm2: {0}", result.Parm2);
            Console.WriteLine("------------------------------");
        }

        static void GetGreeting()
        {
            var result = UnmanagedProxy.GetGreeting();

            Console.WriteLine(Marshal.PtrToStringAnsi(result));
            Console.WriteLine("------------------------------");
        }

        static void GetCost()
        {
            var lineItem = new LineItem
            {
                Name = "Jersey",
                Price = 89.99,
                Quantity = 1,
                SalesTax = .08
            };

            var result = UnmanagedProxy.GetCost(lineItem);

            Console.WriteLine("Cost = {0}", result);
            Console.WriteLine("------------------------------");
        }

        static void GetTotalCost()
        {
            LineItem[] lineItems = new LineItem[2];

            lineItems[0] = new LineItem
            {
                Name = "Jersey",
                Price = 89.99,
                Quantity = 2,
                SalesTax = .08
            };

            lineItems[1] = new LineItem
            {
                Name = "Runing shoes",
                Price = 79.95,
                Quantity = 1,
                SalesTax = .12
            };

            // create the array of pointers
            var lineItemPointers = new IntPtr[lineItems.Length];

            // allocate memory for each pointer and marshal each object
            for (var i = 0; i < lineItems.Length; i++)
            {
                lineItemPointers[i] = Marshal.AllocHGlobal(Marshal.SizeOf<LineItem>());

                Marshal.StructureToPtr<LineItem>(lineItems[i], lineItemPointers[i], false);
            }

            var handle = GCHandle.Alloc(lineItemPointers, GCHandleType.Pinned);

            var result = UnmanagedProxy.GetTotalCost(handle.AddrOfPinnedObject(), lineItems.Length);

            handle.Free();

            Console.WriteLine("Total Cost = {0}", result);
            Console.WriteLine("------------------------------");
        }

        static void GetCustomers()
        {
            var totalExpected = 2;

            var customerArrayPointer = UnmanagedProxy.GetCustomers();

            var pointers = new IntPtr[totalExpected];

            Marshal.Copy(customerArrayPointer, pointers, 0, totalExpected);

            for (var i = 0; i < totalExpected; i++)
            {
                var customer = Marshal.PtrToStructure<Customer>(pointers[i]);

                Console.WriteLine("First name: {0}", customer.FirstName);
                Console.WriteLine("Last name: {0}", customer.LastName);
                Console.WriteLine("Account number: {0}", customer.AccountNumber);
            }

            Console.WriteLine("------------------------------");
        }

        static void GetColumnTotal()
        {
            var totalRows = 9;

            var values = new int[totalRows];

            for (var i = 0; i < totalRows; i++)
            {
                values[i] = i + 1;
            }

            var handle = GCHandle.Alloc(values, GCHandleType.Pinned);

            var result = UnmanagedProxy.GetColumnTotal(handle.AddrOfPinnedObject(), totalRows);

            handle.Free();

            Console.WriteLine(result);
            Console.WriteLine("------------------------------");
        }

        static void GetRowTotals()
        {
            var totalRows = 3;
            var totalColumns = 3;

            var values = new int[totalRows, totalColumns];

            values[0, 0] = 1;
            values[0, 1] = 2;
            values[0, 2] = 3;

            values[1, 0] = 4;
            values[1, 1] = 5;
            values[1, 2] = 6;

            values[2, 0] = 7;
            values[2, 1] = 8;
            values[2, 2] = 9;

            var handle = GCHandle.Alloc(values, GCHandleType.Pinned);

            var pointer = UnmanagedProxy.GetRowTotals(handle.AddrOfPinnedObject(), totalRows, totalColumns);

            handle.Free();

            var rowValues = new int[totalRows];

            Marshal.Copy(pointer, rowValues, 0, totalRows);

            foreach (var item in rowValues)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------------------");
        }
    }
}
