using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daricheController : MonoBehaviour
{
    [SerializeField] private AcidController acidController;
    [SerializeField] private GameObject blades;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            acidController.shouldGoUp = true;
            blades.SetActive(true);
        }
    }
}
