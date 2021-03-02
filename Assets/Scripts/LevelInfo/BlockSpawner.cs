using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    Vector3 blockPos = Vector3.zero;
    Vector3 blockPos2 = Vector3.zero;
    int i = 0;
    public  int cubeCount;
    public List<GameObject> CreateBlockFromImage(LevelInfo levelInfo, Transform transform)
    {
        int i = 0;
        List<GameObject> createdCubes = new List<GameObject>();
        for (int x = 0; x < levelInfo.sprite.texture.width; x++)
        {
            for (int y = 0; y < levelInfo.sprite.texture.height; y++)
            {
                Color color = levelInfo.sprite.texture.GetPixel(x, y);

                if (color.a == 0)
                {
                    continue;
                }

                blockPos = new Vector3(
                    levelInfo.size * (x - (levelInfo.sprite.texture.width * .5f)),
                    levelInfo.size * .5f,
                    levelInfo.size * (y - (levelInfo.sprite.texture.height * .5f)));

                GameObject cubeObj = Instantiate(levelInfo.baseObj, transform);
                cubeObj.transform.localPosition = blockPos;
                cubeObj.name = ""+i;
                cubeObj.tag = "BaseCube";
                cubeObj.layer = 9;

                cubeObj.GetComponent<Rigidbody>().useGravity = false;
                cubeObj.GetComponent<Renderer>().material.color = color;
                cubeObj.GetComponent<BoxCollider>().isTrigger = true;
                cubeObj.transform.localScale = Vector3.one * levelInfo.size;
                cubeObj.GetComponent<Renderer>().enabled = false;
                createdCubes.Add(cubeObj);
                
                i++;
            }
        }
        cubeCount = createdCubes.Count;
        Debug.Log(cubeCount);
        return createdCubes;
    }

    public void CreatedCubes(LevelInfo levelInfo, Transform transform)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                for (int z = 0; z < 16; z++)
                {

                    blockPos2 = new Vector3(
                                        x * levelInfo.size,
                                        y * levelInfo.size + 0.05f,
                                        z * levelInfo.size);
                    GameObject cubeObj = Instantiate(levelInfo.baseObj, transform);
                    cubeObj.transform.localPosition = blockPos2;
                    cubeObj.transform.parent = transform;
                    i++;
                    cubeObj.name = "" + i;
                    cubeObj.tag = "CloneCube";
                    cubeObj.layer = 10;

                    if (i > cubeCount -1)
                    {
                        return;
                    }
                }


            }

        }
    }


}
