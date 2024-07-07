using UnityEngine;

public class LayerChecker : MonoBehaviour
{
    private const string Ground = nameof(Ground);
    private const string Enemy = nameof(Enemy);

    private float _distance = 0.5f;

    public bool CheckGround() => Physics2D.Raycast(transform.position, Vector2.down, _distance, LayerMask.GetMask(Ground));

    public Collider2D CheckEnemies() => Physics2D.OverlapCircle(transform.position, _distance, LayerMask.GetMask(Enemy));
}