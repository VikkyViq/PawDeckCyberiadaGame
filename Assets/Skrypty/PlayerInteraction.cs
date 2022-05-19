using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;

    public bool canInteract;
    public bool interact;

    public Material mat;
    public Material glow;

    public GameObject interactObject;
    
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(interactObject != null)
        {
            interactObject.SetActive(false);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            interact = false;
        }

        if(canInteract)
        {
            GetComponent<MeshRenderer>().material = glow;
        }
        else
        {
            GetComponent<MeshRenderer>().material = mat;
        }

        if(interact)
        {
            interactObject.SetActive(true);
        }
        else
        {
            interactObject.SetActive(false);
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

        interact = true;
    }
}
