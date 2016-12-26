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
    }
}
