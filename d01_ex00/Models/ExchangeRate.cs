public struct ExchangeRate
{
    private readonly string _ID_from;
    private readonly string _ID_to;
    private readonly double _rate;

    public ExchangeRate(string from, string to_and_rate)
    {
        _ID_from = from;
        string[] atrs = to_and_rate.Split(":");
        _ID_to = atrs[0];
        atrs[1] = atrs[1].Replace(',', '.');
        _rate = double.Parse(atrs[1]);
    }

    public string   ID_from
    {
        get => _ID_from;
    }
    public string   ID_to
    {
        get => _ID_to;
    }
    public double   rate
    {
        get => _rate;
    }
}