
public interface IComponentEntity
{
    public void Initialize(Entity entity);
    public void Activate();
    public void Tick();
    public void Disable();
}
