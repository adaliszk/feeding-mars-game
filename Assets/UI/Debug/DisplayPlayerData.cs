using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Debug
{
    public class DisplayPlayerData : MonoBehaviour
    {
        public CharacterData playerData;
        private bool _isCharacterDataExist;

        private Text _position;
        private bool _isPositionDisplayable;
        
        private Text _lookDirection;
        private bool _isLookDirectionDisplayable;
        
        private Text _moveDirection;
        private bool _isMoveDirectionDisplayable;
        
        private Text _animation;
        private bool _isAnimationDisplayable;

        public void Start()
        {
            if (playerData == null)
                return; // Leave everything to be not displayed
            
            foreach (Transform children in transform)
            {
                if (children.name == "Position") _position = children.GetComponent<Text>();
                if (children.name == "LookDirection") _lookDirection = children.GetComponent<Text>();
                if (children.name == "MoveDirection") _moveDirection = children.GetComponent<Text>();
                if (children.name == "Animation") _animation = children.GetComponent<Text>();
            }
            
            if (_position != null) _isPositionDisplayable = true;
            if (_lookDirection != null) _isLookDirectionDisplayable = true;
            if (_moveDirection != null) _isMoveDirectionDisplayable = true;
            if (_animation != null) _isAnimationDisplayable = true;
        }

        public void LateUpdate()
        {
            if (_isPositionDisplayable)
                _position.text = $"Position: X:{playerData.positionX} Y:{playerData.positionY}";
            
            if (_isLookDirectionDisplayable)
                _lookDirection.text = $"Look Direction: X:{playerData.lookDirectionX} Y:{playerData.lookDirectionY}";
            
            if (_isMoveDirectionDisplayable)
                _moveDirection.text = $"Move Direction: X:{playerData.moveDirectionX} Y:{playerData.moveDirectionY}";
            
            if (_isAnimationDisplayable)
                _animation.text = $"Animation: {playerData.animation}";
        }
    }
}