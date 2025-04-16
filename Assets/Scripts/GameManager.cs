using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    CustomDoubleCircleList<Character> list = new CustomDoubleCircleList<Character>();
    [SerializeField] Button buttonCreateCharacter;
    [SerializeField] Button buttonShowCharacter;
    [SerializeField] Button buttonDeleteCharacter;

    float direction;


    private void Start()
    {
      //  buttonCreateCharacter.onClick.AddListener(CreateCharacter);
        buttonShowCharacter.onClick.AddListener(ShowCurrentCharacter);
        buttonDeleteCharacter.onClick.AddListener(DeleteAllCharacter);
    }

    private void Update()
    {
        ChangueCurrentCharacter(direction);
    }

    [Button]
    void CreateCharacter(string name)
    {
        Character character = new Character(name);
        list.Add(character);
        Debug.Log("Character created: " + character.NameCharacter);
    }
    [Button]

    public void MovemententListCharacters(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed) return;
           
        direction = context.ReadValue<float>();
    }


    public void ChangueCurrentCharacter(float direction)
    {
        if (direction == 1)
            list.NextCharacter();

        else if(direction == -1)
            list.BackCharacter();
    }



    void ShowCurrentCharacter()
    {
        if (list.Count == 0)
        {
            Debug.Log("No hay personajes en la lista");
            return;
        }
        Debug.Log("Current character: " + list.Peak.Value.NameCharacter);
        Debug.Log("Posicion: " + list.CurrentIndex);
    }


    void DeleteAllCharacter()
    {
        list.RemoveAll();
        Debug.Log("All characters deleted");
    }

 


}
