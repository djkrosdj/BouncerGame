using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Класс предоставляющий цвет из массива цветов
/// </summary>
[Serializable]
public class ColorsProvider
{
    [SerializeField] private Color[] _colors;

    /// <summary>
    /// Получить случайный цвет
    /// </summary>
    /// <returns>Возвращает случайно сгенерированный цвет</returns>
    public Color GetRandomColor()
    {
        // Генерируем случайный индекс из массива заданных цветов.

        var randomIndex = Random.Range(0, _colors.Length);

        return _colors[randomIndex];
    }
}