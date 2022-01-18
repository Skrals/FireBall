using UnityEngine;

public class LevelIncreaser : MonoBehaviour
{
    [SerializeField] private Tower _tower;

    public int _currLevel;

    private void OnEnable()
    {
        _tower.SizeUpdated += LevelIncrease;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= LevelIncrease;
    }

    private void LevelIncrease(int size)
    {
        if (size <= 0)
        {
            _currLevel += 1;
        }
    }
}
