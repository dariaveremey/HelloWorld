using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MagicNumbers : MonoBehaviour
{
    public int Min;
    public int Max;
    public TextMeshProUGUI InfoLabel;
    public TextMeshProUGUI GuessLabel;
    public TextMeshProUGUI CounterLabel;
    public Button MoreButton;
    public Button LessButton;
    public Button FinishButton;

    private int _guess;
    private int _counter=0;

    private void Options()
    {
        SetInfoText($"Загадай число от {Min} до {Max}.");
        _counter = 0;
        CalculateGuess();
    }
        
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Min = 0;
            Max = 1000;
            Options();
        }
    }

    void Start()
    {
        MoreButton.onClick.AddListener(MoreButtonClicked);
        LessButton.onClick.AddListener(LessButtonClicked);
        FinishButton.onClick.AddListener(FinishButtonClicked);
        
        Options();
    }

    private void CalculateGuess()
    {
        _guess = (Min + Max) / 2; 
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
        SetInfoText("Число больше");
        Min = _guess;
        CalculateGuess();
    }

    private void FinishButtonClicked()
    {
        SetInfoText("Ура! Число угадали!");
        SetGuessText($"Поздравляю, твое число {_guess}");
        SetCounterText($"Число угадано с {_counter} попытки");
    }

    private void LessButtonClicked()
    {
        SetInfoText("Число меньше");
        Max = _guess;
        CalculateGuess();
    }
}