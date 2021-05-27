using System;

public struct ExchangeSum
{
    private double _Sum;
    private string _ID;
    // private string[] _atrs;

    public ExchangeSum(string value)
    {
        string[] _atrs = value.Split(" ");
        _Sum = double.Parse(_atrs[0]);
        _ID = _atrs[1];
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
        double sum_2 = Math.Round(Sum, 2);
        string ret = sum_2.ToString();
        ret += " ";
        ret += _ID;
        return ret;
    }
}