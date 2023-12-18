using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Image _loader;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fillSpeed;

    private AsyncOperation _asyncOperation;

    void Start()
    {
        _loader.fillAmount = 0;
        //_canvasGroup.alpha = 0;
    }

    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        _asyncOperation = SceneManager.LoadSceneAsync(1);
        _asyncOperation.allowSceneActivation = false;

        while (_loader.fillAmount < 0.9f)
        {
            _canvasGroup.alpha += Time.deltaTime;
            _loader.fillAmount = Mathf.Lerp(_loader.fillAmount, Mathf.Clamp01(_asyncOperation.progress * 100), Time.deltaTime * _fillSpeed);

            Debug.Log(Mathf.Clamp01(_asyncOperation.progress * 100));

            yield return null;
        }

        yield return new WaitUntil(() => _loader.fillAmount >= 0.8f);

        Debug.Log("Load scene: " + _asyncOperation.isDone);

        _asyncOperation.allowSceneActivation = true;
    }
}