using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoad = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoad));

        private IEnumerator LoadScene(string nextScene, Action onLoad = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoad?.Invoke();
                yield break;
            }
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);
            while (!waitNextScene.isDone)
                yield return null;

            onLoad?.Invoke();

        }
    }
}