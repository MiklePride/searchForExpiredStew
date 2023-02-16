using System;
using System.Collections.Generic;
using System.Linq;

namespace searchForExpiredStew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.ShowAllExpiredGoods();

            Console.ReadLine();
        }
    }
}

class Warehouse
{
    private List<Stew> _stew = new List<Stew>();

    private int _dataNow = 2023;

    public Warehouse() 
    {
        int stewCount = 25;

        for (int i = 0; i < stewCount; i++)
        {
            _stew.Add(new Stew());
        }
    }

    public void ShowAllExpiredGoods()
    {
        var expiredGoods = _stew.Where(stew => stew.YearOfProduction + stew.ShelfLife <= _dataNow);

        foreach (var stew in expiredGoods) 
        {
            stew.ShowInfo();
        }
    }
}

class Stew
{
    private static Random _random = new Random();

    private string _name;

    public Stew()
    {
        string[] nameProduct = { "Свинина тушеная", "Курица тушеная", "Говядина тушеная" };

        int minimumYearOfProduction = 1999;
        int maximumYearOfProduction = 2024;

        _name = nameProduct[_random.Next(nameProduct.Length)];
        YearOfProduction = _random.Next(minimumYearOfProduction, maximumYearOfProduction);
        ShelfLife = 2;
    }

    public int YearOfProduction { get; private set; }
    public int ShelfLife { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Название: {_name} | Год производства: {YearOfProduction} | Срок годности: {ShelfLife}");
    }
}
