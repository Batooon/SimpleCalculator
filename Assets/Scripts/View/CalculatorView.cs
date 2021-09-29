//Author: Anton Rozum
using System.Globalization;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField] private Color _defaultBgColor;
        [SerializeField] private Color _alertBgColor;
        [SerializeField] private Image _background;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private string _errorText;
        private CalculatorViewModel _calculatorViewModel;

        public void Init(CalculatorViewModel viewModel)
        {
            _calculatorViewModel = viewModel;
            OnModelChanged();
        }

        private void OnEnable()
        {
            _calculatorViewModel.Changed += OnModelChanged;
            _calculatorViewModel.ResultChanged += OnResultChanged;
            OnModelChanged();
        }

        private void OnDisable()
        {
            _calculatorViewModel.Changed -= OnModelChanged;
            _calculatorViewModel.ResultChanged -= OnResultChanged;
        }

        private void OnResultChanged()
        {
            var value = _calculatorViewModel.LatestResult;
            var result = value.ToString(CultureInfo.InvariantCulture);
            _inputField.text = result;
        }

        private void OnModelChanged()
        {
            var expression = _calculatorViewModel.Expression;
            var validExpression = _calculatorViewModel.ExpressionValid;
            _background.color = validExpression ? _defaultBgColor : _alertBgColor;
            _inputField.text = validExpression ? expression : _errorText;
        }
    }
}