using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private LevelIncreaser _levelIncreaser;
    [SerializeField] private Color[] _colors;
    private float div = 20; // коррекция спауна по размеру модели

    private List<Block> _blocks;

    public List<Block> Build()
    {
        int towerSize = _towerSize + (_towerSize / 3 * _levelIncreaser._currLevel);
        _blocks = new List<Block>();
        Transform currentPoint = _buildPoint;
        for (int i = 0; i < towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        return _blocks;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    { 
      //  _block.transform.localScale = _blockSize;
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.Euler(-90, 0, 0), _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y / div  + _block.transform.localScale.y /div, _buildPoint.position.z);
    }
}
