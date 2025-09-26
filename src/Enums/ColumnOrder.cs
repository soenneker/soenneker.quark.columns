using Intellenum;

namespace Soenneker.Quark.Enums;

/// <summary>
/// An enumeration for Quark, representing Bootstrap column order values.
/// This enum contains the standard Bootstrap column order values used for grid layout.
/// </summary>
[Intellenum<string>]
public partial class ColumnOrder
{
    /// <summary>
    /// Column order 1.
    /// Bootstrap class: order-1
    /// </summary>
    public static readonly ColumnOrder O1 = new("1");

    /// <summary>
    /// Column order 2.
    /// Bootstrap class: order-2
    /// </summary>
    public static readonly ColumnOrder O2 = new("2");

    /// <summary>
    /// Column order 3.
    /// Bootstrap class: order-3
    /// </summary>
    public static readonly ColumnOrder O3 = new("3");

    /// <summary>
    /// Column order 4.
    /// Bootstrap class: order-4
    /// </summary>
    public static readonly ColumnOrder O4 = new("4");

    /// <summary>
    /// Column order 5.
    /// Bootstrap class: order-5
    /// </summary>
    public static readonly ColumnOrder O5 = new("5");

    /// <summary>
    /// Column order 6.
    /// Bootstrap class: order-6
    /// </summary>
    public static readonly ColumnOrder O6 = new("6");

    /// <summary>
    /// Column order 7.
    /// Bootstrap class: order-7
    /// </summary>
    public static readonly ColumnOrder O7 = new("7");

    /// <summary>
    /// Column order 8.
    /// Bootstrap class: order-8
    /// </summary>
    public static readonly ColumnOrder O8 = new("8");

    /// <summary>
    /// Column order 9.
    /// Bootstrap class: order-9
    /// </summary>
    public static readonly ColumnOrder O9 = new("9");

    /// <summary>
    /// Column order 10.
    /// Bootstrap class: order-10
    /// </summary>
    public static readonly ColumnOrder O10 = new("10");

    /// <summary>
    /// Column order 11.
    /// Bootstrap class: order-11
    /// </summary>
    public static readonly ColumnOrder O11 = new("11");

    /// <summary>
    /// Column order 12.
    /// Bootstrap class: order-12
    /// </summary>
    public static readonly ColumnOrder O12 = new("12");

    /// <summary>
    /// Column order first.
    /// Bootstrap class: order-first
    /// </summary>
    public static readonly ColumnOrder First = new("first");

    /// <summary>
    /// Column order last.
    /// Bootstrap class: order-last
    /// </summary>
    public static readonly ColumnOrder Last = new("last");
}
