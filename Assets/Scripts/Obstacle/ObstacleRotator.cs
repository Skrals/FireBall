using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _animationDuration;

    private void Update()
    {
        transform.Rotate(0,_animationDuration * Time.deltaTime,0, Space.World);
    }
  
}
