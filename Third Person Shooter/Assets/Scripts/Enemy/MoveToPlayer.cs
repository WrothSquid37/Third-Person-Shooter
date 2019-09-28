using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour {

	public Transform player;

	private NavMeshAgent agent;

	void Start()
	{
        player = GameObject.Find("Player").gameObject.transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		agent.SetDestination(player.transform.position);
	}



}
