using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;
using Verse;
using LivingBuildings;

namespace Verse
{
    public class ShipGeneline : IExposable
    {
        public ShipGenelineDef def;
        public BuildingGene smallTurretGene;
        public BuildingGene mediumTurretGene;
        public BuildingGene largeTurretGene;
        public BuildingGene spinalTurretGene;
        public BuildingGene armor;
        public List<BuildingGene> genes;

        void IExposable.ExposeData()
        {
            Scribe_Values.Look<BuildingGene>(ref smallTurretGene, "smallTurretGene", null);
            Scribe_Values.Look<BuildingGene>(ref mediumTurretGene, "mediumTurretGene", null);
            Scribe_Values.Look<BuildingGene>(ref largeTurretGene, "largeTurretGene", null);
            Scribe_Values.Look<BuildingGene>(ref spinalTurretGene, "spinalTurretGene", null);
            Scribe_Values.Look<BuildingGene>(ref armor, "armor", null);
            Scribe_Collections.Look<BuildingGene>(ref genes, "genes");
        }
    }
}