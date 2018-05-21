using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject _receiverObject;

    [SerializeField]
    private bool isFire;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        if (isFire)
        {
            return;
        }
 
        _receiverObject.GetComponent<ReceiverTrigger>().SendMessage("FireLaser");
        isFire = true;
    }
}
