﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HyperCasualTemplateHelpers
{
    public class TemplateMenuItems : MonoBehaviour
    {
        [MenuItem("GorgonizeGames Template/Play Current Scene", priority = 1)]
        private static void PlayCurrentScene()
        {
            var currentScene = SceneManager.GetActiveScene();
            EditorSceneManager.SaveScene(currentScene);
            EditorConfigManager.SetTestScene(currentScene.name, currentScene.path);
            EditorSceneManager.OpenScene(GlobalConsts.MainScenePath);
            EditorApplication.EnterPlaymode();
        }

        [MenuItem("GorgonizeGames Template/Play Current Scene", isValidateFunction: true, priority = 2)]
        private static bool PlayCurrentSceneValidation()
        {
            if (Application.isPlaying)
            {
                return false;
            }

            var currentScene = SceneManager.GetActiveScene();
            return CanLoadScene(currentScene.name);
        }

        [MenuItem("GorgonizeGames Template/Go to Main Scene", priority = 12)]
        private static void OpenMainScene()
        {
            var currentScene = SceneManager.GetActiveScene();
            EditorSceneManager.SaveScene(currentScene);
            EditorSceneManager.OpenScene(GlobalConsts.MainScenePath);
        }

        [MenuItem("GorgonizeGames Template/Go to Main Scene", isValidateFunction: true, priority = 13)]
        private static bool OpenMainSceneValidation()
        {
            if (Application.isPlaying)
            {
                return false;
            }

            var currentScene = SceneManager.GetActiveScene();
            return currentScene.name != GlobalConsts.MainSceneName;
        }

        private static bool CanLoadScene(string sceneName)
        {
            return sceneName != GlobalConsts.MainSceneName && sceneName != GlobalConsts.LoadSceneName;
        }
    }
}
#endif
