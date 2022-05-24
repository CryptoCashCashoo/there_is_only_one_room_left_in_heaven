using UnityEngine;
using UnityEngine.SceneManagement;


public enum ScenesEnum
{
    MainMenu,
    Level1,
    Level2,
    Level3,
    Level4,
}

public class SceneLoader : MonoBehaviour
{

    public void Level1()
    {
        SceneManager.LoadScene((int)ScenesEnum.Level1);
    }

    public void Level2()
    {
        SceneManager.LoadScene((int)ScenesEnum.Level2);
    }

    public void Level3()
    {
        SceneManager.LoadScene((int)ScenesEnum.Level3);
    }

    public void Level4()
    {
        SceneManager.LoadScene((int)ScenesEnum.Level4);
    }

}
