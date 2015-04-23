using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    
    public void NextScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

}
