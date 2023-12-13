using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{

    // Singleton pattern 
    public static GameManager Instance { get; private set;}

    private Transform canvas;
    public Transform mommyPos;
    public GameObject mommy_instance;
    public GameObject MommyPrefab;

    //public GameManager mummy_instance;
    //private GameManager MummyPrefab;

    [Header("Mommy Profile")]

    //[SerializeField] string name;

    [SerializeField] Color hairColor;

    [SerializeField] Color skinColor;

    [SerializeField] Sprite body_choice;

    [SerializeField] Sprite hair_choice;

    [SerializeField] Sprite nose_choice;

    [SerializeField] Sprite brows_choice;

    [SerializeField] Sprite eyes_choice;

    [SerializeField] Sprite head_choice;

    [SerializeField] Sprite mouth_choice;

    [SerializeField] Sprite clothing_choice;


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
        mommyPos = FindMommyPos();
        LoadMommyPrefab(canvas, mommyPos);
    }


    // Fetch canvas
    private Transform FindCanvas()
    {
        canvas = GameObject.FindWithTag("canvas").transform;
        return canvas;
    }


    // Fetch MummyPosition in the scene
    private Transform FindMommyPos()
    {
        mommyPos = GameObject.FindWithTag("mommypos").transform;

        if (mommyPos == null)
        {
            mommyPos = Instantiate(mommyPos, canvas);
            mommyPos.transform.position = new Vector3(1000f, -1000f, 0f);
            Debug.Log("null finding hence assigned pos");
        }

        return mommyPos;
    }


    // Load and instantiate Mummy Prefab
    private void LoadMommyPrefab(Transform canvas, Transform mommyPos)
    {
        MommyPrefab = Resources.Load("Mommy") as GameObject;
        mommy_instance = Instantiate(MommyPrefab, canvas);
        mommy_instance.transform.position = mommyPos.position;

        //mummy_instance = (GameManager) PrefabUtility.InstantiatePrefab(MummyPrefab);
        //mummy_instance.gameObject.transform.SetParent(canvas);
        //mummy_instance.gameObject.transform.position = mummyPos.position;
        //var m_i = mummy_instance.gameObject;

        Image[] mommyComponents = mommy_instance.GetComponentsInChildren<Image>();
        Scene scene = SceneManager.GetActiveScene();

        if (mommyComponents.Length > 0 && (scene.name != "CustomizationScene"))
        {
            foreach (Image image in mommyComponents)
            {
                switch (image.tag)
                {
                    case "body":
                        image.sprite = body_choice;
                        image.color = skinColor;
                        break;

                    case "head":
                        image.sprite = head_choice;
                        image.color = skinColor;
                        break;

                    case "eyes":
                        image.sprite = eyes_choice;
                        break;

                    case "brows":
                        image.sprite = brows_choice;
                        image.color = hairColor;
                        break;

                    case "nose":
                        image.sprite = nose_choice;
                        break;

                    case "mouth":
                        image.sprite = mouth_choice;
                        break;

                    case "hair":
                        image.sprite = hair_choice;
                        image.color = hairColor;
                        break;

                    case "clothing":
                        image.sprite = clothing_choice;
                        break;
                }
            }
        }
    }


    // Record player choices in Mommy customization
    public void GetPlayerBuiltMommy(Sprite[] sprites)
    {
        if (mommy_instance != null)
        {
            //PrefabUtility.ApplyPrefabInstance(mommy_instance, InteractionMode.AutomatedAction);
            //EditorUtility.SetDirty(MummyPrefab);
            //AssetDatabase.SaveAssets();
            //Debug.Log("Prefab modified");

            body_choice = sprites[0];
            head_choice = sprites[1];
            eyes_choice = sprites[2];
            nose_choice = sprites[3];
            brows_choice = sprites[4];
            mouth_choice = sprites[5];
            hair_choice = sprites[6];
            clothing_choice = sprites[7];
        }
    }

    // Record player choice of color
    public void GetPlayerColor(Color hair, Color skin)
    {
        hairColor = hair;
        skinColor = skin;
    }


    // Record player choices in dialogues: to be used in ScoreCalculator in Final Scene
    public void RecordChoice(int score_got)
    {
        score += score_got;
    }
}
