using UnityEngine;

public class BuildingPreviewer : MonoBehaviour
{
    [SerializeField] public Building buildingToInstantiate;

    private SpriteRenderer buildingSprite;

    public void SetBuildingSprite()
    {
        buildingSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        buildingSprite.sprite = buildingToInstantiate.GetComponentInChildren<SpriteRenderer>().sprite;
        buildingSprite.color = new Color(buildingSprite.color.r, buildingSprite.color.g, buildingSprite.color.b, .5f);

        if (buildingSprite.sprite.rect.height < 600)
        {
            transform.GetChild(0).localPosition = new Vector3(0, .333f, -1);
        }
        else 
        {
            transform.GetChild(0).localPosition = new Vector3(0, .546f, -1);
        }

    }
}
