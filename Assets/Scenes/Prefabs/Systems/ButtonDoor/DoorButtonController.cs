using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonController : MonoBehaviour
{
    [SerializeField]
    Transform door;
    [SerializeField]
    string triggerEntityTag;
    [SerializeField]
    Animator animController;

    int openDoor;

    private void Start()
    {
        animController = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == triggerEntityTag)
        {
            openDoor++;
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == triggerEntityTag)
        {
            openDoor--;
            if(openDoor==0)
            {
                CloseDoor();
            }
        }
    }

    public void OpenDoor()
    {
        animController.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        animController.SetBool("DoorOpen", false);
    }
}
