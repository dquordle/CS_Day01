using System;
using System.Collections.Generic;
using System.IO;

public class Exchanger
{
    private List<ExchangeRate> Rates;

    public Exchanger(string folder)
    {
        Rates = new List<ExchangeRate>();
        string[] files = Directory.GetFiles(folder);
        foreach (var file in files)
        {
            string[] lines = File.ReadAllLines(file);
            string idFrom = file.Substring(folder.Length + 1);
            idFrom = idFrom.Remove(idFrom.Length - 4);
            foreach (var line in lines)
            {
                ExchangeRate exchRate = new ExchangeRate(idFrom, line);
                Rates.Add(exchRate);
            }
        }
    }

    public List<ExchangeSum> Convert(string initStr)
    {
        List<ExchangeSum> exchangeSums = new List<ExchangeSum>()
        {
            new ExchangeSum(initStr)
        };
        string[] atrs = initStr.Split(" ");
        double initSum = double.Parse(atrs[0]);
        string initId = atrs[1];
        for (int i = 0; i < Rates.Count; i++)
        {
            if (Rates[i].ID_from == initId)
            {
                ExchangeSum exchangeSum = new ExchangeSum(Rates[i].ID_to, initSum * Rates[i].rate);
                exchangeSums.Add(exchangeSum);
            }
        }
        return exchangeSums;
    }
}