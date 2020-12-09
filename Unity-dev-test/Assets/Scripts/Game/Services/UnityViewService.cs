using UnityEngine;
using Entitas;

public class UnityViewService : IViewService 
{
    public void LoadPrefab(Contexts contexts, GameEntity entity) 
    {
        var viewGameObject = GameObject.Instantiate(entity.resource.prefab);
        
        if (viewGameObject != null)
        {
            var viewController = viewGameObject.GetComponent<IViewController>();
            if (viewController != null)
            {
                viewController.InitializeView(contexts, entity);
                entity.AddViewController(viewController);
            }
        }
        
        var eventListeners = viewGameObject.GetComponents<IEventListener>();
        foreach(var listener in eventListeners) {
            listener.RegisterListeners(entity);
        }
    }
}