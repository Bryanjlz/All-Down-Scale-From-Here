using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FullSceneChanger : MonoBehaviour
{
    [SerializeField]
    string NextScene;

	public void ChangeScene() {
		SceneManager.LoadScene(NextScene);
	}
}
