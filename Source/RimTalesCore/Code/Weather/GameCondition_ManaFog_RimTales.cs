using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RimWorld
{
    public class GameCondition_ManaFog_RimTales : GameCondition
    {
        public override int TransitionTicks
        {
            get
            {
                return 5000;
            }
        }
        public override void Init()
        {
            LessonAutoActivator.TeachOpportunity(ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
            LessonAutoActivator.TeachOpportunity(ConceptDefOf.AllowedAreas, OpportunityType.Critical);
        }
        public override void GameConditionTick()
        {
            List<Map> affectedMaps = base.AffectedMaps;
            if (Find.TickManager.TicksGame % 3451 == 0)
            {
                for (int i = 0; i < affectedMaps.Count; i++)
                {
                    this.RTC_DoPawnsManaDamage(affectedMaps[i]);
                }
            }
            for (int j = 0; j < this.overlays.Count; j++)
            {
                for (int k = 0; k < affectedMaps.Count; k++)
                {
                    this.overlays[j].TickOverlay(affectedMaps[k], 1f);
                }
            }
        }
        private void RTC_DoPawnsManaDamage(Map map)
        {
            IReadOnlyList<Pawn> allPawnsSpawned = map.mapPawns.AllPawnsSpawned;
            for (int i = 0; i < allPawnsSpawned.Count; i++)
            {
                if (!allPawnsSpawned[i].kindDef.immuneToGameConditionEffects)
                {
                    ManaUtility_RimTales.RTC_DoAirbornePawnManaDamage(allPawnsSpawned[i], 1f);
                }
            }
        }
        public override void GameConditionDraw(Map map)
        {
            for (int i = 0; i < this.overlays.Count; i++)
            {
                this.overlays[i].DrawOverlay(map);
            }
        }
        public override float SkyTargetLerpFactor(Map map)
        {
            return GameConditionUtility.LerpInOutValue(this, (float)this.TransitionTicks, 0.5f);
        }
        public override SkyTarget? SkyTarget(Map map)
        {
            return new SkyTarget?(new SkyTarget(0.85f, this.RTC_ManaFogColors, 1f, 1f));
        }
        public override float AnimalDensityFactor(Map map)
        {
            return 0.75f;
        }
        public override float PlantDensityFactor(Map map)
        {
            return 0.75f;
        }
        public override bool AllowEnjoyableOutsideNow(Map map)
        {
            return false;
        }
        public override List<SkyOverlay> SkyOverlays(Map map)
        {
            return this.overlays;
        }
        private const float MaxSkyLerpFactor = 0.5f;
        private const float SkyGlow = 0.85f;
        private SkyColorSet RTC_ManaFogColors = new SkyColorSet(new ColorInt(0, 216, 255).ToColor, new ColorInt(200, 234, 255).ToColor, new Color(0.5f, 0.6f, 0.8f), 0.85f);
        private readonly List<SkyOverlay> overlays = new List<SkyOverlay>
        {
            new WeatherOverlay_Fog()
        };
    }
}