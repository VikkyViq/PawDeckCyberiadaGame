using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueBox : MonoBehaviour
{
    public string cardScene;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCards()
    {
        SceneManager.LoadScene(cardScene);
    }

    public void Leave()
    {
        parent.gameObject.SetActive(false);
    }
}
