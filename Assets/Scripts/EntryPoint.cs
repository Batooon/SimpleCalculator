//Author: Anton Rozum
using Logic;
using Models;
using UnityEngine;
using TMPro;
using View;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Calculator _calculator;
    [SerializeField] private CalculatorView _calculatorView;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private string _expressionSaveKey;
    [SerializeField] private string _latestResultSaveKey;
    private CalculatorViewModel _viewModel;
    private CalculatorModel _model;

    private void Awake()
    {
        var expression = PlayerPrefs.GetString(_expressionSaveKey, string.Empty);
        var latestResult = (double)PlayerPrefs.GetFloat(_latestResultSaveKey, 0f);
        _model = new CalculatorModel(expression, latestResult);
        _viewModel = new CalculatorViewModel(_model, _inputField);
        _calculator.Init(_viewModel);
        _calculatorView.Init(_viewModel);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetString(_expressionSaveKey, _model.Expression);
        PlayerPrefs.SetFloat(_latestResultSaveKey, (float)_model.LatestResult);
    }
}