using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _changeTime;
    [SerializeField] private int _changeValue;
    [SerializeField] private int _maxHealth;

    private int _targetHealth;

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get => _maxHealth; private set => _maxHealth = value; }

    public void ChangeCurrentHealth(int value)
    {
        _targetHealth = Mathf.Clamp(_targetHealth + value, 0, MaxHealth);
        if (_targetHealth == CurrentHealth + value)
        {
            StartCoroutine(ChangeHealthSmoothly());
        }
    }

    public void GetHeal(int value)
    {
        ChangeCurrentHealth(value);
    }

    public void GetDamage(int value)
    {
        ChangeCurrentHealth(value * -1);
    }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        _targetHealth = CurrentHealth;
    }

    private IEnumerator ChangeHealthSmoothly()
    {
        WaitForSeconds endOfSeconds = new WaitForSeconds(_changeTime);

        while (CurrentHealth != _targetHealth)
        {
            CurrentHealth = (int)Mathf.MoveTowards(CurrentHealth, _targetHealth, _changeValue);
            yield return endOfSeconds;
        }
    }
}
