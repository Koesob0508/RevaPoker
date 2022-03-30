using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject spritePrefab;
    [SerializeField]
    private float distance;
    [SerializeField]
    private int spriteCount;

    public void GenerateSprites()
    {
        if(transform.childCount != 0)
        {
            for(int i = transform.childCount-1; i>=0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }

        for(int i=0; i<spriteCount; i++)
        {
            var newSprite = Instantiate(spritePrefab);
            newSprite.transform.SetParent(gameObject.transform);
            newSprite.transform.localPosition = new Vector3(0f, 0f, i*distance);
            newSprite.transform.localRotation = Quaternion.identity;
        }
    }

    public void DebugSprites(int _debugNumber)
    {
        Debug.Log(this.gameObject.name + " " + _debugNumber);
    }
}
