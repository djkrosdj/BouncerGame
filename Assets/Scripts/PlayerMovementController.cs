using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечающий за перемещения игрока
/// </summary>
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    [SerializeField] private float _forceValue;

    private Rigidbody _rigidbody;
    private GameObject _player;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;                                                    // Получаем ссылку на основную камеру
        _player = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);  // Создаем игрока из префаба
        _rigidbody = _player.GetComponent<Rigidbody>();                           // Получаем компонент Rigidbody игрока
    }

    private void Update()
    {
        // Проверяем на нажатие левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);   // Создаем луч из камеры в точку нажатия мыши

            if (Physics.Raycast(ray, out var hitInfo))
            {
                // устанавливаем скорость в 0
                _rigidbody.velocity = Vector3.zero;

                // Толкаем игрока
                PushPlayer(hitInfo);
            }
        }
    }

    private void PushPlayer(RaycastHit hitInfo)
    {
        // Направление движения
        var direction = (hitInfo.point - transform.position).normalized;

        // Толкаем игрока в заданном направлении
        _rigidbody.AddForce(new Vector3(direction.x, 0, direction.z) * _forceValue);
        
        // Считаем ходы игрока
        CounterScores.IncreaseStepCounter();
    }
}