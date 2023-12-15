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

    private void Awake()
    {
        _objectSpawner.SpawnObjects(_colorsProvider);
        _objectSpawner.SpawnObject(_colorsProvider);
    }
}