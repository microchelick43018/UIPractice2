using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private int _damageValue;
    
    private HealthBar _playerHealth;

    public void OnMouseClick()
    {
        _playerHealth.GetDamage(_damageValue);
    }

    private void Awake()
    {
        _playerHealth = GameObject.FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
    }
}
