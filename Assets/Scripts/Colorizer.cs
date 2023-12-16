using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    private ColorsProvider _colorsProvider;
    private Color _color;
    private Material _material;
    private PositionGenerator _positionGenerator;

    private void Awake()
    {
        // Ищем объект игрового поля который содержит генератор позиций
        var gameBoard = GameObject.Find(GlobalConstants.GAME_BOARD_TAG);
        _positionGenerator = gameBoard.GetComponent<PositionGenerator>();
    }

    private void Start()
    {
        SetColor(); // Задаем начальный цвет 
    }

    // Инициализация объекта цвета
    public void Initialize(ColorsProvider colorsProvider)
    {
        // Получаем провайдер цветов
        _colorsProvider = colorsProvider;

        // Получаем все материалы объекта, включая colored материал
        var materials = _renderer.materials;

        // Находим первый материал, содержащий ключевое слово в его имени
        _material = materials.First(material => material.name.Contains(GlobalConstants.COLORED_MATERIAL));

        // Сохраняем цвет
        _color = _material.color;
    }

    // Обработка столкновения с другим объектом
    private void OnTriggerEnter(Collider collider)
    {
        // Если попавший в триггер объект - это Player
        if (collider.TryGetComponent<PlayerColor>(out var player))
        {
            // Задаем игроку цвет конфеты
            player.SetColor(_color);

            // Задаем цвет
            SetColor();

            // Меняем позицию
            SetRandomPosition();
        }
    }

    // Устанавливаем случайный цвет объекта
    private void SetColor()
    {
        // Получаем случайный цвет из провайдера цветов
        var newColor = _colorsProvider.GetRandomColor();

        _material.color = newColor;  // Применяем новый цвет к материалу
        _color = newColor;           // Сохраняем текущий цвет
    }

    // Устанавливаем случайную позицию объекта
    private void SetRandomPosition()
    {
        // Получаем случайную позицию из PositionGenerator и устанавливаем её объекту
        Vector3 Position = _positionGenerator.GetRandomPointOnGameBoard();

        transform.position = Position;
    }
}