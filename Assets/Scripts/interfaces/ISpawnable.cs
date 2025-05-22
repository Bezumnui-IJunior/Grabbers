using System;

public interface ISpawnable<out T>
{
    event Action<T> Dying;

    void Destroy();

    void TurnOn();
    void TurnOff();
}