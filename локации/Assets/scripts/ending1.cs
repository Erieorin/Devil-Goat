using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending1 : MonoBehaviour
{
    public string sceneToLoad;
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

