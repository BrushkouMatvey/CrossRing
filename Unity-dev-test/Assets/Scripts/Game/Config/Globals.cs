using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.UI;

[Game, Input, CreateAssetMenu, Unique]
public class Globals : ScriptableObject
{
    public GameObject ballPrefab;
    public GameObject RingPrefab;
    public Camera camera;
    public GameObject scorePrefab;
    public Button playButtonPrefab;
    public Button restartButtonPrefab;
    public Button menuButtonPrefab;
    
}