using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    static SceneManager instance;
    public static SceneManager Instance { get { instance.Init(); return instance; } }

    private ScreenTransition screenTransition;

    private string currentSceneName = null;
    private bool _init = false;
    private bool _isLoading = false;

    [RuntimeInitializeOnLoadMethod]
    private static void OnApplicationEnter()
    {
        // 씬 매니저
        GameObject go = GameObject.Find($"@{typeof(SceneManager).Name}");
        if (go == null)
            go = new GameObject($"@{typeof(SceneManager).Name}");

        instance = go.AddComponent<SceneManager>();
        DontDestroyOnLoad(go);

        Instance.Init();
    }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (_init)
        {
            return;
        }

        Debug.Log("초기화 시작");
        _init = true;

        // 씬 트랜지션
        GameObject screenTransitionObject = Instantiate(Resources.Load<GameObject>("ScreenTransition"));
        SetCanvas(screenTransitionObject);
        screenTransition = screenTransitionObject.GetComponent<ScreenTransition>();
        if (screenTransition != null)
            Debug.Log("씬 트랜지션 발견");

        screenTransition.CircleSize = 1f;
        DontDestroyOnLoad(screenTransitionObject);
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.IsPressed()) LoadScene("SampleScene");
        if (Keyboard.current.digit2Key.IsPressed()) LoadScene("TheLittlePrince");
        if (Keyboard.current.digit3Key.IsPressed()) LoadScene("ShinSaimdang");
    }

    public IEnumerator LoadSceneCO(string _sceneName)
    {
        yield return StartCoroutine(screenTransition.CircleInCo(1f));

        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);

        //AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_sceneName);
        //op.allowSceneActivation = false;

        //while (!op.isDone)
        //{
        //    yield return null;
        //}

        //op.allowSceneActivation = true;
        //yield return StartCoroutine(screenTransition.CircleOutCo(1f));

        //Debug.Log("씬 변경 완료");
        //_isLoading = true;

    }

    public void LoadScene(string _sceneName)
    {
        if (!_isLoading && currentSceneName != _sceneName)
        {
            Debug.Log("씬 변경중...");
            _isLoading = true;
            StartCoroutine(LoadSceneCO(_sceneName));
        }
    }

    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public string GetCurrentSceneName()
    {
        return currentSceneName;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        Debug.Log("씬 변경 완료");

        StartCoroutine(screenTransition.CircleOutCo(1f, _callback: () => { _isLoading = false; }));

    }

    public void SetCanvas(GameObject _go)
    {
        // GameObject go = GameObject.Find("EventSystem");
        // if (go == null) SetEventSystem();

        Canvas canvas = _go.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        CanvasScaler cs = _go.GetComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
    }
}
