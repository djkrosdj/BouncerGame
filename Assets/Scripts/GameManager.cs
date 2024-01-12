using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Класс управляющий запуском игры
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private ColorsProvider _colorsProvider;

    [SerializeField] private ObjectSpawner _objectSpawner;

    [SerializeField] private PositionGenerator _positionGenerator;

    private void Awake()
    {
        _positionGenerator.Initialize();                    // Инициализируем данные генератора случайных точек
        _objectSpawner.SpawnObjects(_colorsProvider);       // Спавним объекты - подарки
        _objectSpawner.SpawnObject(_colorsProvider);        // Спавним объект - конфета которая перекрашивает Player
    }
}