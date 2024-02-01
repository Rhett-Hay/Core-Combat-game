using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float maxHealth = 100f;

        private float health;

        private void Start()
        {
            health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (health == 0) return;

            health = Mathf.Max(health - damage, 0);
            Debug.Log(health);
        }
    }
}
