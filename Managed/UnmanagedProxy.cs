namespace Managed
{
    using System;
    using System.Runtime.InteropServices;

    public static class UnmanagedProxy
    {
        [DllImport("Unmanaged.dll", EntryPoint = "add", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int parm1, int parm2);

        [DllImport("Unmanaged.dll", EntryPoint = "sum", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Sum(Parameters parameters);

        [DllImport("Unmanaged.dll", EntryPoint = "getParameters", CallingConvention = CallingConvention.Cdecl)]
        public static extern Parameters GetParameters();

        [DllImport("Unmanaged.dll", EntryPoint = "getGreeting", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetGreeting();

        [DllImport("Unmanaged.dll", EntryPoint = "getCost", CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetCost(LineItem lineItem);

        [DllImport("Unmanaged.dll", EntryPoint = "getTotalCost", CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetTotalCost(IntPtr lineItems, int totalLineItems);

        [DllImport("Unmanaged.dll", EntryPoint = "getCustomers", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetCustomers();

        [DllImport("Unmanaged.dll", EntryPoint = "getRowTotals", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetRowTotals(IntPtr array, int totalRows, int totalColumns);
    }
}
