using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Move;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                GetComponent<Movement>().MoveTo(hit.point);
            }

            Debug.DrawRay(ray.origin, ray.direction * 100);
        }
    }
}
