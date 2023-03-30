using UnityEngine.SceneManagement;

namespace RPG.GameManagement
{
    public class SceneController : ISceneController
    {
        //button event
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        //button event
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}
