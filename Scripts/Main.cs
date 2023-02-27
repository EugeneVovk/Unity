using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // метод перезагрузки уровня после проигрыша
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
