using System.Text.Json;

class Calculator
{
    public List<Operation> history;

    public Calculator()
    {
        history = new List<Operation>();
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Выберите опцию:");
            Console.WriteLine("1. Провести математическую операцию.");
            Console.WriteLine("2. Посмотреть историю математических операций.");
            Console.WriteLine("3. Выйти из программы.");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    PerformMathOperation();
                    break;
                case "2":
                    ViewHistory();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некорректный выбор опции. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }

    public void PerformMathOperation()
    {
        bool repeat = true;
        while (repeat)
        {
            double number1;
            double number2;
            string operation;
            try
            {
                Console.WriteLine("Введите первое число: ");
                number1 = GetNumberInput();
                Console.WriteLine("Введите второе число: ");
                number2 = GetNumberInput();
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный формат числа!");
                Console.ReadLine();
                continue;
            }

            Console.WriteLine("Выберите необходимую операцию: +, -, *, / ");
            operation = GetOperationInput();

            double result = PerformOperation(number1, number2, operation);
            Console.WriteLine("Результат: " + result);

            Operation currentOperation = new Operation(number1, number2, operation, result);
            history.Add(currentOperation);

            Console.WriteLine("Хотите ли вы провести еще одну математическую операцию? (да/нет)");
            string repeatChoice = Console.ReadLine();
            if (repeatChoice.ToLower() != "да")
            {
                repeat = false;
            }
        }
    }
    public double GetNumberInput()
    {
        double number;
        string input = Console.ReadLine();
        while (!double.TryParse(input, out number))
        {
            Console.WriteLine("Неправильный формат числа. Пожалуйста, введите число снова: ");
            input = Console.ReadLine();
        }
        return number;
    }
    public string GetOperationInput()
    {
        string operation = Console.ReadLine();
        while (operation != "+" && operation != "-" && operation != "*" && operation != "/")
        {
            Console.WriteLine("Неправильный формат операции. Пожалуйста, введите операцию снова: ");
            operation = Console.ReadLine();
        }
        return operation;
    }

    public double PerformOperation(double number1, double number2, string operation)
    {
        double result = 0;
        switch (operation)
        {
            case "+":
                result = number1 + number2;
                break;
            case "-":
                result = number1 - number2;
                break;
            case "*":
                result = number1 * number2;
                break;
            case "/":
                if (number2 == 0)
                    Console.WriteLine("На ноль делить нельзя ");
                else
                    result = number1 / number2;
                break;
            default:
                Console.WriteLine("Неизвестная операция ");
                break;
        }
        return result;
    }

    public void ViewHistory()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("История операций пуста");
            return;
        }

        Console.WriteLine("История операций:");
        foreach (Operation operation in history)
        {
            Console.WriteLine(operation.ToString());
        }
        Console.ReadLine();
    }

    public void SaveHistoryToFile(string filePath)
    {
        string json = JsonSerializer.Serialize(history);
        File.WriteAllText(filePath, json);
    }

    public void LoadHistoryFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            history = JsonSerializer.Deserialize<List<Operation>>(json);
        }
    }
}