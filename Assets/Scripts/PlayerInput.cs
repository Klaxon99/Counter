using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action Clicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Clicked?.Invoke();
        }
    }
}