//Author: Anton Rozum
using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Models;
using UnityEngine;

namespace Logic
{
    public class Calculator : MonoBehaviour
    {
        private CalculatorViewModel _calculatorViewModel;

        public void Init(CalculatorViewModel viewModel)
        {
            _calculatorViewModel = viewModel;
        }

        public void Clear()
        {
            _calculatorViewModel.Expression = string.Empty;
            _calculatorViewModel.ExpressionValid = true;
        }

        public void UpdateInput(string value)
        {
            _calculatorViewModel.Expression += value;
        }

        public void OnInputFieldEndEdit(string inputField)
        {
            _calculatorViewModel.Expression = inputField;
            CheckValidation();
        }

        public void TryCompute()
        {
            if (ValidateInput() == false)
            {
                _calculatorViewModel.ExpressionValid = false;
                return;
            }

            bool success;
            var value = 0d;
            try
            {
                var result = new DataTable().Compute(_calculatorViewModel.Expression, null);
                value = Convert.ToDouble(result);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }

            _calculatorViewModel.ExpressionValid = success;
            if (success==false)
                return;
            _calculatorViewModel.Expression = value.ToString(CultureInfo.InvariantCulture);
            _calculatorViewModel.LatestResult = value;

        }

        private void CheckValidation()
        {
            if (_calculatorViewModel.ExpressionValid == false)
                _calculatorViewModel.ExpressionValid = ValidateInput();
        }

        private bool ValidateInput()
        {
            var r = new Regex(@"^\d+[.]?\d*[\+\*\/\-]\d+[.]?\d*$",
                RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
            return r.IsMatch(_calculatorViewModel.Expression);
        }
    }
}