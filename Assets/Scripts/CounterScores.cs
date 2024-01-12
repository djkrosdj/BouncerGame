using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textRedPresent;
    [SerializeField] private TextMeshProUGUI _textGreenPresent;
    [SerializeField] private TextMeshProUGUI _textBluePresent;
    [SerializeField] private TextMeshProUGUI _textPlayer;

    private static int _redCounter;
    private static int _greenCounter;
    private static int _blueCounter;
    private static int _playerStepCounter;
    
    void Update()
    {
        _textRedPresent.text = _redCounter.ToString();
        _textGreenPresent.text = _greenCounter.ToString();
        _textBluePresent.text = _blueCounter.ToString();
        _textPlayer.text = _playerStepCounter.ToString();
    }

    public static void IncreaseColorCounter(Color color)
    {
        if (color==Color.red)
        {
            _redCounter++;
        }

        if (color == Color.green)
        {
            _greenCounter++;
        }

        if (color == Color.blue)
        {
            _blueCounter++;
        }
    }
    
    public static void DecreaseColorCounter(Color color)
    {
        if (color==Color.red)
        {
            _redCounter--;
        }

        if (color == Color.green)
        {
            _greenCounter--;
        }

        if (color == Color.blue)
        {
            _blueCounter--;
        }
    }

    public static void IncreaseStepCounter()
    {
        _playerStepCounter++;
    }
    
}
