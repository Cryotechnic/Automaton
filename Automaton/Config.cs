using Automaton.Features;
using ECommons.Configuration;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace Automaton.Configuration;

public class Config : IEzConfig
{
    [JsonIgnore]
    public const int CURRENT_CONFIG_VERSION = 2;

    public int Version = CURRENT_CONFIG_VERSION;
    public ObservableCollection<string> EnabledTweaks = [];
    public TweakConfigs Tweaks = new();
    public bool ShowDebug;
}

public class TweakConfigs
{
    public AchievementTrackerConfiguration AchievementTrackerConfiguration { get; init; } = new();
    public AddresBookConfiguration AddresBook { get; init; } = new();
    public AddresBookDebugConfiguration AddresBookDebug { get; init; } = new();
    public AutoFollowConfiguration AutoFollow { get; init; } = new();
    public AutoSelectGardeningConfiguration AutoSelectGardening { get; init; } = new();
    public ClickToMoveConfiguration ClickToMove { get; init; } = new();
    public CommandsConfiguration Commands { get; init; } = new();
    public DateWithDestinyConfiguration DateWithDestiny { get; init; } = new();
    public DebugToolsConfiguration DebugTools { get; init; } = new();
    public EnhancedDutyStartEndConfiguration EnhancedDutyStartEnd { get; init; } = new();
    public EnhancedTargetingConfiguration EnhancedTargeting { get; init; } = new();
    public FcChestTabRenameConfiguration FCChestTabRename { get; init; } = new();
    public GettingTooAttachedConfiguration GettingTooAttached { get; init; } = new();
    public GMAlertConfiguration GMAlert { get; init; } = new();
    public HuntRelayHelperConfiguration HuntRelayHelper { get; init; } = new();
    public MarketAdjusterConfiguration MarketAdjuster { get; init; } = new();
}

public class YamlFactory : ISerializationFactory
{
    public string DefaultConfigFileName => $"ez{Name}.yaml";

    public T Deserialize<T>(string inputData)
    {
        return new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .Build().Deserialize<T>(inputData);
    }

    public string Serialize(object s, bool prettyPrint)
    {
        return new SerializerBuilder().Build().Serialize(s);
    }
}