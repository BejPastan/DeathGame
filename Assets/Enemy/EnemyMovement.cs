using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    Transform player;
    private bool canMove;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(player==null)
        {
            GameObject.Find("Player");
        }
    }

    private async void Move()
    {
        if(Application.isPlaying && canMove)
        {
            agent.destination = player.position;
            await Task.Delay(500);
            Move();
        }
    }

    public void StartMovement()
    {
        canMove = true;
        agent.isStopped = false;
        Move();
    }

    public void StopMovement()
    {
        canMove = false;
        agent.isStopped = true;
        transform.LookAt(player);
    }

}

