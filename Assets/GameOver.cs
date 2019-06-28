using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text Score = null;
    [SerializeField] Text FinalScore = null;
    [SerializeField] Button PlayAgain = null;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayAgain.onClick.AddListener(Reload);
        FinalScore.text = Score.text;
        Score.gameObject.SetActive(false);
    }

    void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
