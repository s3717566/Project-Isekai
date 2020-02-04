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
    [Range(1,999)]
    public int MaximumStacks = 1;
    public Sprite Icon;

    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }

    public virtual Item GetCopy() {
return this;
    }

    public virtual void Destroy() {

    }
} 
