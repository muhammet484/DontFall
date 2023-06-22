using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that contains tags as hashsets.  <br></br>
/// Do not create an object from this class. Use GameManager to get object instead. <br></br>
/// Use the public hashset variables to find that if your  game object in any of these hashsets. if yes this game object has this tag. <br></br>
/// eg: if(Enemies.contains(MyGameObject)) { print("This is an enemy!"); } <br></br>
///  <br></br>
/// Be careful; you should add your game object to any hashset in awake method and call them in start method or in the methods that's called after awake method.
///  <br></br>
///  Using hashsets for tagging is 9x faster than using unity's "gameObject.tag". Also you can set tags more than 1 for game objects.
/// </summary>
public class TagSets
{
    public HashSet<GameObject> DynamicObstacle = new HashSet<GameObject>();
}
