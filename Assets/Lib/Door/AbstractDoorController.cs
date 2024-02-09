using UnityEngine;

namespace Lib.Door
{
    public abstract class AbstractDoorController : MonoBehaviour
    {
        [SerializeField] private Sprite altSprite;
        private bool _opened;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && CanOpen())
            {
                FindFirstObjectByType<LevelController>().NextLevel();
            }
        }

        protected virtual bool CanOpen()
        {
            return _opened;
        }

        /**
         * This method is called by the LightSwitch if the player interacts with it. This opens the door to the
         * next level.
         */
        public void OpenDoor()
        {
            if (_opened) return;
            _opened = true;
            GetComponent<SpriteRenderer>().sprite = altSprite;
        }
    }
}