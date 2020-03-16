using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int zombieCount = 0;

    void Awake()
    {
        zombieCount = GameObject.FindGameObjectsWithTag("Zombie").Length;
        //do not remove
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        RecordZombieDeath();
    }

    private void RecordZombieDeath()
    {
        if (zombieCount == 0)
        {
            SceneManager.LoadScene("GameComplete");
        }
    }
}
