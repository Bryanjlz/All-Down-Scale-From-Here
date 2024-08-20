using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneChanger : MonoBehaviour
{
    [SerializeField]
    string NextScene;
    [SerializeField]
    string SceneToUnload;
    
    public void LoadScene () {
        SceneManager.LoadSceneAsync(NextScene, LoadSceneMode.Additive);
    }
    public void LoadScene (string scene) {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }

    public void UnloadScene () {
        SceneManager.UnloadSceneAsync(SceneToUnload);
    }
    public void UnloadScene (string scene) {
        SceneManager.UnloadSceneAsync(scene);
    }

    public void ChangeScene () {
        LoadScene();
        UnloadScene();
    }
}
