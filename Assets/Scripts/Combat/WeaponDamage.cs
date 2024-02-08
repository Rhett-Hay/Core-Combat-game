using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    [SerializeField] float weaponDamage = 5f;


    private List<Collider> alreadyCollided = new List<Collider>();

    private void OnEnable()
    {
        alreadyCollided.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return; 

        if (alreadyCollided.Contains(other)) return;

        alreadyCollided.Add(other);

        if (other.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(weaponDamage);
        }      
    }
}
