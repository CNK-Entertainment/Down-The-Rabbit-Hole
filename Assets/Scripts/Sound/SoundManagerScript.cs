﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Basic sound manager to store all sound effects and to call them from here whenever needed
/// </summary>
public class SoundManagerScript : MonoBehaviour
{

    static Dictionary<Sound, AudioClip> Sounds;
    // Enum that stores each sound effect
    public enum Sound
    {
        QuickSlash,
        SlowSlash,
        QuickThrust,
        Deflect,
        Select,
        Pickup,
        ChestOpen
    }

    static AudioSource audioSrc;
    /// <summary>
    /// Store each sound effect into a dictionary
    /// </summary>
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        Sounds = new Dictionary<Sound, AudioClip> {
            {Sound.QuickSlash, Resources.Load<AudioClip>("Sounds/Items/Weapon/QuickSlash") },
            {Sound.Deflect, Resources.Load<AudioClip>("Sounds/Items/Weapon/deflect") },
            {Sound.Select, Resources.Load<AudioClip>("Sounds/UI/select") },
            {Sound.ChestOpen, Resources.Load<AudioClip>("Sounds/Consumable/ChestOpen") },
            {Sound.Pickup, Resources.Load<AudioClip>("Sounds/Consumable/PickUpItem") }




        };
    }
    /// <summary>
    /// Play the called sound effect
    /// </summary>
    /// <param name="sound">Called sound effect</param>
    public static void PlaySound(Sound sound)
    {
        if (Sounds.TryGetValue(sound, out AudioClip clip))
        {
            audioSrc.PlayOneShot(clip);
        }
    }
}
