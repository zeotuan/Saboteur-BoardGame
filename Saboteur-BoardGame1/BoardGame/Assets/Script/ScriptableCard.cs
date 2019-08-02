//just for testing might not be needed at all
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "SCard")]
public class ScriptableCard : ScriptableObject
{
     public string cardName;
     public int left,right,up,down,rotate;
     public Sprite FrontArt;
     public Sprite BackArt;
}
 