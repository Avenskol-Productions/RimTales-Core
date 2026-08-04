using RimWorld;
using RimWorld.Planet;
using Verse;
public class BiomeWorker_RimTalesRainForest : BiomeWorker
{
    public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile)
    {
        // We don't want to generate on water.
        if (tile.WaterCovered)
        {
            return -100f;
        }
        // We don't want to generate where it's too cold
        if (tile.temperature < -15f)
        {
            return 0.05f;
        }
        //We want to generate where there is a lot of rain
        if (tile.rainfall > 2000f)
        {
            return 0.05f;
        }
        // We use the tileId as part of the seed to get a constant for each tile.
        // "^" is to perform a bitwise XOR operation
        // 0x11245d7a is a random hexadecimal value
        // We add these last two pieces so that if another mod randomly generates their tiles, the values won't be the same
        // If our random value is above 0.009 we won't generate here
        // This might seem like a small amount, but there is over 100,000 tiles on a map with 30% coverage so the odds are quite high
        if (Rand.ValueSeeded(planetTile.tileId ^ 0x11245d7a) > 0.05f)
        {
            return 0f;
        }
        // A formula to calculate the score at this tile.
        return (float)(16.0 + (tile.temperature - 7.0) + (tile.rainfall - 600.0) / 180.0);
    }
}