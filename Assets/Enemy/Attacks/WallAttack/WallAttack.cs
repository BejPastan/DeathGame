using UnityEngine;
using System.Threading.Tasks;

public class WallAttack : EnemyAttack
{
    [SerializeField]
    GameObject wallPartPref;
    [SerializeField]
    Animator animator;

    [Header("Ustawienia Ataku")]

    [SerializeField]
    float timeToNextWallPart;
    [SerializeField]
    float wallPartsInUnit;
    [SerializeField]
    float wallPartsDispersion;
    [SerializeField]
    int wallMaxLength;


    public async override Task Attack()
    {
        //ustawai kierunek
        transform.LookAt(player);
        //odpala animację ataku
        animator.SetBool("Wall", true);
        float timeToWait = animator.GetCurrentAnimatorStateInfo(0).length;
        //czeka do końca animacji
        await Task.Delay((int)(timeToWait*1000));
        
        bool canCreate = true;
        Rigidbody wallPhisics;
        Collider triggerBox;
        int wallSize=0;
        Transform wallPart;

        Vector3 nextPosition;
        //tutaj muszę obliczyć wektopr przesunięcia kolejnych fragmentó ściany
        nextPosition = transform.forward/(wallPartsInUnit);
        

        while (canCreate)
        {
            wallSize++;
            //muszę tutaj jakoś determinować w którym miejscu pojawia się kolejny fragment wall'a
            //tworzy kolejne fragmenty wall'a
            Vector3 position = (nextPosition * wallSize) + transform.position + new Vector3(Random.Range(-wallPartsDispersion, wallPartsDispersion), -1f, Random.Range(-wallPartsDispersion, wallPartsDispersion));
            Quaternion rotation = transform.rotation;
            rotation.y = Random.rotation.y;
            wallPart = Instantiate(wallPartPref, position, rotation).transform;
            wallPhisics = wallPart.GetComponentsInChildren<Rigidbody>()[1];

            //sprawdza czy nie uderzają w przeszkodę
            triggerBox = wallPhisics.transform.GetComponent<Collider>();

            Collider[] colliders;

            colliders = Physics.OverlapBox(triggerBox.bounds.center, triggerBox.bounds.extents);

            foreach(Collider collider in colliders)
            {
                if(collider.tag == "Obstacle")
                {
                    canCreate = false;
                }
            }
            
            //to jest tylko na chwilę żeby się nie wypierdoliła pętla
            if(wallSize == wallMaxLength)
            {
                canCreate = false;
            }
            await Task.Delay((int)(1000*timeToNextWallPart));
        }
        //kończy atak
        animator.SetBool("Wall", false);
    }
}
