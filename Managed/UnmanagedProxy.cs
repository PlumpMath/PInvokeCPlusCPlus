namespace Managed
{
    using System;
    using System.Runtime.InteropServices;

    public static class UnmanagedProxy
    {
        [DllImport("Unmanaged.dll", EntryPoint = "add", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int parm1, int parm2);
    }
}
