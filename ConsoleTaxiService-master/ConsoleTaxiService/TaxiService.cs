namespace Core;

internal class TaxiService
{
    private string _inputFromAddress;
    private string _inputToAddress;

    private Random _random = new Random();
    private const float DISTANCE_CORRECTOR = 1.75f;
    private LoadFactorTypes _loadFactor = LoadFactorTypes.Small;
    private const float LOAD_FACTOR_CORRECTOR = 2;
    private int _minimumPrice = 400;
    private Driver[] _drivers = new Driver[]
    {
        new Driver("Дархан", "Tesla", "черный", "707AGA06"),
        new Driver("Нурхан", "Camry", "белый", "777XAN06"),

    };

    public float Distance
    {
        get
        {
            float distance = _random.Next(0, 6) + _random.NextSingle();
            return (float)Math.Round(distance, 2);
        }
    }
    public int Price
    {
        get
        {
            int price = (int)(Distance / DISTANCE_CORRECTOR * (int)_loadFactor * _minimumPrice);
            price = price <= _minimumPrice ? _minimumPrice : price;
            return price;
        }
    }
    public float LoadFactor => (float)_loadFactor / LOAD_FACTOR_CORRECTOR;
    public Driver RandomDriver => _drivers[_random.Next(0, _drivers.Length)];
    public void InputAddresses()
    {
        Console.Write("Введите адрес откуда: ");
        _inputFromAddress = Console.ReadLine();
        Console.Write("Введите адрес куда: ");
        _inputToAddress = Console.ReadLine();
    }

    public void AcceptOrder()
    {
        Console.WriteLine("Ваш заказ принят!");
        Console.WriteLine($"Вы поедите с {_inputFromAddress} до {_inputToAddress}, расстояние {Distance}км");
        Console.WriteLine($"Стоимость поездки {Price} тг.");
        Driver driver = RandomDriver;
        Console.WriteLine($"Ваш водитель {driver.Name}, {driver.CarColor} {driver.CarBrand}, с номером {driver.CarNumber} прибудет через {_random.Next(0, 5)} мин.");

    }

}
enum LoadFactorTypes
{
    None = 1,
    Small = 3,
    Medium = 4,
    High = 5

}