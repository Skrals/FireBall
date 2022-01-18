using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lifeCounterView;
    [SerializeField] private DeathZone _deathZone;

    private void OnEnable()
    {
        _deathZone.LifeUpdater += OnLifeUpdated;
    }
    private void OnDisable()
    {
        _deathZone.LifeUpdater-= OnLifeUpdated;
    }
    private void OnLifeUpdated(int size)
    {
        _lifeCounterView.text = $"Lifes: " + size.ToString();
    }
}
