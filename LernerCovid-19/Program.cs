using LernerCovid_19;

Console.Write("Сколько стадий разработки и клинических исследований должна пройти вакцина? (Ваше число + 2 стадии) ");
int n = int.Parse(Console.ReadLine());

Console.Write("Время, которое понадобиться НИЦЭМ им. Н. Ф. Гамалеи для сбора информации о COVID-19 (Стадия 1): ");
int entranceA = int.Parse(Console.ReadLine());

Console.Write("Время, которое понадобиться ФНЦИРИП им. М. П. Чумакова для сбора информации о COVID-19 (Стадия 1): ");
int entranceB = int.Parse(Console.ReadLine());

int[,] Stages = new int[2, n];
int[,] DevelopmentTime = new int[2, n];

for (int i = 0; i < n; i++)
{
    Console.Write("Время длительности стадии " + (i + 2) + " в НИЦЭМ им. Н. Ф. Гамалеи: ");
    Stages[0, i] = int.Parse(Console.ReadLine());

    Console.Write("Время длительности стадии " + (i + 2) + " в ФНЦИРИП им. М. П. Чумакова: ");
    Stages[1, i] = int.Parse(Console.ReadLine());

    if (i > 0)
    {
        Console.Write("Время передачи наработок в НИЦЭМ им. Н. Ф. Гамалеи (Стадия " + (i + 2) + "): ");
        DevelopmentTime[1, i] = int.Parse(Console.ReadLine());

        Console.Write("Время передачи наработок в ФНЦИРИП им. М. П. Чумакова (Стадия " + (i + 2) + "): ");
        DevelopmentTime[0, i] = int.Parse(Console.ReadLine());
    }
}
Console.Write("Массовое производство вакцины в НИЦЭМ им. Н. Ф. Гамалеи (Последняя стадия): ");
int exitA = int.Parse(Console.ReadLine());

Console.Write("Массовое производство вакцины в ФНЦИРИП им. М. П. Чумакова (Последняя стадия): ");
int exitB = int.Parse(Console.ReadLine());

VaccineConveyor vaccineConveyor = new VaccineConveyor(n, entranceA, entranceB, exitA, exitB, Stages, DevelopmentTime);
vaccineConveyor.GetVaccineProductionTime();