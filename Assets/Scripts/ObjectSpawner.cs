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
        _colorsProvider = colorsProvider;

        for (int i = 0; i < _numberOfObjects; i++)
        {
            var item = Instantiate(_pickableItemPrefab);

            // Генерируем новую позицию, избегая коллизий при спавне
           // Vector3 randomSpawnPoint = GenerateSafeSpawnPoint();

           // item.transform.position = randomSpawnPoint;
           
           Vector3 randomSpawnPoint = _positionGenerator.GetRandomPointOnGameBoard();

           // Пока враг касается кого-либо - генерируем новую позицию
          // while (randomSpawnPoint.HasCollisions(_enemyRadius))
           //{
             //  randomSpawnPoint = _positionGenerator.GetRandomPointOnGameBoard();
         //  }

           item.transform.position = randomSpawnPoint;

            // Инициализируем объект случайным цветом
            item.Initialize(_colorsProvider.GetRandomColor());
        }
    }

    public void SpawnObject(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;

        var item = Instantiate(_colorizerPrefab);
        Vector3 randomSpawnPoint = _positionGenerator.GetRandomPointOnGameBoard();
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