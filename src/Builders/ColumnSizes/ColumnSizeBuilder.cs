using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Soenneker.Quark.Enums;
using Soenneker.Utils.PooledStringBuilders;

namespace Soenneker.Quark;

/// <summary>
/// Simplified column size builder with fluent API for chaining column size rules.
/// </summary>
public sealed class ColumnSizeBuilder : ICssBuilder
{
    private readonly List<ColumnSizeRule> _rules = new(4);

    private const string _classCol1 = "col-1";
    private const string _classCol2 = "col-2";
    private const string _classCol3 = "col-3";
    private const string _classCol4 = "col-4";
    private const string _classCol5 = "col-5";
    private const string _classCol6 = "col-6";
    private const string _classCol7 = "col-7";
    private const string _classCol8 = "col-8";
    private const string _classCol9 = "col-9";
    private const string _classCol10 = "col-10";
    private const string _classCol11 = "col-11";
    private const string _classCol12 = "col-12";
    private const string _classColAuto = "col-auto";

    internal ColumnSizeBuilder(string size, Breakpoint? breakpoint = null)
    {
        _rules.Add(new ColumnSizeRule(size, breakpoint));
    }


    internal ColumnSizeBuilder(List<ColumnSizeRule> rules)
    {
        if (rules is { Count: > 0 })
            _rules.AddRange(rules);
    }

    public ColumnSizeBuilder S1 => ChainWithSize("1");
    public ColumnSizeBuilder S2 => ChainWithSize("2");
    public ColumnSizeBuilder S3 => ChainWithSize("3");
    public ColumnSizeBuilder S4 => ChainWithSize("4");
    public ColumnSizeBuilder S5 => ChainWithSize("5");
    public ColumnSizeBuilder S6 => ChainWithSize("6");
    public ColumnSizeBuilder S7 => ChainWithSize("7");
    public ColumnSizeBuilder S8 => ChainWithSize("8");
    public ColumnSizeBuilder S9 => ChainWithSize("9");
    public ColumnSizeBuilder S10 => ChainWithSize("10");
    public ColumnSizeBuilder S11 => ChainWithSize("11");
    public ColumnSizeBuilder S12 => ChainWithSize("12");
    public ColumnSizeBuilder Auto => ChainWithSize("auto");

    public ColumnSizeBuilder OnPhone => ChainWithBreakpoint(Breakpoint.Phone);
    public ColumnSizeBuilder OnTablet => ChainWithBreakpoint(Breakpoint.Tablet);
    public ColumnSizeBuilder OnLaptop => ChainWithBreakpoint(Breakpoint.Laptop);
    public ColumnSizeBuilder OnDesktop => ChainWithBreakpoint(Breakpoint.Desktop);
    public ColumnSizeBuilder OnWidescreen => ChainWithBreakpoint(Breakpoint.Widescreen);
    public ColumnSizeBuilder OnUltrawide => ChainWithBreakpoint(Breakpoint.Ultrawide);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ColumnSizeBuilder ChainWithSize(string size)
    {
        _rules.Add(new ColumnSizeRule(size, null));
        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ColumnSizeBuilder ChainWithBreakpoint(Breakpoint breakpoint)
    {
        if (_rules.Count == 0)
        {
            _rules.Add(new ColumnSizeRule("12", breakpoint));
            return this;
        }

        int lastIdx = _rules.Count - 1;
        ColumnSizeRule last = _rules[lastIdx];
        _rules[lastIdx] = new ColumnSizeRule(last.Size, breakpoint);
        return this;
    }

    public string ToClass()
    {
        if (_rules.Count == 0)
            return string.Empty;

        using var sb = new PooledStringBuilder();
        var first = true;

        for (var i = 0; i < _rules.Count; i++)
        {
            ColumnSizeRule rule = _rules[i];
            string cls = GetColumnSizeClass(rule.Size);
            if (cls.Length == 0)
                continue;

            string bp = BreakpointUtil.GetBreakpointClass(rule.Breakpoint);
            if (bp.Length != 0)
                cls = InsertBreakpoint(cls, bp);

            if (!first) sb.Append(' ');
            else first = false;

            sb.Append(cls);
        }

        return sb.ToString();
    }

    public string ToStyle()
    {
        // Column sizes are typically handled via Bootstrap classes, not inline styles
        return string.Empty;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string GetColumnSizeClass(string size)
    {
        return size switch
        {
            "1" => _classCol1,
            "2" => _classCol2,
            "3" => _classCol3,
            "4" => _classCol4,
            "5" => _classCol5,
            "6" => _classCol6,
            "7" => _classCol7,
            "8" => _classCol8,
            "9" => _classCol9,
            "10" => _classCol10,
            "11" => _classCol11,
            "12" => _classCol12,
            "auto" => _classColAuto,
            _ => string.Empty
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string InsertBreakpoint(string className, string bp)
    {
        int dashIndex = className.IndexOf('-');
        if (dashIndex > 0)
        {
            int len = dashIndex + 1 + bp.Length + (className.Length - dashIndex);
            return string.Create(len, (className, dashIndex, bp), static (dst, s) =>
            {
                s.className.AsSpan(0, s.dashIndex).CopyTo(dst);
                int idx = s.dashIndex;
                dst[idx++] = '-';
                s.bp.AsSpan().CopyTo(dst[idx..]);
                idx += s.bp.Length;
                s.className.AsSpan(s.dashIndex).CopyTo(dst[idx..]);
            });
        }

        return string.Create(bp.Length + 1 + className.Length, (className, bp), static (dst, s) =>
        {
            s.bp.AsSpan().CopyTo(dst);
            int idx = s.bp.Length;
            dst[idx++] = '-';
            s.className.AsSpan().CopyTo(dst[idx..]);
        });
    }
}
