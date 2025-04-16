using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    CustomDoubleCircleList<Character> list = new CustomDoubleCircleList<Character>();
    [SerializeField] TMP_InputField inputNameCharacter;
    [SerializeField] Button buttonCreateCharacter;
    [SerializeField] Button buttonShowCharacter;
    [SerializeField] Button buttonDeleteCharacter;


    private void Start()
    {
        buttonCreateCharacter.onClick.AddListener(CreateCharacter);
        buttonShowCharacter.onClick.AddListener(ShowCurrentCharacter);
        buttonDeleteCharacter.onClick.AddListener(DeleteAllCharacter);
    }




    void CreateCharacter()
    {
        string name = inputNameCharacter.text;
        if (string.IsNullOrWhiteSpace(name))
        {
            Debug.Log("Tienes que ingresar un nombre");
            return;
        }

        Character character = new Character(name);
        list.Add(character);
        Debug.Log("Character created: " + character.NameCharacter);
        inputNameCharacter.text = null;
    }


   
    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            list.BackCharacter();
            ShowCurrentCharacter();
        }
    }

    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            list.NextCharacter();
            ShowCurrentCharacter();
        }
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
