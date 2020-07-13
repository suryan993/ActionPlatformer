using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectArchetype", menuName = "Object Data", order = 52)]
public class ObjectAssetData : ScriptableObject
{
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;

    public Mesh Mesh
    {
        get
        {
            return mesh;
        }
    }

    public Material Material
    {
        get
        {
            return material;
        }
    }

}
