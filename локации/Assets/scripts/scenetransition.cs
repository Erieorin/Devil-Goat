using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenetransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public vectorvalue playerStorage;
    public bool playerinrange;

    void Update()
    {
        if (Input.GetKeyDown("e") && playerinrange)
        {
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
            playerinrange = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerinrange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        { 
            playerinrange = false;
        }
    }
}
