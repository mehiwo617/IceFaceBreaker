using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButtonScript: MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
