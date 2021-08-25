using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _changeTime;
    [SerializeField] private int _changeValue;

    private UnityEvent _changedHealth = new UnityEvent();
    private Text _text;
    private Slider _slider;
    private Player _player;
    private int _currentHealth;
    private bool _isChangingHealth;

    private void Awake()
    {
        _isChangingHealth = false;
        _player = FindObjectOfType<Player>().GetComponent<Player>();
        _slider = GetComponent<Slider>();
        _text = GetComponentInChildren<Text>();
    }

    public void ChangeCurrentHealth()
    {
        if (_isChangingHealth == false)
        {
            _isChangingHealth = true;
            StartCoroutine(ChangeHealthSmoothly());
        }
    }

    private void OnEnable()
    {
        _changedHealth.AddListener(UpdateText);
        _changedHealth.AddListener(UpdateSlider);
        _player.ChangedHealth += ChangeCurrentHealth;
    }

    private void OnDisable()
    {
        _changedHealth.RemoveListener(UpdateText);
        _changedHealth.RemoveListener(UpdateSlider);
        _player.ChangedHealth -= ChangeCurrentHealth;
    }

    private void Start()
    {
        _currentHealth = _player.CurrentHealth;
        _changedHealth?.Invoke();
    }

    private void UpdateText()
    {
        _text.text = $"{_currentHealth} / {_player.MaxHealth}";
    }

    private void UpdateSlider()
    {
        _slider.value = (float)_currentHealth / _player.MaxHealth;
    }

    private IEnumerator ChangeHealthSmoothly()
    {
        WaitForSeconds endOfSeconds = new WaitForSeconds(_changeTime);
        while (_player.CurrentHealth != _currentHealth)
        {
            _currentHealth = (int)Mathf.MoveTowards(_currentHealth, _player.CurrentHealth, _changeValue);
            _changedHealth.Invoke();
            yield return endOfSeconds;
        }
        _isChangingHealth = false;
    }
}
