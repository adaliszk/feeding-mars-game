using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Game/Character")]
    public class CharacterData : ScriptableObject
    {
        // Lore
        public new string name;
        public string introduction;
        public Texture2D avatar;
        
        // Gameplay
        public int hunger = 4;
        public float moveSpeed = 3f;
        
        // Rendering
        public string animation = "Idle-BottomRight";
        
        public float positionX = 0;
        public float positionY = 0;

        public float lookDirectionX = 0;
        public float lookDirectionY = 0;

        public void SetPosition(Vector2 position)
        {
            positionX = position.x;
            positionY = position.y;
        }

        public void SetLookDirection(Vector2 lookingDirection)
        {
            lookDirectionX = lookingDirection.x;
            lookDirectionY = lookingDirection.y;
        }
    }
}