using System;

class NextDayCalculator
{
    static void Main()
    {
        Console.Write("Введите день: ");
        int day = int.Parse(Console.ReadLine());

        Console.Write("Введите месяц: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Введите год: ");
        int year = int.Parse(Console.ReadLine());

        if (!IsValidDate(day, month, year))
        {
            Console.WriteLine("Ошибка: Некорректная дата.");
            return;
        }

        int daysInMonth = GetDaysInMonth(month, year);

        if (day < daysInMonth) 
        {
            day++;
        }
        else if (month < 12) 
        {
            day = 1;
            month++;
        }
        else 
        {
            day = 1;
            month = 1;
            year++;
        }

        Console.WriteLine($"Следующая дата: {day:D2}.{month:D2}.{year}");
    }

    static bool IsValidDate(int day, int month, int year)
    {
        if (year < 1 || month < 1 || month > 12 || day < 1)
            return false;

        int daysInMonth = GetDaysInMonth(month, year);
        return day <= daysInMonth;
    }

    static int GetDaysInMonth(int month, int year)
    {
        switch (month)
        {
            case 2: 
                return IsLeapYear(year) ? 29 : 28;
            case 4:
            case 6:
            case 9:
            case 11: 
                return 30;
            default: 
                return 31;
        }
    }

    static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}
