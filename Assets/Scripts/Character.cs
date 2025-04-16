using UnityEngine;

public class Character
{
    private string nameCharacter;

    public string NameCharacter => nameCharacter;

    public Character(string name)
    {
        nameCharacter = name;
    }

}
