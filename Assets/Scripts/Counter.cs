using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _changeDelay;
    [SerializeField] private PlayerInput _playerInput;

    private Coroutine _coroutine;

    public event Action<int> CountChanged;

    public int Count { get; private set; }

    private void Awake()
    {
        Count = 0;
    }

    private void OnEnable()
    {
        _playerInput.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _playerInput.Clicked -= OnClicked;
    }

    public void Add()
    {
        Count++;
        CountChanged?.Invoke(Count);
    }

    private IEnumerator ChangeCountRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_changeDelay);

        while (enabled)
        {
            Add();

            yield return wait;
        }
    }

    private void OnClicked()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ChangeCountRoutine());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}