using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemName;
    public string Desc;

    [Range(1,999)]
    public int MaximumStacks = 1;
    public Sprite Icon;

    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);

        //to make it work with webgl (pfft, collisions are rare anyway)
        //System.Random random = new System.Random();
        //id = random.Next(10000000).ToString();
    }

    public virtual Item GetCopy() {
return this;
    }

    public virtual void Destroy() {

    }
} 
