namespace Managed
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public class LineItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double SalesTax { get; set; }
    }
}
