using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class PunchTweener : AbstractTweener {

    public float punchScale;
    public float duration;
    public int vibrato;
    public float elastacity;

    public override void Tween(Transform transform) {
        transform.DOPunchScale(new Vector3(punchScale, punchScale, punchScale), duration, vibrato, elastacity);
    }
}
