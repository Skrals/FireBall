using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class DeathZone : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private Tower _tower;
    [SerializeField] private Tank _tank;
    [SerializeField] private GameOverScreen _gameOverScreen;

    public int _lifes;

    public event UnityAction<int> LifeUpdater;

    private void Start()
    {
        LifeUpdater?.Invoke(_lifes);
    }

    public void ExplosionAnimation()
    {
        Instantiate(_explosionEffect, transform.position, _explosionEffect.transform.rotation);
    }

    public void DeathCounter ()
    {
        _lifes -= 1;
        _tower.LifeRegen(-1);
        if (_lifes <= 0)
        {
            _lifes = 0;
            GameOver();
            LifeUpdater?.Invoke(_lifes);
        }
        else
        {
            LifeUpdater?.Invoke(_lifes);
        }
    }

    private void GameOver ()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _tank.enabled = false;
    }

}
