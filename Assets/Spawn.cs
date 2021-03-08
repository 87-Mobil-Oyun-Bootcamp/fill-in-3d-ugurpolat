using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    int count = 862;
    int i = 0;
    Vector3 spawnPos = Vector3.zero;
    public GameObject cube;
    public Transform a;
    public float offSet = 0.2f;


    // Start is called before the first frame update
    void Start()
    {

        MakeBlock();

    }

    public void MakeBlock()
    {


        CountBlock();
          
    }

    void CountBlock()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int z = 0; z < 5; z++)
                {

                    spawnPos = new Vector3(
                                        x * cube.transform.localScale.x,
                                        y * cube.transform.localScale.y + 0.05f,
                                        z * cube.transform.localScale.z);
                    GameObject cubeObj = Instantiate(cube, transform);
                    cubeObj.transform.localPosition = spawnPos;
                    cubeObj.transform.parent = transform;
                    i++;
                    cubeObj.name = "" + i;

                    if (i > 22)
                    {
                        return;
                    }
                }


            }

        }



    }
}

        //for (int x = 0; x < 16; x++)
        //{
        //    for (int y = 0; y < 16; y++)
        //    {

        //        for (int i = 0; i < length; i++)
        //        {

        //        }
        //        Color color = levelInfo.sprite.texture.GetPixel(x, y);

        //        if (color.a == 0)
        //        {
        //            continue;
        //        }

        //        blockPos2 = new Vector3(
        //            levelInfo.size * (x - (levelInfo.sprite.texture.width * .5f)),
        //            levelInfo.size * .5f,
        //            levelInfo.size * (y - (levelInfo.sprite.texture.height * .5f)));

        //        GameObject cubeObj = Instantiate(levelInfo.baseObj, transform);
        //        cubeObj.transform.localPosition = blockPos2;

        //        cubeObj.GetComponent<Renderer>().material.color = Color.green;
        //        cubeObj.transform.localScale = Vector3.one * levelInfo.size;

        //        createdCubes.Add(cubeObj);
        //    }
        //}
        //cubeCount = createdCubes.Count;


        //return createdCubes;