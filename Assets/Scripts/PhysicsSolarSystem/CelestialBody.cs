using System.Collections.Generic;
using UnityEngine;

// Атрибут [ExecuteInEditMode] позволяет выполнение кода в редакторе Unity.
// Атрибут [RequireComponent] обязывает наличие компонента Rigidbody на объекте.
[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class CelestialBody : GravityObject
{
    // Публичные поля для настройки параметров объекта.
    public float radius; // Радиус объекта.
    public float surfaceGravity; // Гравитация на поверхности объекта.
    public Vector3 initialVelocity; // Начальная скорость объекта.
    public string bodyName = "Unnamed"; // Название объекта по умолчанию.
    Transform meshHolder; // Ссылка на Transform, который будет содержать сетку объекта.

    // Свойства для доступа к скорости и массе объекта.
    public Vector3 velocity { get; private set; } // Текущая скорость объекта (доступ только на чтение).
    public float mass { get; private set; } // Масса объекта (доступ только на чтение).
    Rigidbody rb; // Ссылка на компонент Rigidbody объекта.

    // Метод Awake вызывается при инициализации объекта.
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody.
        rb.mass = mass; // Устанавливаем массу объекта из свойства mass.
        velocity = initialVelocity; // Устанавливаем начальную скорость объекта.
    }

    // Метод обновления скорости объекта на основе воздействия гравитации от других тел.
    public void UpdateVelocity(CelestialBody[] allBodies, float timeStep)
    {
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude; // Квадрат расстояния между объектами.
                Vector3 forceDir = (otherBody.rb.position - rb.position).normalized; // Нормализованный вектор направления на другой объект.

                Vector3 acceleration = forceDir * Universe.gravitationalConstant * otherBody.mass / sqrDst; // Ускорение.
                velocity += acceleration * timeStep; // Обновление скорости.
            }
        }
    }

    // Метод обновления скорости объекта на основе заданного ускорения.
    public void UpdateVelocity(Vector3 acceleration, float timeStep)
    {
        velocity += acceleration * timeStep; // Обновление скорости на основе заданного ускорения.
    }

    // Метод обновления позиции объекта на основе его скорости.
    public void UpdatePosition(float timeStep)
    {
        rb.MovePosition(rb.position + velocity * timeStep); // Обновление позиции объекта на основе скорости.
    }

    // Метод вызывается при валидации (изменении параметров) объекта.
    void OnValidate()
    {
        // Расчет массы объекта на основе гравитации, радиуса и константы гравитации.
        mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;

        // Получение ссылки на дочерний объект для отображения сетки и установка его размера.
        meshHolder = transform.GetChild(0);
        meshHolder.localScale = Vector3.one * radius;

        // Установка имени объекта.
        gameObject.name = bodyName;
    }

    // Свойство для доступа к компоненту Rigidbody объекта.
    public Rigidbody Rigidbody
    {
        get { return rb; }
    }

    // Свойство для доступа к текущей позиции объекта.
    public Vector3 Position
    {
        get { return rb.position; }
    }

    public NBodySimulation NBodySimulation
    {
        get => default;
        set
        {
        }
    }
}
