using UnityEngine;
using System.Collections;

public class CountChanger : MonoBehaviour
{
    [SerializeField] private float _changeDelay;
    [SerializeField] private Counter _counter;
    [SerializeField] private PlayerInput _playerInput;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _playerInput.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _playerInput.Clicked -= OnClicked;
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

    private IEnumerator ChangeCountRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_changeDelay);

        while (enabled)
        {
            _counter.Add();

            yield return wait;
        }
    }
}