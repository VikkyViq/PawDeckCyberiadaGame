using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool canInteract;

    public Material mat;
    public Material glow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract)
        {
            GetComponent<MeshRenderer>().material = glow;
        }
        else
        {
            GetComponent<MeshRenderer>().material = mat;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void OnMouseDown()
    {
        if(canInteract)
        {
            Debug.Log(gameObject.name + " Interakcja");
        }
    }
}
