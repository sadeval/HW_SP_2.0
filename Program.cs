using System;
using System.Threading;

class Program
{
    static void TemperatureSensor(object roomNumber)
    {
        Random random = new Random();
        while (true)
        {
            int temperature = random.Next(-10, 36);
            Console.WriteLine($"Комната {roomNumber}: Температура = {temperature}°C");

            Thread.Sleep(1000);
        }
    }

    static void Main()
    {
        Console.Write("Введите количество комнат (потоков): ");
        int numRooms = int.Parse(Console.ReadLine());

        Console.Write("Введите время работы программы (в секундах): ");
        int workTime = int.Parse(Console.ReadLine());

        Thread[] threads = new Thread[numRooms];

        for (int i = 0; i < numRooms; i++)
        {
            threads[i] = new Thread(new ParameterizedThreadStart(TemperatureSensor));
            threads[i].Start(i + 1); 
        }

        Thread.Sleep(workTime * 1000);

        for (int i = 0; i < numRooms; i++)
        {
            threads[i].Interrupt();
        }

        Console.WriteLine("Программа завершена.");
    }
}
