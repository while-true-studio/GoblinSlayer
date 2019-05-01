using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReseter : MonoBehaviour {
    private static bool initialized = false;
    private void Awake()
    {
        if (!initialized)
        {
            initialized = true;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.F9))
            SceneManager.LoadScene(2);
        if (Input.GetKey(KeyCode.F10))
            SceneManager.LoadScene(1);
	}
}
