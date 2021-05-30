using System;

public struct ExchangeSum
{
    private double _Sum;
    private string _ID;
    public ExchangeSum(string value)
    {
        string[] atrs = value.Split(" ");
        _Sum = double.Parse(atrs[0]);
        _ID = atrs[1];
    }

    public ExchangeSum(string id, double sum)
    {
        _ID = id;
        _Sum = sum;
    }
    public double Sum
    {
        get => _Sum;
    }

    public string ID
    {
        get => _ID;
    }

    public override string ToString()
    {
        return $"{_Sum:N2} {_ID}";
    }
}