﻿using System;
using System.Collections.Generic;
using System.Text;
using static SIGBOT.Components.War.Map;

namespace SIGBOT.Components.War.Rules
{
    public class OneTakeOne : Rule
    {
        public override void Advance(Teams teams, List<Region> regions, int step)
        {
            var teamHeads = Enum.GetValues(typeof(TEAM));
            var playingTeam = teams[(TEAM)teamHeads.GetValue(new Random().Next(teamHeads.Length))];

            var targets = new List<Region>();
            foreach (var region in playingTeam.GetTerritory())
            {
                foreach (var neighbor in region.neighbors)
                {
                    if (playingTeam.territory.Contains(neighbor)) continue;
                    targets.Add(Program.game.map.regions[neighbor]);
                }
            }

            var i = new Random().Next(targets.Count);
            var target = targets[i];

            playingTeam.TakeOwnershipOf(target);
        }
    }
}
