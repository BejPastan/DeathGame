using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    int bounceNumb;//ile razy mo�e si� odbi� zanim zniknie
    [SerializeField]
    int dmg;//jaki dmg zadaje
    public float speed;
    public bool death;//czy posta� jest �mierci�(aka mo�e zabi� wsyzstkich)
    Vector3 oldVelocity;

    public Rigidbody physics;

    private async void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Obstacle"))
        {
            //tutaj musi wylicza� now� trajektori� lotu
            Move(CalcNewDirection(collision.contacts[0].normal));
            bounceNumb--;
            if (bounceNumb == 0)
            {
                Destroy(gameObject);
            }
        }
        else if(collision.transform.tag == "Enemy")
        {
            if(death)
            {
                //tutaj musz� wsadzi� odejmowanie �ycia przeciwnikom, bo trafi�a ich �mier�
                collision.gameObject.GetComponent<EnemyController>().GetDmg(dmg);
            }
            Destroy(gameObject);
        }
        else if(collision.transform.tag=="Player")
        {
            //tutaj musz� wsadzi� odejmowanie HP
            Destroy(gameObject);
        }
        else if(collision.transform.CompareTag("Destroyable"))
        {
            Move(CalcNewDirection(collision.contacts[0].normal));
            bounceNumb--;
            if (bounceNumb == 0)
            {
                Destroy(gameObject);
            }
            collision.gameObject.GetComponent<DestroyableWall>().GetDamage(dmg);
        }
        else if(collision.transform.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    private Vector3 CalcNewDirection(Vector3 surfaceNormal)
    {
        
        Vector3 newDirection = Vector3.Reflect(oldVelocity, surfaceNormal);
        /*Debug.Log("Surface Normal = " + surfaceNormal);
        Debug.Log("old Velocity = " + oldVelocity);
        Debug.Log("New Direction = "+newDirection);*/
        return newDirection;
    }

    public async Task Move(Quaternion rotation)
    {
        //nadaje oblicza jaki b�dzie kierunek ruchu
        Vector3 direction;
        transform.rotation = rotation;
        direction = -transform.right;
        Move(direction);
    }

    public async Task Move(Vector3 direction)
    {
        physics.velocity = Vector3.zero;
        physics.AddForce(direction.normalized * speed, ForceMode.VelocityChange);

        transform.rotation = Quaternion.LookRotation(direction);
        transform.Rotate(new Vector3(90, 0, 0));
        //problem jest z pobieraniem pr�dko�ci
        await Task.Delay(50);
        oldVelocity = physics.velocity;
    }
}
