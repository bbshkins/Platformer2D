using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _moveSpeed;
     
    private AnimatorToggler _animatorToggler;

    public void Initialize(Animator animator)
    {
        _animatorToggler = new AnimatorToggler(animator);
        _animatorToggler.SetRunBool(true);
    }

    private void Update() => Patrol();

    private void Patrol()
    {
        if (_groundChecker.CheckGround() == false)
            Rotate();

        transform.Translate(transform.right * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void Rotate()
    {
        if (transform.rotation.y > 0)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 180));
    }
}
