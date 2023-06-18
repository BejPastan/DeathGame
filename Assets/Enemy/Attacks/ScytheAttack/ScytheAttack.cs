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
        //zakoñczenie ataku, odpalenie ruchu
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

    //KURWAAAAAAAA, ZADZIA£A£O ZA PIERWSZYM RAZEM
    //TO JAKAŒ MAGIA ALBO JACYŒ BOGOWIE
    private async void TeleportToTarget()
    {
        //pobiera kierunek w którym musi siê poruszyæ
        Vector3 nextPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        //wyznacza ile musi siê przesun¹æ
        float distance = Mathf.Sqrt(Mathf.Pow(nextPosition.x - transform.position.x, 2) + Mathf.Pow(nextPosition.z - transform.position.z, 2));
        //odejmuje po³owê zasiêgu ataku
        distance -= attackRange / 2;
        //o ile musi siê dok³adnie przesun¹æ
        Vector3 transfer = (nextPosition - transform.position).normalized*distance;
        //wyznacza now¹ pozycjê na któej musi siê znaleŸæ
        nextPosition = transform.position + transfer;
        //odpala animacjê teleportacji
        //przesuwa przeciwnika
        transform.position = nextPosition;
        //obraca go o 90 stopni
        //odpala animacjê pojawiania siê na miejscu
    }

}
