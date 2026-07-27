using Godot;

namespace LearnGodot.core.resources.scripts;

[Tool]
[GlobalClass]
public partial class EntityStats : Resource
{
    [Export] public float MovementSpeed { get; set; } = 400.0f;
    [Export] public int MaxHealth { get; set; } = 10;
    [Export] public int CurrentHealth { get; set; }
    [Export] public float SprintMultiplier { get; set; } = 1.5f;

    public EntityStats()
    {
        CurrentHealth = MaxHealth;
    }

}