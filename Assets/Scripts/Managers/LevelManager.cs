using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance => instance;

    [Space]
    [SerializeField]
    LevelInfoAsset LevelInfoAsset;

    [Space]
    [SerializeField]
    private Transform blockContainer;

    [Space]
    [SerializeField]
    private Transform blockContainer2;
    public int cubeCount;

    private static LevelManager instance;

    BlockSpawner blockSpawner = new BlockSpawner();

    int currentLevelIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        blockSpawner = GetComponent<BlockSpawner>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        cubeCount = blockSpawner.cubeCount;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNextLevel()
    {
        blockSpawner.CreateBlockFromImage(LevelInfoAsset.levelInfos[currentLevelIndex], blockContainer);
        blockSpawner.CreatedCubes(LevelInfoAsset.levelInfos[currentLevelIndex], blockContainer2);
        
        
    }

   
}
