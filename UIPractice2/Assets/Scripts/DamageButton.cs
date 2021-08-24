using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private int _damageValue;
    
    private Player _player;

    public void OnMouseClick()
    {
        _player.GetDamage(_damageValue);
    }

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
}
