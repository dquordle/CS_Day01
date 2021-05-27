using System;
using System.Collections.Generic;
using System.IO;

public class Exchanger
{
    private string value;
    private string path_to_file;
    private List<ExchangeRate> Rates;

    public Exchanger(string path_to_folder)
    {
        if (!Directory.Exists(path_to_folder)) // Move that to validation function
        {
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
            return;
        }
        else
        {
            Rates = new List<ExchangeRate>();
            string[] files = Directory.GetFiles(path_to_folder);
            foreach (var file in files)
            {
                string[] lines = File.ReadAllLines(file);
                string id_from = file.Substring(path_to_folder.Length + 1);
                id_from = id_from.Remove(id_from.Length - 4);
                foreach (var line in lines)
                {
                    ExchangeRate exch_rate = new ExchangeRate(id_from, line);
                    Rates.Add(exch_rate);
                }
            }
        }
    }

    public List<ExchangeSum> Convert(string init_str)
    {
        List<ExchangeSum> exchangeSums = new List<ExchangeSum>()
        {
            new ExchangeSum(init_str)
        };
        string[] atrs = init_str.Split(" ");
        double init_sum = double.Parse(atrs[0]);
        string init_id = atrs[1];
        for (int i = 0; i < Rates.Count; i++)
        {
            if (Rates[i].ID_from == init_id)
            {
                ExchangeSum exchangeSum = new ExchangeSum(Rates[i].ID_to, init_sum * Rates[i].rate);
                exchangeSums.Add(exchangeSum);
            }
        }

        return exchangeSums;
    }
}