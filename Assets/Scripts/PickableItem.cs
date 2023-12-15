using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    private Material _material;
    private Color _color;

    public void Initialize(Color color)
    {
        // Сохраняем colored материал
        var materials = _renderer.materials;
        _material = materials.First(material => material.name.Contains(GlobalConstants.COLORED_MATERIAL));

        // Задаем материалу переданный цвет              
        _material.color = color;
        _color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Если столкнувшийся с предметом объект - это Player
        if (collision.gameObject.TryGetComponent<PlayerColor>(out var player))
        {
            // Если цвет объекта совпадает с цветом игрока
            if (player.Color == _color)
            {
                // Разрушаем объект
                Destroy(gameObject);
            }
        }
    }
}