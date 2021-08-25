using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingButton : MonoBehaviour
{
    [SerializeField] private int _healValue;

    private HealthBar _playerHealth;

    public void OnMouseClick()
    {
        _playerHealth.GetHeal(_healValue);
    }

    private void Awake()
    {
        _playerHealth = GameObject.FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
    }
}
