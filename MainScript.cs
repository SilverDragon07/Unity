//クリックした二点で長方形を書くスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainScript : MonoBehaviour
{
    GameObject Tile;
    GameObject TilesParent;
    float size = 0.8f;
    Sprite[] TileSprite = new Sprite[2];

    GameObject[,] Stage = new GameObject[10, 10];
    bool firstSelect = true;
    int firstX, firstY, secondX, secondY;

    void Start()
    {
        TileSprite[0] = Resources.Load<Sprite>("Tile_Off");
        TileSprite[1] = Resources.Load<Sprite>("Tile_On");

        Tile = Resources.Load<GameObject>("Prefabs/Tile");
        TilesParent = GameObject.Find("TilesParent");

        for(int y = 0; y < 10; y++)
        {
            for(int x = 0; x < 10; x++)
            {
                Stage[x, y] = Instantiate(Tile, new Vector2(x * size, y * size), Quaternion.identity, TilesParent.transform);
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (firstSelect)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                double mouseSelectedX = Math.Round(mousePosition.x * 10 / 8, MidpointRounding.AwayFromZero);
                double mouseSelectedY = Math.Round(mousePosition.y * 10 / 8, MidpointRounding.AwayFromZero);
                firstX = (int)mouseSelectedX;
                firstY = (int)mouseSelectedY;

                Stage[firstX, firstY].GetComponent<SpriteRenderer>().sprite = TileSprite[1];

                firstSelect = !firstSelect;
            }
            else
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                double mouseSelectedX = Math.Round(mousePosition.x * 10 / 8, MidpointRounding.AwayFromZero);
                double mouseSelectedY = Math.Round(mousePosition.y * 10 / 8, MidpointRounding.AwayFromZero);
                secondX = (int)mouseSelectedX;
                secondY = (int)mouseSelectedY;
                SpriteChange();
          
                firstSelect = !firstSelect;
            }
        }
    }


    void SpriteChange()
    {
        if (firstY < secondY)
        {
            for (int y = firstY; y <= secondY; y++)
            {
                if (firstX < secondX)
                {
                    for (int x = firstX; x <= secondX; x++)
                    {
                        Stage[x, y].GetComponent<SpriteRenderer>().sprite = TileSprite[1];
                    }
                }
                else
                {
                    for (int x = firstX; x >= secondX; x--)
                    {
                        Stage[x, y].GetComponent<SpriteRenderer>().sprite = TileSprite[1];
                    }
                }
            }
        }
        else
        {
            for (int y = firstY; y >= secondY; y--)
            {
                if (firstX < secondX)
                {
                    for (int x = firstX; x <= secondX; x++)
                    {
                        Stage[x, y].GetComponent<SpriteRenderer>().sprite = TileSprite[1];
                    }
                }
                else
                {
                    for (int x = firstX; x >= secondX; x--)
                    {
                        Stage[x, y].GetComponent<SpriteRenderer>().sprite = TileSprite[1];
                    }
                }
            }
        }
    }
}
