using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLvl : MonoBehaviour
{
    public void SaveDifficult(int lvl)
    {
        PlayerPrefs.SetInt("Difficult", lvl);
    }

    public int GetSavedDifficult ()
    {
        return PlayerPrefs.GetInt("Difficult", 0);
    }

    public void DeleteSavedDifficult ()
    {
        PlayerPrefs.DeleteKey("Difficult");
    }
}
