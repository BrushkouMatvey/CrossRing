using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IViewController
{
    protected Contexts _contexts;
    protected GameEntity _entity;

    public Vector2 Position
    {
        get {return transform.position;} 
        set {transform.position = value;}
    }

    public Vector2 Scale
    {
        get {return transform.localScale;} 
        set {transform.localScale = value;}
    }
    
    public void InitializeView(Contexts contexts, IEntity entity) {
        _contexts = contexts;
        _entity = (GameEntity)entity;
        gameObject.Link(_entity);
    }

    public void DestroyView() 
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}