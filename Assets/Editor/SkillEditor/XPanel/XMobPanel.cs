﻿using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class XMobPanel : XPanel
{


    public override void Add()
    {
        if (Hoster.SkillData.Mob == null) Hoster.SkillData.Mob = new List<XMobUnitData>();
        Hoster.SkillData.Mob.Add(new  XMobUnitData());
        Hoster.SkillDataExtra.Add<XMobUnitDataExtra>();
        Hoster.EditorData.XMob_foldout = true;
    }

    protected override void OnInnerGUI()
    {
        if (Hoster.SkillData.Mob == null) return;

        for (int i = 0; i < Hoster.SkillData.Mob.Count; i++)
        {
            Hoster.SkillData.Mob[i].Index = i;

            EditorGUILayout.BeginHorizontal();

            Hoster.SkillData.Mob[i].TemplateID = EditorGUILayout.IntField("Unit ID", Hoster.SkillData.Mob[i].TemplateID);

            if (GUILayout.Button(_content_remove, GUILayout.MaxWidth(30)))
            {
                Hoster.SkillData.Mob.RemoveAt(i);
                Hoster.SkillDataExtra.MobEx.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();

            if (i < Hoster.SkillData.Mob.Count)
            {
                float mob_at = (Hoster.SkillData.Mob[i].At / XSkillInspector.frame);
                EditorGUILayout.BeginHorizontal();
                mob_at = EditorGUILayout.FloatField("Mob At ", mob_at);
                GUILayout.Label("(frame)");
                GUILayout.Label("", GUILayout.MaxWidth(30));
                EditorGUILayout.EndHorizontal();

                Hoster.SkillDataExtra.MobEx[i].Ratio = mob_at / Hoster.SkillDataExtra.SkillClip_Frame;
                if (Hoster.SkillDataExtra.MobEx[i].Ratio > 1) Hoster.SkillDataExtra.MobEx[i].Ratio = 1;

                EditorGUILayout.BeginHorizontal();
                Hoster.SkillDataExtra.MobEx[i].Ratio = EditorGUILayout.Slider("Ratio", Hoster.SkillDataExtra.MobEx[i].Ratio, 0, 1);
                GUILayout.Label("(0~1)", EditorStyles.miniLabel);
                EditorGUILayout.EndHorizontal();

                Hoster.SkillData.Mob[i].At = (Hoster.SkillDataExtra.MobEx[i].Ratio * Hoster.SkillDataExtra.SkillClip_Frame) * XSkillInspector.frame;
                Hoster.SkillData.Mob[i].LifewithinSkill = EditorGUILayout.Toggle("Life with in Skill", Hoster.SkillData.Mob[i].LifewithinSkill);
                EditorGUILayout.Space();
                Hoster.SkillData.Mob[i].Offset_At_X = EditorGUILayout.FloatField("OffsetX", Hoster.SkillData.Mob[i].Offset_At_X);
                Hoster.SkillData.Mob[i].Offset_At_Y = EditorGUILayout.FloatField("OffsetY", Hoster.SkillData.Mob[i].Offset_At_Y);
                Hoster.SkillData.Mob[i].Offset_At_Z = EditorGUILayout.FloatField("OffsetZ", Hoster.SkillData.Mob[i].Offset_At_Z);
                EditorGUILayout.Space();
                Hoster.SkillData.Mob[i].Shield = EditorGUILayout.Toggle("Shield", Hoster.SkillData.Mob[i].Shield);
            }

            if (i != Hoster.SkillData.Mob.Count - 1)
            {
                GUILayout.Box("", line);
                EditorGUILayout.Space();
            }
        }
    }

    protected override bool FoldOut
    {
        get { return Hoster.EditorData.XMob_foldout; }
        set { Hoster.EditorData.XMob_foldout = value; }
    }

    protected override string PanelName
    {
        get { return "Mob Units"; }
    }

    protected override int Count
    {
        get { return Hoster.SkillData.Mob == null ? -1 : Hoster.SkillData.Mob.Count; }
    }
}
