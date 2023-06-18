using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ScytheAttack : EnemyAttack
{
    [SerializeField]
    Transform scythe;
    [SerializeField]
    Transform player;
    [SerializeField]
    float attackRange;
    [SerializeField]
    Animator animator;

    //atakowanie
    public async override Task Attack()
    {
        //doskok do celu
        TeleportToTarget();
        //odpalenie animacji ataku
        animator.SetBool("Attack", true);
        float animTime = GetAnimationDuration("ScytheAttack");
        await Task.Delay((int)(animTime * 1000));
        //zako�czenie ataku, odpalenie ruchu
        animator.SetBool("Attack", false);
    }

    private float GetAnimationDuration(string animationName)
    {
        float duration=0;

        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        foreach(AnimationClip clip in clips)
        {
            if(clip.name == animationName)
            {
                duration = clip.length;
            }
        }

        return duration;
    }

    //KURWAAAAAAAA, ZADZIA�A�O ZA PIERWSZYM RAZEM
    //TO JAKA� MAGIA ALBO JACY� BOGOWIE
    private async void TeleportToTarget()
    {
        //pobiera kierunek w kt�rym musi si� poruszy�
        Vector3 nextPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        //wyznacza ile musi si� przesun��
        float distance = Mathf.Sqrt(Mathf.Pow(nextPosition.x - transform.position.x, 2) + Mathf.Pow(nextPosition.z - transform.position.z, 2));
        //odejmuje po�ow� zasi�gu ataku
        distance -= attackRange / 2;
        //o ile musi si� dok�adnie przesun��
        Vector3 transfer = (nextPosition - transform.position).normalized*distance;
        //wyznacza now� pozycj� na kt�ej musi si� znale��
        nextPosition = transform.position + transfer;
        //odpala animacj� teleportacji
        //przesuwa przeciwnika
        transform.position = nextPosition;
        //obraca go o 90 stopni
        //odpala animacj� pojawiania si� na miejscu
    }

}
