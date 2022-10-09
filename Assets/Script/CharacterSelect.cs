using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacters = 0;

    void Start()
    {
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }
        characters[selectedCharacters].SetActive(true);
    }

    public void ChangeCharacter(int newCharacter)
    {
        characters[selectedCharacters].SetActive(false);
        characters[newCharacter].SetActive(true);
        selectedCharacters = newCharacter;
    }
    void Update()
    {
        
    }
}
