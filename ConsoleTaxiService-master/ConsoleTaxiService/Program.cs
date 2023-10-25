using Core;

internal class Program
{
    private static void Main(string[] args)
    {
        TaxiService taxiService = new TaxiService();
        taxiService.InputAddresses();
        taxiService.AcceptOrder();
    }
}