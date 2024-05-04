using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> CountChanged;

    public int Count { get; private set; }

    private void Awake()
    {
        Count = 0;
    }

    public void Add()
    {
        Count++;
        CountChanged?.Invoke(Count);
    }
}