using System.Collections.Generic;
using Godot;

namespace LearnGodot.core.resources.scripts;

[GlobalClass]
public partial class EnemyResource : Resource
{
    /// <summary>
    /// Get or set the spritesheet to be used.
    /// </summary>
    [Export] public Texture2D SpriteSheetTexture { get; set; }
    
    /// <summary>
    /// The size of each tile in the spritesheet.
    /// </summary>
    [Export] public int TileSize { get; set; }
    
    /// <summary>
    /// Get or set the current tile index.
    /// </summary>
    [Export] public int TileIndex { get; set; }
    
    /// <summary>
    /// Holds the Tile indexes that make up the animation.
    /// </summary>
    [Export] public int[] AnimationFrameIndexes { get; set; }
    
    /// <summary>
    /// Get or set the current animation frame.
    /// </summary>
    [Export] public int CurrentFrame { get; set; }
    
    /// <summary>
    /// The duration of each animation frame in seconds
    /// </summary>
    [Export] public int FrameDuration { get; set; }
}