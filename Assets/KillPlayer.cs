using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {


    public void OnTriggerStay(Collider other)
    {
       
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
