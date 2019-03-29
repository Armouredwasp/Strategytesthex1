using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenceswitcher : MonoBehaviour
{
 public void Switchtomapeditor()
    {
        SceneManager.LoadScene(sceneName: "debugMapeditor");
    }
}
