using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    private UnityEvent _changedHealth = new UnityEvent();
    private Text _text;
    private Slider _slider;
    private Player _player;
  
    private void Awake()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
        _slider = GetComponent<Slider>();
        _text = GetComponentInChildren<Text>();
    }

    private void OnEnable()
    {
        _changedHealth.AddListener(UpdateText);
        _changedHealth.AddListener(UpdateSlider);
    }

    private void OnDisable()
    {
        _changedHealth.RemoveListener(UpdateText);
        _changedHealth.RemoveListener(UpdateSlider);
    }

    private void Update()
    {
        _changedHealth.Invoke();
    }

    private void UpdateText()
    {
        _text.text = $"{_player.CurrentHealth} / {_player.MaxHealth}";
    }

    private void UpdateSlider()
    {
        _slider.value = (float)_player.CurrentHealth / _player.MaxHealth;
    }   
}
