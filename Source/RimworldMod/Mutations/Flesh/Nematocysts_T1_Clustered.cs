using SaveOurShip2;
using BioShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace RimWorld
{
    public class ClusteredNematocysts : IMutation
    {
        bool IHediff.ShouldAddTo(CompBuildingBodyPart target)
        {
            bool ret = false;
            ret = ret || (target.parent.TryGetComp<CompShipHeart>() != null);
            ret = ret || (target.parent.TryGetComp<CompMutationWorker>() != null);
            return ret;
        }

        void IHediff.Apply(CompBuildingBodyPart target)
        {
            if (target.parent.TryGetComp<CompShipHeart>() != null)
            {
                CompShipHeart heart = target.parent.TryGetComp<CompShipHeart>();
                heart.defs.TryGetValue("smallTurretOptions", new List<ThingDef>())
                    .Add(ThingDef.Named("ShipTurret_ClusteredNematocyst"));
                heart.defs.TryGetValue("smallTurretOptions", new List<ThingDef>())
                    .Add(ThingDef.Named("ShipTurret_ClusteredNematocyst"));

            }
            if (target.parent.TryGetComp<CompMutationWorker>() != null)
            {
                target.parent.TryGetComp<CompMutationWorker>().RemoveMutation<ClusteredNematocysts>("offense", "flesh");
                target.parent.TryGetComp<CompMutationWorker>().mutationThemes["flesh"]++;
            }
        }
        void IHediff.Remove(CompBuildingBodyPart target)
        {

        }
        List<Tuple<IMutation, string, string>> IMutation.GetMutationsForTier(string tier, List<IMutation> existingMutations) {
            if (tier == "tier2")
            {
                List<Tuple<IMutation, string, string>> ret = new List<Tuple<IMutation, string, string>>();
                if (existingMutations.Any(mut => mut is PotentAcid)) {
                    ret.Add(new Tuple<IMutation, string, string>(
                        new AcidNematocysts(),
                        "offense",
                        "flesh"));
                }
                if (existingMutations.Any(mut => mut is DenseSpines))
                {
                    ret.Add(new Tuple<IMutation, string, string>(
                        new BatteringNematocysts(),
                        "offense",
                        "flesh"));
                }
                if (existingMutations.Any(mut => mut is EfficientSpines))
                {
                    ret.Add(new Tuple<IMutation, string, string>(
                        new SplinteringNematocysts(),
                        "offense",
                        "flesh"));
                }

                return ret;
            }
            else
            {
                return new List<Tuple<IMutation, string, string>>();
            }
        }
        String IMutation.GetTier() {
            return "tier1";
        }
        String IMutation.GetDescription()
        {
            return "Clustered Nematocysts\nSmall weapon scaffolds now grow into clustered nematocysts, which fire larger volleys.";
        }
        public override String ToString()
        {
            return "Clustered Nematocysts";
        }
        Texture2D IMutation.GetIcon()
        {
            return null;
        }
        void IExposable.ExposeData()
        {

        }
        float IHediff.StatMult(string stat)
        {
            return 1f;
        }
    }
}