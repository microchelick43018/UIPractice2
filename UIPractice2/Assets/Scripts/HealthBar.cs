using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _changeTime;
    [SerializeField] private int _changeValue;

    private UnityEvent _changedHealth = new UnityEvent();
    private Text _text;
    private int _currentHealth;
    private int _targetHealth;
    private Slider _slider;

    public void ChangeCurrentHealth(int value)
    {
        _targetHealth = Mathf.Clamp(_targetHealth + value, 0, _maxHealth);
        if (_targetHealth == _currentHealth + value)
        {
            StartCoroutine(ChangeHealthSmoothly());
        }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _targetHealth = _currentHealth;
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

    private void Start()
    {
        _changedHealth?.Invoke();
    }

    private IEnumerator ChangeHealthSmoothly()
    {
        WaitForSeconds endOfSeconds = new WaitForSeconds(_changeTime);

        while (_currentHealth != _targetHealth)
        {
            _currentHealth = (int) Mathf.MoveTowards(_currentHealth, _targetHealth, _changeValue);
            _changedHealth.Invoke();
            yield return endOfSeconds;
        }
    }

    private void UpdateText()
    {
        _text.text = $"{_currentHealth} / {_maxHealth}";
    }

    private void UpdateSlider()
    {
        _slider.value = (float)_currentHealth / _maxHealth;
    }
}
