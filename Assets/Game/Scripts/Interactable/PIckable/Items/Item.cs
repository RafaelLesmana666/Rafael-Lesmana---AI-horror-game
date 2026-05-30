using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour, IInteractable, IPickable
{
    [SerializeField]
    private ItemData _itemData;

    public string Name => _itemData.Name;

    public void Interact(PlayerCharacter mc)
    {
        Pickup(mc);
    }

    public UnityEvent OnItemPicked;

    public virtual void Pickup(PlayerCharacter mc)
    {
        ItemData newData = new ItemData(_itemData.ID, _itemData.Name);

        mc.Inventory.AddItem(newData);
        OnItemPicked?.Invoke();

        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
