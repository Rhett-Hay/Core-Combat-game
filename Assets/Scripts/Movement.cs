using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform target;
    Ray ray;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        Debug.DrawRay(ray.origin, ray.direction * 100);

        GetComponent<NavMeshAgent>().destination = target.position;
    }
}
