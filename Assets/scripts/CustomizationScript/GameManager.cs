using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    // Singleton pattern 
    public static GameManager Instance { get; private set;}

    private Transform canvas;
    public Transform mummyPos;
    public GameObject mummy_instance;
    public GameObject MummyPrefab;

    //public GameManager mummy_instance;
    //private GameManager MummyPrefab;

    [Header("Mummy Profile")]

    [SerializeField] string name;
    [SerializeField] Color headColor;
    [SerializeField] Color skinColor;


    [Header("Choices record")]

    public int score = 90;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Subscribe to the event when script is enabled
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // Unsubscribe from the event when the script is disabled
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    // Called when a new scene loads
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        canvas = FindCanvas();
        mummyPos = FindMummyPos();
        LoadMummyPrefab(canvas, mummyPos);
    }


    // Fetch canvas
    private Transform FindCanvas()
    {
        canvas = GameObject.FindWithTag("canvas").transform;
        return canvas;
    }


    // Fetch MummyPosition in the scene
    private Transform FindMummyPos()
    {
        mummyPos = GameObject.FindWithTag("mummypos").transform;

        if (mummyPos == null)
        {
            mummyPos = Instantiate(mummyPos, canvas);
            mummyPos.transform.position = new Vector3(1000f, -1000f, 0f);
            Debug.Log("null finding hence assigned pos");
        }

        return mummyPos;
    }


    // Load and instantiate Mummy Prefab
    private void LoadMummyPrefab(Transform canvas, Transform mummyPos)
    {
        MummyPrefab = Resources.Load("Mummy") as GameObject;
        mummy_instance = Instantiate(MummyPrefab, canvas);
        mummy_instance.transform.position = mummyPos.position;

        //mummy_instance = (GameManager) PrefabUtility.InstantiatePrefab(MummyPrefab);
        //mummy_instance.gameObject.transform.SetParent(canvas);
        //mummy_instance.gameObject.transform.position = mummyPos.position;
        //var m_i = mummy_instance.gameObject;
    }


    // Change Scene
    public static void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    // Record player choices in Mummy customization
    public void GetPlayerBuiltMummy()
    {
        if (mummy_instance != null)
        {
            PrefabUtility.ApplyPrefabInstance(mummy_instance, InteractionMode.AutomatedAction);

            EditorUtility.SetDirty(MummyPrefab);
            AssetDatabase.SaveAssets();
            Debug.Log("Prefab modified");
        }
    }


    // Record player choices in dialogues: to be used in ScoreCalculator in Final Scene
    public void RecordChoice(int score_got)
    {
        score += score_got;
    }
}
