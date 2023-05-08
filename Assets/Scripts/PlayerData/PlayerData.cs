using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string name;
    public int health;
    public int level;

    public PlayerData(string name, int health, int level)
    {
        this.name = name;
        this.health = health;
        this.level = level;
    }

    public override string ToString()
    {
        return $"{name} is at {health} HP. On level {level}";
    }
}