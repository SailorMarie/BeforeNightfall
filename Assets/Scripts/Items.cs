using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class Items : ScriptableObject
{
    [field: SerializeField] public ItemType ItemType {  get; set; }
    [field : SerializeField] public string Name { get; set; }
    [field: SerializeField] public string FirstPickUp {  get; set; }
    [field: SerializeField] public string Description { get; set; }
    [field: SerializeField] public Sprite Sprite { get; set; }
    [field: SerializeField] public GameObject InspectorItem { get; set; }
    [field: SerializeField] public GameObject Prefab {  get; set; }


}
    public enum ItemType
    {
        Material = 0,
        Quest = 1,
        RedHerring = 2
    }
