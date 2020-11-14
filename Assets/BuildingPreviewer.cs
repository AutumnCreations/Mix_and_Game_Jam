using UnityEngine;

public class BuildingPreviewer : MonoBehaviour
{
    [SerializeField] Building buildingToInstantiate;

    private SpriteRenderer buildingSprite;

    private void Awake()
    {
        buildingSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        buildingSprite.sprite = buildingToInstantiate.GetComponentInChildren<SpriteRenderer>().sprite;
        buildingSprite.color = new Color(buildingSprite.color.r, buildingSprite.color.g, buildingSprite.color.b, .5f);
    }
}
