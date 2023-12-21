using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigate : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(new Vector3(10f, 0f, 10f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination=player.transform.position;
    }
}
