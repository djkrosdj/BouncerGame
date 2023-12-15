using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Класс генерирующий случайную точку на игровом пространстве
/// </summary>
public class PositionGenerator : MonoBehaviour
{
    private Vector3 _minBounds; // Минимальные границы объекта GameBoard
    private Vector3 _maxBounds; // Максимальные границы объекта GameBoard

    private void Awake()
    {
        CalculateBounds();
    }

    /// <summary>
    /// Метод вычисления размера поля для спавна
    /// </summary>
    private void CalculateBounds()
    {
        Renderer planeRenderer = GetComponent<Renderer>();
        if (planeRenderer != null)
        {
            _minBounds = planeRenderer.bounds.min;
            _maxBounds = planeRenderer.bounds.max;
        }
    }

    /// <summary>
    /// Метод генерирующий случайную точку для спавна объекта
    /// </summary>
    /// <returns>Возвращает координаты точки спавна</returns>
    public Vector3 GetRandomPointOnGameBoard()
    {
        // Получаем случайные координаты в пределах границ объекта GameBoard
        float randomX = Random.Range(_minBounds.x + 0.6f, _maxBounds.x - 0.6f);
        float randomZ = Random.Range(_minBounds.z + 0.6f, _maxBounds.z - 0.6f);
        
        // Создаем вектор со случайными координатами, но с фиксированной y-координатой (высотой плоскости)
        Vector3 randomPoint = new Vector3(randomX, transform.position.y, randomZ);

        return randomPoint;
    }
}