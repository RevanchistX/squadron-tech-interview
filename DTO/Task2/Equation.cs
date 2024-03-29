﻿using System.Data;
using Squadron.Services;

namespace Squadron.DTO.Task2;

public class Equation(int id, double firstItem, string operand, double secondItem, double result)
{
    public int Id { get; set; } = id;
    public double FirstItem { get; set; } = firstItem;
    public string Operand { get; set; } = operand;
    public double SecondItem { get; set; } = secondItem;

    public double Result { get; set; } = result;


    public double Evaluate()
    {
        return Convert.ToDouble(new DataTable().Compute(FirstItem + Operand + SecondItem, null));
    }

    public static bool EvaluateById(int id, double value)
    {
        var equations = DbService.LoadDbFile<Equation>("/Task2/dbEquations.json", out string equationsDbFilePath);
        return equations.Find(eq => eq.Id == id).Evaluate().Equals(value);
    }

    public string CompileExpression()
    {
        return FirstItem + " " + Operand + " " + SecondItem + " = " + Result;
    }
}