using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private SaveLvl _saveLvl;
    private void Start()
    {
        _saveLvl = new SaveLvl();
    }

    public void RestartButton ()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartProgressButton()
    {
        _saveLvl.DeleteSavedDifficult();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
