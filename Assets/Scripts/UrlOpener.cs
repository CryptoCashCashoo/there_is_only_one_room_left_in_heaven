using UnityEngine;


public class UrlOpener : MonoBehaviour
{
    public void Open(string url)
    {
        Application.OpenURL(url);
    }
}
