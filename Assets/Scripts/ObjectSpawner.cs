using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private PickableItem _pickableItemPrefab; // Префаб объекта для спавна

    [SerializeField] private Colorizer _colorizerPrefab; // Префаб объекта для спавна задающего цвет

    [SerializeField] private int _numberOfObjects = 6; // Количество объектов для спавна

    [SerializeField] private float _enemyRadius = 1; // Размер сферы для поиска касания при спавне

    private ColorsProvider _colorsProvider;
    private PositionGenerator _positionGenerator;

    private void Awake()
    {
        _positionGenerator = GetComponent<PositionGenerator>();
    }

    public void SpawnObjects(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;                        // Генерируем цвет объекта

        for (int i = 0; i < _numberOfObjects; i++)
        {
            var item = Instantiate(_pickableItemPrefab);         // Инстанциируем префаб объекта
            
            Vector3 randomSpawnPoint = GenerateSafeSpawnPoint(); // Генерируем новую позицию, избегая коллизий при спавне

            item.transform.position = randomSpawnPoint;
            
            item.Initialize(_colorsProvider.GetRandomColor());   // Инициализируем объект случайным цветом
        }
    }

    public void SpawnObject(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;                      // Генерируем цвет объекта

        var item = Instantiate(_colorizerPrefab);       // Инстанциируем префаб объекта
        
        Vector3 randomSpawnPoint = GenerateSafeSpawnPoint();   // Генерируем новую позицию, избегая коллизий при спавне
       
        item.transform.position = randomSpawnPoint;

        item.Initialize(_colorsProvider);

    }

    private Vector3 GenerateSafeSpawnPoint()
    {
        // Генерируем новую позицию
        Vector3 randomSpawnPoint = _positionGenerator.GetRandomPointOnGameBoard();

        // Пока объект касается чего-либо, генерируем новую позицию
        while (randomSpawnPoint.HasCollisions(_enemyRadius))
        {
            randomSpawnPoint = _positionGenerator.GetRandomPointOnGameBoard();
        }

        return randomSpawnPoint;
    }
}