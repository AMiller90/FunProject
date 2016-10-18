using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scenechanger : MonoBehaviour
{
    public void Sceneloader (string name)
    {
        SceneManager.LoadScene(name);
    }
}
