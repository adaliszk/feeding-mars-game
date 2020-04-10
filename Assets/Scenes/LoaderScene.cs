using System.Collections;
using System.Threading;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes
{
    public class LoaderScene : MonoBehaviour
    {
        public GameData game;
        public Slider progressBar;

        public void Awake()
        {
            game = Game.GetData();
        }
        
        public void Start()
        {
            LoadScene(game.CurrentScene);
        }

        private void LoadScene(string sceneName)
        {
            StartCoroutine(DoSceneLoadAsynchronously(sceneName));
        }

        private IEnumerator DoSceneLoadAsynchronously(string sceneName)
        {
            progressBar.value = 0;

            var sceneLoading = SceneManager.LoadSceneAsync(sceneName);
            while (!sceneLoading.isDone)
            {
                var progress = Mathf.Clamp01(sceneLoading.progress / .9f);
                progressBar.value = progress;
                yield return null;
            }
            
            game.SetScene(sceneName);
        }
    }
}