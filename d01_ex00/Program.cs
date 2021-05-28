using System;
using System.Collections.Generic;

// validation(args);

string folder = args[1];
string init_sum = args[0];
Exchanger inst = new Exchanger(folder);
// ExchangeSum ex = new ExchangeSum(args[0]);
// Console.WriteLine($"sum: {ex.Sum}\nid: {ex.ID}");
List<ExchangeSum> exchangesums = inst.Convert(init_sum);
{Console.WriteLine($"Сумма в исходной валюте: {exchangesums[0].ToString()}");
    for (int i = 1; i < exchangesums.Count; i++)
    {
        Console.WriteLine($"Сумма в {exchangesums[i].ID}: {exchangesums[i].ToString()}");
    }
}