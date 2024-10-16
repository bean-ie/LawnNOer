using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GrassController : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;
    GamemodeManager gamemodeManager;
    // Start is called before the first frame update
    void Start()
    {
        gamemodeManager = FindObjectOfType<GamemodeManager>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position + player.forward * 2);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            gamemodeManager.AddDeath();
            Destroy(gameObject);
        }
    }
}
