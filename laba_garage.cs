using System;
using System.Collections.Generic;

namespace AMOGUS
{
    public class Car
    {
        public string brand;
        public string number;
        public bool purity;
    }

    public class Garage
    {
        public List<Car> cars = new List<Car>();

        public void AddCar(Car car)
        {
            cars.Add(car);
        }
        public void RemoveCar(int num)
        {
            Random m = new Random();
            int number = m.Next(0, num);
            Car car1 = cars[number];
            Console.WriteLine($"Вы зачем-то выкинули {car1.brand} под номером {car1.number}");
            cars.Remove(car1);
        }

    }

    public class CarWash
    {
        private Garage garage;
        public CarWash(Garage garage)
        {
            this.garage = garage;
        }
        public void Wash(int num)
        {
            Random m = new Random();
            int number = m.Next(0, num);
            Car car = garage.cars[number];
            if (car.purity == false)
            {
                Console.WriteLine($"Помыли машину {car.brand} номер: {car.number}");
                car.purity = true;
            }
            else
            {
                Console.WriteLine($"Зачем-то ещё раз помыли {car.brand} под номером {car.number}....");
            }
        }
        public void WashAllCars(Garage garage)
        {
            foreach (Car cary in garage.cars)
            {
                cary.purity = true;
            }
            Console.WriteLine("Поздавляю, все машины помыты!");
        }

        internal class Program
        {
            static void Main()
            {
                string[] avaibleBrands = { "Skoda", "Lada", "Vaz", "Toyota", "Volvo", "Honda", "Scania", "Schevrolet", "Renault", "MAN", "Mercedes", "Hyundai" };
                Garage garage = new Garage();
                CarWash carwash = new CarWash(garage);
                Console.WriteLine("Сколько в гараже машин ?"); int num = int.Parse(Console.ReadLine());
                string numbery = "";
                Random m = new Random();
                Random n = new Random();
                for (int i = 0; i < num; i++)
                {
                    string res = "";
                    int nInt = n.Next(0, avaibleBrands.Length - 1);
                    for (int j = 0; j <= 5; j++)
                    { 
                        int mInt = m.Next(0, 9);
                        res += Convert.ToString(mInt);
                    }
                    numbery = res;
                    Car car = new Car { brand = avaibleBrands[nInt], number = numbery, purity = false };
                    garage.AddCar(car);
                    numbery = "";
                }

                Console.WriteLine("Теперь у вас в гараже " + Convert.ToString(num) + " машин. Ваши следующие действия ?");

                while (true)
                {
                    Console.WriteLine("1. Вымыть рандомную машину");
                    Console.WriteLine("2. Вымыть все машины");
                    Console.WriteLine("3. Выкинуть рандомную машину");
                    Console.WriteLine("4. Вывести список машин в гараже");

                    string key = Console.ReadLine();
                    switch (key)
                    {
                        case "1": carwash.Wash(num); break;
                        case "2": carwash.WashAllCars(garage); break;
                        case "3": garage.RemoveCar(num); num--; break;
                        case "4": Printer(garage); break;
                    }
                }
            }

            static void Printer(Garage garage)
            {
                foreach(Car car in garage.cars)
                {
                    if (car.purity == true)
                    {
                        Console.WriteLine($"Автомобиль {car.brand} под номером {car.number}, чистая");
                    }
                    else
                    {
                        Console.WriteLine($"Автомобиль {car.brand} под номером {car.number}, грязная");
                    }
                }
            }
        }
    }
}
