using UnityEngine;

namespace RPG.CharacterGeneration
{
    public class CharacterGenerator: ICharacterGenerator
    {
        private static readonly string _assetBundlePath = Application.streamingAssetsPath + "/characters";
        private static GameObject _generatedCharacter;
        private static GameObject[] _characterPrefabs;

        public CharacterGenerator()
        {
            AssetBundle assetBundle = AssetBundle.LoadFromFile(_assetBundlePath);
            if (assetBundle == null)
            {
                Debug.LogError($"Failed to load asset bundle from {_assetBundlePath}");
                return;
            }

            _characterPrefabs = assetBundle.LoadAllAssets<GameObject>();
            if (_characterPrefabs == null || _characterPrefabs.Length == 0)
            {
                Debug.LogError($"No character prefabs found in {_assetBundlePath}. Cannot generate character.");
            }

            assetBundle.Unload(false);
        }

        public void GenerateCharacter()
        {
            if (_characterPrefabs == null || _characterPrefabs.Length == 0)
            {
                Debug.LogError($"No character prefabs found in {_assetBundlePath}. Cannot generate character.");
                return;
            }

            int index = Random.Range(0, _characterPrefabs.Length);

            if (_characterPrefabs[index] == _generatedCharacter)
            {
                GenerateCharacter();
                return;
            }

            if (_generatedCharacter != null)
            {
                Object.Destroy(_generatedCharacter);
            }

            _generatedCharacter = Object.Instantiate(_characterPrefabs[index], Vector2.zero, Quaternion.identity);
            _generatedCharacter.tag = "Player";
            Object.DontDestroyOnLoad(_generatedCharacter);
        }
    }
}