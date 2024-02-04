using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField input;
    public TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
       // Wait();
       SetScore();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

    }
    void SetScore()
    {
        score.text = Saving.Instance.HighScore;
    }

    void SetName()
    {
       
        Saving.Instance.Name = input.text;
    
    }

    public void StartNew()
    {
        SetName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
       
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
