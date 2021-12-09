using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private Animator m_animator;
    private string m_nextLevelName;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void FadeToLevel(string sceneName)
    {
        m_animator.SetTrigger("FadeOut");
        m_nextLevelName = sceneName;
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(m_nextLevelName);
    }
}
