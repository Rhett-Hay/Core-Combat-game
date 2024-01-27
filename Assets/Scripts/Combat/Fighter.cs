using UnityEngine;
using RPG.Move;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;

        [SerializeField] Transform target;

        private void Update()
        {
            if (target == null) return;

            if (!GetIsInRange())
            {
                GetComponent<Movement>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Movement>().Cancel();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
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
