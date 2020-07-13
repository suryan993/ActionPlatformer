using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerArchetype", menuName = "Player Data", order = 51)]
public class PlayerAssetData : ScriptableObject
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
