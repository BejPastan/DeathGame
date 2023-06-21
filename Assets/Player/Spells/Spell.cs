using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class Spell : MonoBehaviour
{
    //podstawowe staty
    [SerializeField]
    public float paraboleHeight;
    [SerializeField]
    protected float range;

    bool activated = false;


    //odpalanie u�ycia spella przy kontakcie z czymkolwiek poza graczem
    protected async void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && !activated)
        {
            activated = true;
            await ExecuteSpell();
            Destroy(gameObject);
        }
    }

    //u�ywanie spella
    public async virtual Task ExecuteSpell()
    {
        Debug.Log("eeeeee... co� posz�o nie tak");
    }

    //pobieranie controler�w od wszystkich trafionych przeciwnik�w
    protected void GetEnemies(float radius, out EnemyController[] controllers)
    {
        Debug.Log("range: " + radius);
        controllers = new EnemyController[0];
        //znajduje wszystkich przeciwnik�w w zasi�gu
        Collider[] enemies = Physics.OverlapSphere(transform.position, radius);
        //pobiera EnemyControllery od wszystkich w zasi�gu
        for (int x = 0; x < enemies.Length; x++)
        {
            if (enemies[x].GetComponent<EnemyController>() != null)
            {
                Array.Resize(ref controllers, controllers.Length + 1);
                controllers[controllers.Length - 1] = enemies[x].GetComponent<EnemyController>();
            }
        }
    }
}
