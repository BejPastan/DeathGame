using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using System.Threading.Tasks;


public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public EnemyAttack[] attackType;
    public EnemyMovement movement;
    public HealthSystem health;

    [SerializeField]
    Transform player;

    private bool canAttack;

    int attackNumb;

    private async void Start()
    {
        canAttack = true;
        attackType = GetComponents<EnemyAttack>();
        movement.StartMovement();
        SelectAttack();
    }




    //WALKA
    //losowanie którego ataku użyje
    private async void SelectAttack()
    {
        attackNumb = Random.Range(0, attackType.Length);
        await Task.Delay((int)(attackType[attackNumb].cooldawn * 1000));
        await Attack();
    }

    //wykonywanie ataku, czekanie cooldownu i potem wywoływanie losowania ataku
    private async Task Attack()
    {
        if(Application.isPlaying && canAttack)//ten warunek jest żeby zatrzymywało sie przy naciśnięciu stop w edytorze XD nie usuwaj tego debilu
        {
            movement.StopMovement();
            attackType[attackNumb].StartAttack();
            await attackType[attackNumb].Attack();
            if(canAttack)
            {
                movement.StartMovement();
                SelectAttack();
            }
        }
    }

    //pauzowanie ataku
    public async Task StopAttack(int stopTime = 0)
    {
        canAttack = false;
        attackType[attackNumb].StopFight();
        await Task.Delay(stopTime);
    }



    //MOVEMENT
    public void StopMovement()
    {
        movement.StopMovement();
    }

    public async void PauseMovement(int pauseTime = 0)
    {
        movement.StopMovement();
        await Task.Delay(pauseTime);
        movement.StartMovement();
    }

    public void StartMovement()
    {
        movement.StartMovement();
    }

    public async void ChangeTarget(Transform newTarget,float duration)
    {
        movement.target = newTarget;
        Debug.Log(movement.target);
        await Task.Delay((int)(duration * 1000));
        movement.target = player;
    }




    //umieranie dostawnaie dmg itp
    public void GetDmg(int dmg)
    {
        if(!health.IsAlive(dmg))
        {
            Death();
        }
    }

    public void Death()
    {
        canAttack = false;
        movement.StopMovement();
        foreach(EnemyAttack attack in attackType)
        {
            attack.StopFight();
        }
        GetComponent<NavMeshAgent>().enabled = false;
        transform.rotation = Quaternion.Euler(90, 0, 0);
        GetComponent<Collider>().enabled = false;
    }
}
