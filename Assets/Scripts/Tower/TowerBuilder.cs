using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Vector3 _blockSize;
    private float div = 600; // коррекция спауна по размеру модели

    private List<Block> _blocks;
    private void Start()
    {
        Build();
    }

    public List<Block> Build()
    {
        _blocks = new List<Block>();
        Transform currentPoint = _buildPoint;
        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        return _blocks;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    { 
        _block.transform.localScale = _blockSize;
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.Euler(-90, 0, 0), _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y / div+ _block.transform.localScale.y /div, _buildPoint.position.z);
    }
}
