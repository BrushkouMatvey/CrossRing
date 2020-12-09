using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Input, CreateAssetMenu, Unique]
public class Globals : ScriptableObject
{
    public GameObject ballPrefab;
    public GameObject RingPrefab;
    public GameObject scorePrefab;
}