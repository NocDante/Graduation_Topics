using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_TouchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
   
        GameObject narrationObject = GameObject.Find("NarrationManager");

        if (narrationObject != null)
        {
        
            NarrationManager narrationmanager = narrationObject.GetComponent<NarrationManager>();
           

            if (narrationmanager != null)
            {
                narrationmanager.StartNarration();
                Destroy(gameObject);

            }
     

        }
     
    }
}
