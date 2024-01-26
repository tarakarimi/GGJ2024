using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daricheController : MonoBehaviour
{
    [SerializeField] private AcidController acidController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            acidController.shouldGoUp = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            acidController.shouldGoUp = true;
        }
    }
    
}
