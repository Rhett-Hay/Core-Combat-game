using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;
using RPG.Move;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 5.0f;

        Fighter fighter;
        Health health;
        Movement movement;
        GameObject player;
        Vector3 guardPosition;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            movement = GetComponent<Movement>();
            player = GameObject.FindWithTag("Player");

            guardPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (health.IsDead()) return;
            if (InRangeOfPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                movement.StartMoveAction(guardPosition);
            }
        } 

        private bool InRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        // Function called by Unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
