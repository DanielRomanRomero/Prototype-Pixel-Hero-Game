using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform pos;
    [SerializeField] private GameObject particlesBat;

    private void Awake()
    {
        pos = GetComponent<Transform>();
    }

    public void SpreadBatParticles()
    {
        Instantiate(particlesBat, pos.position,Quaternion.identity);
    }
}
