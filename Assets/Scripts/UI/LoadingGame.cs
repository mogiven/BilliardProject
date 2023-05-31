using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Playground");
    }
}
