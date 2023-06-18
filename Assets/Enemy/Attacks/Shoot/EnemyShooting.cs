using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]

public class EnemyShooting : EnemyAttack
{
    [SerializeField]
    private int fireRate;
    [SerializeField]
    private int series;
    [SerializeField]
    public Transform bulletPref;
    [SerializeField]
    private Transform gun;
    [SerializeField]
    private int inacuracy;

    public async override Task Attack()
    {
        //wchodzi do pêtli strza³u
        for(int x=0; x<series; x++)
        {
            if(alive)
            {
                //tworzy pocisk
                Transform bullet = Instantiate(bulletPref);
                bullet.position = gun.position;
                //rotacja pocisku
                Quaternion rotation = Quaternion.Euler(0, gun.rotation.eulerAngles.y + 90 + Random.Range(-this.inacuracy, this.inacuracy), bullet.rotation.eulerAngles.z);
                bullet.GetComponent<Projectile>().Move(rotation);
                await Task.Delay(60000 / fireRate);
            }
        }
    }
}
