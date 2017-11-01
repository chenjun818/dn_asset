﻿using System.Collections.Generic;
using UnityEngine;

public enum DummyState { Idle, Move, Fire };

public interface ISkillHoster
{
    Transform Transform { get; }

    GameObject Target { get; }

    XConfigData ConfigData { get; set; }

    XSkillResult skillResult { get; set; }
    
    XSkillData xOuterData { get; set; }

    List<Vector3>[] warningPosAt { get; set; }

    XSkillData CurrentSkillData { get; }

    float ir { get; set; }

    float or { get; set; }

    XSkillDataExtra SkillDataExtra { get; }

    Transform ShownTransform { get; set; }
    
    void AddedTimerToken(uint token, bool logical);

    bool IsPickedInRange(int n, int d);

    bool IsInField(XSkillData data, int triggerTime, Vector3 pos, Vector3 forward, Vector3 target, float angle, float distance);

    void StopFire();

    void AddedCombinedToken(uint token);

    Vector3 GetRotateTo();
}