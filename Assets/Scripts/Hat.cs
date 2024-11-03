using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public GameObject bear;  
    public GameObject proBear; 
    public float pickupRange = 2.0f;      
    public LayerMask pickupLayer;    

    private bool isUpgraded = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            CheckForItemPickup();
        }
    }

    private void CheckForItemPickup()
    {
        Collider[] itemsInRange = Physics.OverlapSphere(transform.position, pickupRange, pickupLayer);

        foreach (Collider item in itemsInRange)
        {
            PickupItem(item.gameObject);
            ChangeModel();
            break;
        }
    }

    private void PickupItem(GameObject item)
    {
        Debug.Log("Picked up Hat");
        Destroy(item); //Esto despues deberia hacerle tp a la cabecita del alien
    }
    
    private void ChangeModel()
    {
        if (!isUpgraded)
        {
            bear.SetActive(false);
            proBear.SetActive(true);
            isUpgraded = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
