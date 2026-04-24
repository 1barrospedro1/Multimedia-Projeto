using UnityEngine;
using UnityEngine.AI;
using MimicSpace; // This talks to the procedural leg script

public class MimicAI : MonoBehaviour
{
    [Header("Target")]
    public Transform player; 

    private NavMeshAgent agent;
    private Mimic myMimic;

    void Start()
    {
        // Grab the components off the monster
        agent = GetComponent<NavMeshAgent>();
        myMimic = GetComponent<Mimic>();
    }

    void Update()
    {
        if (player != null)
        {
            // 1. Tell the AI to run towards the player
            agent.SetDestination(player.position);

            // 2. Feed the AI's speed to the procedural legs so they crawl
            myMimic.velocity = agent.velocity;
        }
    }
}