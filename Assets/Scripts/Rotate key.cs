using UnityEngine;

public class PickupKey : MonoBehaviour
{
    [Header("Настройки вращения")]
    [Tooltip("Скорость вращения вокруг вертикальной оси")]
    [SerializeField] private float rotationSpeed = 70f;

    [Header("Настройки парения (вверх-вниз)")]
    [Tooltip("Включить/выключить покачивание в воздухе")]
    [SerializeField] private bool IsHovering = true;
    [Tooltip("Амплитуда движения вверх-вниз")]
    [SerializeField] private float hoverAmplitude = 0.2f;
    [Tooltip("Скорость движения вверх-вниз")]
    [SerializeField] private float hoverSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        // Запоминаем начальную позицию ключа
        startPosition = transform.position;
    }

    void Update()
    {
        // 1. ВРАЩЕНИЕ: Крутим ТОЛЬКО вокруг оси Y (вертикальная ось)
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);

        // 2. ПАРЕНИЕ: Плавное движение вверх-вниз с помощью синусоиды
        if (IsHovering)
        {
            float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}