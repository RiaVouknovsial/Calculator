//Написать программу которая будет сохранять историю математических 
//операций калькулятора в Json файл и  пользователь по желанию 
//может просмотреть все математические операции которые он проводил
//Калькулятор должен быть полностью реализован 

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

Calculator calculator = new Calculator();
string historyFilePath = "history.json";

calculator.LoadHistoryFromFile(historyFilePath);
calculator.Run();
calculator.SaveHistoryToFile(historyFilePath);


