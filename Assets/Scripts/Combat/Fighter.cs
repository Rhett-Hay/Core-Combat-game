using UnityEngine;
using RPG.Move;

namespace RPG.Combat
{   
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;

        [SerializeField] Transform target;

        private void Update()
        {
            if (target == null && Vector3.Distance(transform.position, target.position) > weaponRange)
            {
                GetComponent<Movement>().MoveTo(target.position);
                
            }
            else if (target != null && Vector3.Distance(transform.position, target.position) < weaponRange)
            { 
                GetComponent<Movement>().Stop();
                //target = null;
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}
