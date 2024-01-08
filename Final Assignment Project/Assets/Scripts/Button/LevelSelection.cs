using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level01()
    {
        SceneManager.LoadScene(2);
    }
    public void Level02()
    {
        SceneManager.LoadScene(3);
    }
    public void Level11()
    {
        SceneManager.LoadScene(4);
    }
    public void Level12()
    {
        SceneManager.LoadScene(5);
    }
    public void Level13()
    {
        SceneManager.LoadScene(6);
    }
    public void Level21()
    {
        SceneManager.LoadScene(7);
    }
    public void Level22()
    {
        SceneManager.LoadScene(8);
    }


}
