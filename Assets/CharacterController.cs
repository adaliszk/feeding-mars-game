using Data;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterData))]
public class Character : MonoBehaviour
{
    private CharacterData _characterData;

    public void Start()
    {
        _characterData = GetComponent<CharacterData>();
    }
}