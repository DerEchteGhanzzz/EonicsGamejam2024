using Lib.Player;
using UnityEngine;

namespace Lib.Hazard
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] protected float speed;
        protected float _direction;

        protected virtual void Start()
        {
            _direction = FindFirstObjectByType<AbstractPlayerController>().transform.position.x < transform.position.x
                ? -1f
                : 1f;
            Destroy(gameObject, 5f);
        }

        protected virtual void FixedUpdate()
        {
            transform.position += Vector3.right * (_direction * Time.fixedDeltaTime * speed);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<AbstractPlayerController>().Hurt();
            }
        }
    }
}