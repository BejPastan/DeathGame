using UnityEngine;
using System.Threading.Tasks;

public class Lure : Spell
{
    [SerializeField]
    float duration;

    public async override Task ExecuteSpell()
    {
        Debug.Log("uderzenie");
        EnemyController[] enemies;

        GetEnemies(range, out enemies);
        //zatrzymywanie przeciwników
        foreach (EnemyController enemy in enemies)
        {
            Debug.Log("kolejny");
            enemy.StopAttack((int)(duration * 1000));
            enemy.ChangeTarget(gameObject.transform, duration);
        }
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        await Task.Delay((int)(duration * 1000));
    }
}
