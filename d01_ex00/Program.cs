using System;
using System.Collections.Generic;
using System.IO;

Return Validation(string[] args)
{
    if (args.Length != 2)
        return Return.Error;

    string[] firstArg = args[0].Split(" ");
    
    if (firstArg.Length != 2 || !double.TryParse(firstArg[0], out double sum))
        return Return.Error;
    if (!Directory.Exists(args[1]))
        return Return.Error;
    return Return.Success;
}

Return valid = Validation(args);
if (valid == Return.Error)
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
else
{
    string folder = args[1];
    string init_sum = args[0];
    Exchanger exchanger = new Exchanger(folder);
    List<ExchangeSum> exchangesums = exchanger.Convert(init_sum);
    {
        Console.WriteLine($"Сумма в исходной валюте: {exchangesums[0].ToString()}");
        for (int i = 1; i < exchangesums.Count; i++)
        {
            Console.WriteLine($"Сумма в {exchangesums[i].ID}: {exchangesums[i].ToString()}");
        }
    }
}

public enum Return
{
    Success,
    Error
};
