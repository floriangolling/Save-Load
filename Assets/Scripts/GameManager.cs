using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void FinishedLevel()
    {
        SaveLoadManager.saveData(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            instance.FinishedLevel();
        }
    }
}
