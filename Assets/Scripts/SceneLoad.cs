using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void UpdateBestScorTable()
    {
        GameManager.Instance.UpdateBestScorTable();
    }
}
