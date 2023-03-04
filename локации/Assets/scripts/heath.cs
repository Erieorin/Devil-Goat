using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heath : MonoBehaviour
{
    public string sceneToLoad;
    public int maxHealth = 1;
    public int health;
    public playermovement lol;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!lol.hiding)
        {
            health -= damage;
            if (health <= 0)
            {
                //Destroy(gameObject);
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
