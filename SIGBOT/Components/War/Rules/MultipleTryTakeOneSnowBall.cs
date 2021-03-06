﻿using System;
using System.Collections.Generic;
using System.Text;
using static SIGBOT.Components.War.Map;

namespace SIGBOT.Components.War.Rules
{
    public class MultipleTryTakeOneSnowBall : Rule
    {
        public override void Advance(Teams teams, List<Region> regions, int step)
        {
            foreach (var team in teams)
            {
                var targets = new List<Region>();
                foreach (var region in team.GetTerritory())
                {
                    foreach (var neighbor in region.neighbors)
                    {
                        if (team.territory.Contains(neighbor)) continue;
                        targets.Add(Program.game.map.regions[neighbor]);
                    }
                }

                if (targets.Count == 0) continue; // No target..?

                var i = new Random().Next(targets.Count);
                var target = targets[i];

                if (new Random().Next(100) > team.territory.Count*10) continue; // Invasion failed

                // Invasion success
                team.TakeOwnershipOf(target);
            }
        }
    }
}
