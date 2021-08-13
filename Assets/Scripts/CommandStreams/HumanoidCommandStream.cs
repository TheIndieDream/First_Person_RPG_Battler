using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new HumanoidCommandStream", 
    menuName = "Command Stream.../Humanoid Command Stream")]
public class HumanoidCommandStream : CommandStream<Command<IHumanoid>>
{
   
}
