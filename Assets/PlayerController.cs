using System;
using Data;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public Camera viewportCamera;
    public CharacterData characterData;

    private Rigidbody2D _player;
    private Vector2 _playerPosition;
    private Vector2 _playerMoveDirection;
    private Vector2 _mouseDirection;

    private Animator _animator;

    #region Lifecycle
    public void Start()
    {
        _player = GetComponent<Rigidbody2D>();
        _player.gravityScale = 0;

        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
        UpdateMoveDirection();
        UpdateMouseDirection();
        UpdateLookDirection();
    }
    
    public void FixedUpdate()
    {
        MovePlayer();
        UpdatePlayerPosition();
        UpdateMouseDirection();
        UpdateLookDirection();
    }
    #endregion

    private void UpdateMouseDirection()
    {
        var mouse = viewportCamera.ScreenToWorldPoint(Input.mousePosition);
        var player = _player.position;

        _mouseDirection = new Vector2
        {
            x = (mouse.x - player.x),
            y = (mouse.y - player.y),
        };
    }


    private void UpdateMoveDirection()
    {
        _playerMoveDirection = new Vector2
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetAxisRaw("Vertical"),
        };
    }


    private static readonly int LookDirectionX = Animator.StringToHash("LookDirectionX");
    private static readonly int LookDirectionY = Animator.StringToHash("LookDirectionY");

    private void UpdateLookDirection()
    {
        _animator.SetFloat(LookDirectionX, _mouseDirection.x);
        _animator.SetFloat(LookDirectionY, _mouseDirection.y);

        characterData.animation = GetCurrentAnimation().name;
        characterData.SetLookDirection(_mouseDirection);
    }
    
    private AnimationClip GetCurrentAnimation()
    {
        var characterAnimationInfo = _animator.GetCurrentAnimatorClipInfo(0);
        return characterAnimationInfo[0].clip;
    }
    
    
    private void MovePlayer()
    {
        _player.MovePosition(
            _player.position + _playerMoveDirection * (characterData.moveSpeed * Time.fixedDeltaTime)
        );
    }

    
    private void UpdatePlayerPosition()
    {
        characterData.SetPosition(_player.position);
    }
}