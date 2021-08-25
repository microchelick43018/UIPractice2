using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingButton : MonoBehaviour
{
    [SerializeField] private int _healValue;

    private Player _player;

    public void OnMouseClick()
    {
        _player.GetHeal(_healValue);
    }

    private void Awake()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
    }
}
