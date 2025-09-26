using Soenneker.Quark.Enums;

namespace Soenneker.Quark;

/// <summary>
/// Represents a column offset rule with optional breakpoint.
/// </summary>
internal readonly struct ColumnOffsetRule
{
    public readonly string Offset;
    public readonly Breakpoint? Breakpoint;

    public ColumnOffsetRule(string offset, Breakpoint? breakpoint = null)
    {
        Offset = offset;
        Breakpoint = breakpoint;
    }

}
