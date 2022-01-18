using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    private Vector3 _moveDirection;

    private void Start()
    {
        _moveDirection = Vector3.right;
    }

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
        if(other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
        if(other.TryGetComponent(out DeathZone deathZone))
        {
            deathZone.ExplosionAnimation();
            deathZone.DeathCounter();
            Destroy(gameObject);
        }
    }

    private void Bounce()
    {
        _moveDirection = -Vector3.right + Vector3.up;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(-1, 1, 0), _bounceRadius);
    }
}
