﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomPotion : Consumable
{
    public override string Tooltip => "Mystery never know what in it till you try it.";



    public Consumable SelectedPotion;

    protected override void Start()
    {
        GameObject[] possiblePotions = Resources.LoadAll<GameObject>("Prefabs/Items/Consumables");
        var consumables = possiblePotions.Select(x => x.GetComponent<Consumable>());
        SelectedPotion = consumables.ElementAt(Random.Range(0, consumables.Count()));
        SelectedPotion.OnPickup(Inventory.Character);
    }


    public override void Consume()
    {
        SelectedPotion.Consume();

        base.Consume();
    }
}