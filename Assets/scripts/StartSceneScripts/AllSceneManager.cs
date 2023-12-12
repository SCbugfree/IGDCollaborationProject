using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllSceneManager : MonoBehaviour
{
    // Change Scene
    public static void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
