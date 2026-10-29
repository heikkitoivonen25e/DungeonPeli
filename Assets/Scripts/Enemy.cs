using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent _agent;
    GameObject _target;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
    }

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        _agent.SetDestination(_target.transform.position);
    }
}
