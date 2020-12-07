using Entitas;

public class ServiceRegistrationSystems  : Feature  {
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        Add(new RegisterViewServiceSystem(contexts, services.View));
    }	
}