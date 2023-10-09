namespace LernerCovid_19;

public sealed class VaccineConveyor
{
    public int _n { get; set; }
    public int _entranceA { get; set; }
    public int _entranceB { get; set; }
    public int _exitA { get; set; }
    public int _exitB { get; set; }
    public int[,] _Stages { get; set; }
    public int[,] _DevelopmentTime { get; set; }

    public VaccineConveyor(int n, int entranceA, int entranceB, int exitA, int exitB, int[,] Stages, int[,] DevelopmentTime)
    {
        _n = n;
        _entranceA = entranceA;
        _entranceB = entranceB;
        _exitA = exitA;
        _exitB = exitB;
        _Stages = Stages;
        _DevelopmentTime = DevelopmentTime;
    }

    public void GetVaccineProductionTime()
    {
        string stageRoadmapA = string.Empty;
        string stageRoadmapB = string.Empty;
        int[] stageFinishTimeA = new int[_n];
        int[] stageFinishTimeB = new int[_n];
        string temp;
        string start = "\nCбор информации о COVID-19 (Стадия 1)";

        stageFinishTimeA[0] = _entranceA + _Stages[0, 0];
        stageRoadmapA += start + " >> НИЦЭМ им. Н. Ф. Гамалеи (Стадия 2) >>";

        stageFinishTimeB[0] = _entranceB + _Stages[1, 0];
        stageRoadmapB += start + " >> ФНЦИРИП им. М. П. Чумакова (Стадия 2) >>";

        for (int i = 1; i < _n; i++)
        {
            int circleA1 = stageFinishTimeA[i - 1] + _Stages[0, i];
            int circleB1 = stageFinishTimeB[i - 1] + _DevelopmentTime[1, i] + _Stages[0, i];
            stageFinishTimeA[i] = Math.Min(circleA1, circleB1);
            if (circleA1 <= circleB1)
            {
                temp = stageRoadmapA;
                stageRoadmapA += " НИЦЭМ им. Н. Ф. Гамалеи (Стадия " + (i + 2) + ") >> ";
            }
            else
            {
                temp = stageRoadmapA;
                stageRoadmapA = stageRoadmapB + " Передача наработок в НИЦЭМ им. Н. Ф. Гамалеи и работа над (Стадия " + (i + 2) + ") >> ";
            }
            int circleA2 = stageFinishTimeB[i - 1] + _Stages[1, i];
            int circleB2 = stageFinishTimeA[i - 1] + _DevelopmentTime[0, i] + _Stages[1, i];
            stageFinishTimeB[i] = Math.Min(circleA2, circleB2);
            if (circleA2 <= circleB2)
            {
                stageRoadmapB += " ФНЦИРИП им. М. П. Чумакова (Стадия " + (i + 2) + ") >> ";
            }
            else
            {
                stageRoadmapB = temp + " Передача наработок в ФНЦИРИП им. М. П. Чумакова и работа над (Стадия " + (i + 2) + ") >> ";
            }
        }
        stageRoadmapA += " Начало массового прививания людей вакциной \"Спутник V\"";
        stageRoadmapB += " Начало массового прививания людей вакциной \"КовиВак\"";

        string resume1 = "\nМинимальное время разработки и иследования вакцины от COVID-19 составляет ";
        string resume2 = "Путь к такому результату: ";

        if ((stageFinishTimeA[_n - 1] + _exitA) < (stageFinishTimeB[_n - 1] + _exitB))
        {
            Console.WriteLine(resume1 + (stageFinishTimeA[_n - 1] + _exitA) + " мес");
            Console.WriteLine(resume2 + stageRoadmapA);
        }
        else
        {
            Console.WriteLine(resume1 + (stageFinishTimeB[_n - 1] + _exitB) + " мес");
            Console.WriteLine(resume2 + stageRoadmapB);
        }
    }
}
