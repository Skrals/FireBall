using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
    }
    
    private void OnBulletHit (Block block)
    {
        block.BulletHit -= OnBulletHit;

        _blocks.Remove(block);

        foreach (var item in _blocks)
        {
            item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 0.1f, block.transform.position.z);
        }
    }
}
