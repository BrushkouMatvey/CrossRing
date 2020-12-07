using Entitas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreListener : MonoBehaviour, IEventListener, IScoreListener
{
    private GameEntity _entity;
    
    [SerializeField]
    private Text scoreValue;
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddScoreListener(this);
    }

    public void OnScore(GameEntity entity, int value)
    {
        scoreValue.text = value.ToString();
    }
}