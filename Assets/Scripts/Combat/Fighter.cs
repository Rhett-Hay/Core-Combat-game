using UnityEngine;
using RPG.Move;
using RPG.Core;
using System;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 3f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;

        [SerializeField] Transform target;
        float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Movement>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Movement>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                // This will trigger the Hit() event
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

        void Hit()
        {
            Health healthComp = GetComponent<Health>();
            healthComp.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            float enemyPosition = Vector3.Distance(transform.position, target.position);
            return enemyPosition <= weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ScheduleAction>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
