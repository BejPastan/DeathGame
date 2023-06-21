using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ScytheAttack : EnemyAttack
{
    [SerializeField]
    Transform scythe;
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
        animator.SetBool("Scythe", true);
        float animTime = GetAnimationDuration("ScytheAttack");
        await Task.Delay((int)(animTime * 1000));
        //zakończenie ataku, odpalenie ruchu
        animator.SetBool("Scythe", false);
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

    //KURWAAAAAAAA, ZADZIAŁAŁO ZA PIERWSZYM RAZEM
    //TO JAKAŚ MAGIA ALBO JACYŚ BOGOWIE
    private async void TeleportToTarget()
    {
        //pobiera kierunek w którym musi się poruszyć
        Vector3 nextPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        //wyznacza ile musi się przesunąć
        float distance = Mathf.Sqrt(Mathf.Pow(nextPosition.x - transform.position.x, 2) + Mathf.Pow(nextPosition.z - transform.position.z, 2));
        //odejmuje po³owę zasięgu ataku
        distance -= attackRange / 2;
        //o ile musi się dokładnie przesunąć
        Vector3 transfer = (nextPosition - transform.position).normalized*distance;
        //wyznacza nową pozycję na której musi się znaleźć
        nextPosition = transform.position + transfer;
        //odpala animacje teleportacji
        //przesuwa przeciwnika
        transform.position = nextPosition;
        //obraca go o 90 stopni
        //odpala animację pojawiania się na miejscu
    }

}
