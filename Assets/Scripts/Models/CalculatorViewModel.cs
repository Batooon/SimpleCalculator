//Author: Anton Rozum
using System;
using TMPro;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class CalculatorViewModel
    {
        public event Action Changed;
        public event Action ResultChanged;
        [SerializeField] private TMP_InputField _inputField;
        private CalculatorModel _model;
        private bool _expressionValid = true;

        public double LatestResult
        {
            get => _model.LatestResult;
            set
            {
                _model.LatestResult = value;
                ResultChanged?.Invoke();
            }
        }
    
        public string Expression
        {
            get => _model.Expression;
            set
            {
                _model.Expression = value;
                Changed?.Invoke();
            }
        }
        public bool ExpressionValid
        {
            get => _expressionValid;
            set
            {
                _expressionValid = value;
                Changed?.Invoke();
            }
        }

        public CalculatorViewModel(CalculatorModel model, TMP_InputField inputField)
        {
            _model = model;
            _inputField = inputField;
        }
    }
}