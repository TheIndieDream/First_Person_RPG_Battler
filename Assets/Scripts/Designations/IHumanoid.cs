using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHumanoid
{
    void Crouch();
    void Move(Vector2 moveInput, bool isGamepadInput);
    void Jump();
    void ToggleRun();
    void ToggleSprint();
}
