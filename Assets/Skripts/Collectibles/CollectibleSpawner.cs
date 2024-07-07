using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private List<Collectible> _collectibles;
    [SerializeField] private float _spawnDelay = 10f;

    private GroundPlatformStash _groundPlatformStash;
    private List<Ground> _groundPlatforms;

    public void Initialize(GroundPlatformStash groundPlatformStash)
    {
        _groundPlatformStash = groundPlatformStash;
        _groundPlatforms = _groundPlatformStash.GetPlatforms();
        SpawnCollectiblesDelayed();
    }

    private void SpawnCollectiblesDelayed()
    {
        InvokeRepeating(nameof(SpawnCollectibleAtRandomPoint), 0f, _spawnDelay);
    }

    private void SpawnCollectibleAtRandomPoint()
    {
        int randomIndex = SelectRandomIndex(_collectibles.Count);
        Collectible collectible = _collectibles[randomIndex];

        collectible.Appear(GetRandomPosition());
    }

    private int SelectRandomIndex(int elementsCount) => Random.Range(0, elementsCount);

    private Vector2 GetRandomPosition()
    {
        Ground ground = _groundPlatforms[SelectRandomIndex(_groundPlatforms.Count)];
        float positionY = ground.Position.y + 1.5f;
        float startPointX = ground.Position.x - (ground.Scale.x / 2);
        float endPointX = ground.Position.x + (ground.Scale.x / 2);

        return new Vector2(Random.Range(startPointX, endPointX), positionY);
    }
}
