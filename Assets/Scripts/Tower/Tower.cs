using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    [SerializeField] private DeathZone _deatZone;

    private List<Block> _blocks;

    [SerializeField] private int _blockStrikeToRegen;
    [SerializeField] private int _currentBlockStrike;

    public event UnityAction<int> SizeUpdated;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }

        SizeUpdated?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block block)
    {
        block.BulletHit -= OnBulletHit;

        _blocks.Remove(block);

        _currentBlockStrike += 1;

        LifeRegen(_currentBlockStrike);

        foreach (var item in _blocks)
        {
            item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 0.1f, block.transform.position.z);
        }

        SizeUpdated?.Invoke(_blocks.Count);

        if (_blocks.Count <= 0)
        {
            Start();
        }
    }

    public void LifeRegen(int streak)
    {
        if(streak>=_blockStrikeToRegen)
        {
            _deatZone._lifes += 1;
            _currentBlockStrike = 0;
            _deatZone.LifeUpdaterMethod();
            _blockStrikeToRegen += _blocks.Count / 4;
        }
        else if (streak <=0)
        {
            _currentBlockStrike = 0;
        }
        
    }
}
