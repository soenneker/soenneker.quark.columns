using Soenneker.Quark.Enums;

namespace Soenneker.Quark;

/// <summary>
/// Represents a column size rule with optional breakpoint.
/// </summary>
internal readonly struct ColumnSizeRule
{
    public readonly string Size;
    public readonly Breakpoint? Breakpoint;

    public ColumnSizeRule(string size, Breakpoint? breakpoint = null)
    {
        Size = size;
        Breakpoint = breakpoint;
    }

}
