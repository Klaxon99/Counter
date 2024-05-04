using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _text.text = _counter.Count.ToString();
    }

    private void OnEnable()
    {
        _counter.CountChanged += OnCountChanged;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= OnCountChanged;
    }

    private void OnCountChanged(int count)
    {
        _text.text = count.ToString();
    }
}