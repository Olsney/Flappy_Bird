using System;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    private int _value;

    public event Action<int> Changed;

    public void Increase()
    {
        _value++;

        Changed?.Invoke(_value);
    }

    public void Reset()
    {
        _value = 0;

        Changed?.Invoke(_value);
    }
}
