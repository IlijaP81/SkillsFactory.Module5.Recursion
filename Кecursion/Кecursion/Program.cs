
using Recursion;


class MainClass
{
    static void Main(string[] args)
    {
        string phrase; int deep;
        phrase = DoCheckPhrase();
        DoCheckDeep(out deep);
        Echo(phrase, deep);

        int powerUp = PowerUp(9, 3);
        Console.WriteLine(powerUp.ToString());
    }

    private static string DoCheckPhrase()
    {
        Console.WriteLine("Введите фразу (более 2-х символов:");
        string phrase = Console.ReadLine();
        if (phrase.Length < 2)
        {
            Console.WriteLine("Фраза содержит менее 2-х символов");
            DoCheckPhrase();
        }
        return phrase;
    }

    private static void DoCheckDeep(out int deep)
    {
        deep = 0;
        int numberOfColors = Enum.GetNames(typeof(ColorsSet)).Length - 1;
        Console.WriteLine("Определите глубину (целое число, не более " + numberOfColors);
        try
        {
            deep = int.Parse(Console.ReadLine());
            if (deep > numberOfColors) deep = numberOfColors;
        }
        catch
        {
            Console.WriteLine("Введите целое число не более " + numberOfColors);
            DoCheckDeep(out deep);
        }
        return;
    }

    static void Echo(string message, int numOfIterations)
    {
        string messageCropped = message.Remove(0, 2);
        Console.BackgroundColor = (ConsoleColor)(Enum.GetValues(typeof(ColorsSet)).GetValue(numOfIterations));
        Console.WriteLine("..." + messageCropped);
        if (messageCropped.Length > 2 & numOfIterations > 1)
        {
            numOfIterations--;
            Echo(messageCropped, numOfIterations);
        }
        else return;
    }

    private static int PowerUp(int N, byte pow)
    {
        if (pow == 0)
        {
            return 1;
        }
        else
        {
            if (pow == 1)
            {
                return N;
            }
            else
            {
                return N * PowerUp(N, --pow);
            }
        }
    }
}
