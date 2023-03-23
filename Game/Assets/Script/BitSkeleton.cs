using UnityEngine;

[CreateAssetMenu(fileName = "Bit Skeleton", menuName = "Scriptable Object/Bit Skeleton", order = int.MaxValue)]

public class BitSkeleton: ScriptableObject
{
    [SerializeField]
    private string bitName;
    public string BitName { get { return bitName;}}
    [SerializeField]
    private string bitDescription;
    public string BitDescription { get { return bitDescription;}}
    public Bits bit;
}
