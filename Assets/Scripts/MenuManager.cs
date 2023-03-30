using UnityEngine;
using RPG.CharacterGeneration;

namespace RPG.GameManagement
{
    public class MenuManager : MonoBehaviour
    {
        private ICharacterGenerator _characterGenerator;
        private ISceneController _sceneController;

        private void Awake()
        {
            _characterGenerator = new CharacterGenerator();
            _sceneController = new SceneController();
        }

        public void OnGenerateCharacter()
        {
            _characterGenerator.GenerateCharacter();
        }

        public void OnLoadScene(string name)
        {
            _sceneController.LoadScene(name);
        }

        public void OnLoadScene(int index)
        {
            _sceneController.LoadScene(index);
        }
    }
}
