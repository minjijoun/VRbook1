using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        // ¾À ¸Å´ÏÀú
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

        _init = true;

        currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // ¾À Æ®·£Áö¼Ç
        GameObject screenTransitionObject = Instantiate(Resources.Load<GameObject>("ScreenTransition"));
        SetCanvas(screenTransitionObject);
        screenTransition = screenTransitionObject.GetComponent<ScreenTransition>();
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

        //Debug.Log("¾À º¯°æ ¿Ï·á");
        //_isLoading = true;

    }

    public void LoadScene(string _sceneName)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetSceneByName(_sceneName) == null)
        {
            Debug.Log($"{_sceneName}¾À ÀÌ¸§ÀÌ ºôµå ¸ñ·Ï¿¡ ¾ø½À´Ï´Ù.");
            return;
        }

        if (!_isLoading && currentSceneName != _sceneName)
        {
            Debug.Log("¾À º¯°æÁß...");
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
        StartCoroutine(screenTransition.CircleOutCo(1f, _callback: () => { _isLoading = false; }));

        SetCanvas(screenTransition.gameObject);
        GameObject go = GameObject.Find("EventSystem");
        if (go == null)
        {
            go = new GameObject { name = "EventSystem" };
            go.AddComponent<EventSystem>();
        }
    }

    public void SetCanvas(GameObject _go)
    {
        Canvas canvas = _go.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
        canvas.planeDistance = 0.02f;
        canvas.overrideSorting = true;

        CanvasScaler cs = _go.GetComponent<CanvasScaler>();
        cs.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
    }
}
