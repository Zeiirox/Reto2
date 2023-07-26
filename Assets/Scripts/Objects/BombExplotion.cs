using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplotion : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float explotionRadius = 2;
    [SerializeField, Range(500, 1500)] private float explotionForce = 500;
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
