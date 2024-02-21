using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class InitManager : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene((int)Scenes.Game);
        }
    }
}
