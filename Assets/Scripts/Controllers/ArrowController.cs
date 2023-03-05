using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D arrowRB;
    [SerializeField] private float arrowSpeed;
    private Vector2 _arrowDirection;

    public Vector2 ArrowDirection { get => _arrowDirection; set => _arrowDirection = value; }

    [SerializeField] private GameObject arrowImpact;
    private Transform transformArrow;
    [SerializeField] private GameObject arrowImpactBat;

    private void Awake()
    {
        arrowRB = GetComponent<Rigidbody2D>();
        transformArrow = GetComponent<Transform>();
    }

    void Update()
    {
        arrowRB.velocity = _arrowDirection * arrowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(arrowImpactBat, transformArrow.position, Quaternion.identity);
            other.gameObject.GetComponent<EnemyController>().SpreadBatParticles();
            Destroy(other.gameObject);
        }
       if(other.CompareTag("Ground"))
        {
            Instantiate(arrowImpact, transformArrow.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
