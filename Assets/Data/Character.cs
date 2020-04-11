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
        public float moveSpeed = .1f;
        
        // Rendering
        public string animation = "Idle-BottomRight";
        
        public float positionX;
        public float positionY;
        
        public float moveDirectionX;
        public float moveDirectionY;
        
        public float lookDirectionX;
        public float lookDirectionY;

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
        
        public void SetMoveDirection(Vector2 movementDirection)
        {
            moveDirectionX = movementDirection.x;
            moveDirectionY = movementDirection.y;
        }
    }
}