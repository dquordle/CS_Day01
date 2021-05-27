using System;
using System.Collections.Generic;

// validation(args);

Exchanger inst = new Exchanger(args[1]);
// ExchangeSum ex = new ExchangeSum(args[0]);
// Console.WriteLine($"sum: {ex.Sum}\nid: {ex.ID}");
List<ExchangeSum> exchangesums = inst.Convert(args[0]);
{Console.WriteLine($"Сумма в исходной валюте: {exchangesums[0].ToString()}");
    for (int i = 1; i < exchangesums.Count; i++)
    {
        Console.WriteLine($"Сумма в {exchangesums[i].ID}: {exchangesums[i].ToString()}");
    }
}