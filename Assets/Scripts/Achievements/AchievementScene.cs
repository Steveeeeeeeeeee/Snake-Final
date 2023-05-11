using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementScene : MonoBehaviour
{
    // Start is called before the first frame update

    private static int selectedPlayer;

    
   public void LoadPlayerScene()
    {

        SceneManager.LoadScene("PlayerScene");
        DataPersistenceManager.Instance.SaveGame();
    }
}
