namespace Managed
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
