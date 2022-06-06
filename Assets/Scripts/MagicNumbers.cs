using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    public int Min = 1;
    public int Max = 1000;
    public TextMeshProUGUI InfoLabel;
    public TextMeshProUGUI GuessLabel;
    public TextMeshProUGUI CounterLabel;
    public string SceneLabel;
    public Button MoreButton;
    public Button LessButton;
    public Button FinishButton;

    private int _guess;
    private int _counter = 0;
    private bool _isGameOver;
    private int _minReset;
    private int _maxReset;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _minReset = Min;
            _maxReset = Max;
            SetDefaultValues();
        }
    }

    private void Start()
    {
        MoreButton.onClick.AddListener(MoreButtonClicked);
        LessButton.onClick.AddListener(LessButtonClicked);
        FinishButton.onClick.AddListener(FinishButtonClicked);
        _minReset = Min;
        _maxReset = Max;
        SetDefaultValues();
    }

    #endregion


    #region Private methods

    private void CalculateGuess()
    {
        _guess = (_minReset + _maxReset) / 2;
        _counter++;
        SetGuessText($"Твое число {_guess}?");
        SetCounterText("С какой попытки угадаем число?");
    }

    private void SetInfoText(string text)
    {
        InfoLabel.text = text;
    }

    private void SetGuessText(string text)
    {
        GuessLabel.text = text;
    }

    private void SetCounterText(string text)
    {
        CounterLabel.text = text;
    }

    private void MoreButtonClicked()
    {
        if (_isGameOver)
            return;
        SetInfoText("Число больше");
        _minReset = _guess;
        CalculateGuess();
    }

    private void FinishButtonClicked()
    {
        if (_isGameOver)
            return;
        SetInfoText("Ура! Число угадали!");
        SetGuessText($"Поздравляю, твое число {_guess}");
        SetCounterText($"Число угадано с {_counter} попытки");
        _isGameOver = true;
        this.Wait(2f, () => { SceneLoader.Instance.Load(SceneLabel); });
    }

    private void LessButtonClicked()
    {
        if (_isGameOver)
            return;
        SetInfoText("Число меньше");
        _maxReset = _guess;
        CalculateGuess();
    }

    private void SetDefaultValues()
    {
        SetInfoText($"Загадай число от {_minReset} до {_maxReset}.");
        _counter = 0;
        CalculateGuess();
        _isGameOver = false;
    }

    #endregion
}