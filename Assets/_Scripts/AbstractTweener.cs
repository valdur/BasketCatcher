using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTweener : ScriptableObject {

    public abstract void Tween(Transform transform);
}
