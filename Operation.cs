class Operation
{
    public double Number1 { get; set; }
    public double Number2 { get; set; }
    public string OperationType { get; set; }
    public double Result { get; set; }

    public Operation(double number1, double number2, string operationType, double result)
    {
        Number1 = number1;
        Number2 = number2;
        OperationType = operationType;
        Result = result;
    }

    public override string ToString()
    {
        return $"{Number1} {OperationType} {Number2} = {Result}";
    }
}