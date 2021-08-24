using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _healthBarObject;

    private HealthBar _healthBar;

    private void Start()
    {
        _healthBar = _healthBarObject.GetComponent<HealthBar>();
    }

    public void GetHeal(int value)
    {
        _healthBar.ChangeCurrentHealth(value);
    }

    public void GetDamage(int value)
    {
        _healthBar.ChangeCurrentHealth(value * -1);
    }
}
