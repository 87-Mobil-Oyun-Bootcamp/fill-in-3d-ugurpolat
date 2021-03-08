using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCubeControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CloneCube"))
        {
            if (!gameObject.GetComponent<Renderer>().enabled)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                other.gameObject.GetComponent<Collider>().enabled = false;
                other.gameObject.transform.position = gameObject.transform.position;
                other.gameObject.layer = 9;

                Destroy(other.gameObject, 1f);
            }
            

        }
    }
    

}
