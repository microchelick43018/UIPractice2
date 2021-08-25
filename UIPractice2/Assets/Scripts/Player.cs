using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private UnityEvent _changedHealth = new UnityEvent();

    public event UnityAction ChangedHealth
    {
        add => _changedHealth.AddListener(value);
        remove => _changedHealth.RemoveListener(value);
    }

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get => _maxHealth; private set => _maxHealth = value; }

    public void GetHeal(int value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, _maxHealth);
        _changedHealth?.Invoke();
    }

    public void GetDamage(int value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - value, 0, _maxHealth);
        _changedHealth?.Invoke();
    }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }
}
