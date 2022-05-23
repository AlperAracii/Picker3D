using System.Collections.Generic;

public class PickerManager
{
    private List<CollectableBaseScript> _collectables;

    public PickerManager()
    {
        _collectables = new List<CollectableBaseScript>();
    }

    public void AddCollectable(CollectableBaseScript collectableBase)
    {
        _collectables.Add(collectableBase);
    }

    public void RemoveCollectable(CollectableBaseScript collectableBase)
    {
        _collectables.Remove(collectableBase);
    }

    public List<CollectableBaseScript> GetCollectables()
    {
        return _collectables;
    }

    public void Clear()
    {
        _collectables.Clear();
    }
}
