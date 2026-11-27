---
name: coding-task-prompts-and-settings
description: "Use when adding or changing a tray task prompt (options) window or its Import/Export settings buttons - SetControls/TryReadOptions/TryGetOptions/TryReadSettings split, lenient export vs the OK gate, empty-scope rules, SettingsRoundTrip/Refusals facts, footer layout."
---

# AI Guidelines: Task prompt windows and their Import/Export settings

The tray's `*OptionsWindow` prompts - one dialog per dialog-backed background task (`Coding - Background Tasks.md` §2) -
and the **Import settings.../Export settings...** buttons every one of them carries. Reference implementation:
`Windows\OpenBuildingMatchOptionsWindow.xaml.cs` (DiGi-Organization/DiGi.GIS.PostgreSQL.UI#60), extended to all 15
remaining windows in the sweep #62-#76; the per-window decisions and the defects the facts found are in
[Evidence](evidence.md). The window works on a copy and a cancelled dialog
changes nothing (`Coding - Background Tasks.md` §2) - this guideline is what sits on top of that: the buttons, the split
methods, what each path refuses, and the facts that prove it.

## Checklist
- One issue per window **before** code: `<Window caption> window: Import/Export settings`, premises verified against the
  code, Problem/Proposal/Acceptance/Tests (§7).
- XAML: two 110 px buttons, left-aligned in the footer row, names `Button_ImportSettings`/`Button_ExportSettings`;
  tooltips say what is written and that nothing runs until OK (§1).
- Split the code-behind into `SetControls` / `TryReadOptions(complete, ...)` / `TryGetOptions` / static
  `TryReadSettings`; only `TryGetOptions` (hence OK) ever writes the held options (§2).
- Build every read on a **candidate copy** (`new(held) { ... }`); a refusal must leave the held options byte-identical -
  the facts assert it (§2).
- Export (`complete == false`) is lenient: ranges, required scopes, required directories and run-shape forcing are OK's
  gate only; both paths refuse what cannot be written back as typed, with OK's exact message (§3).
- An empty scope is `null`, never an empty set; a window that *shows* "no scope" as "every county selected" refuses the
  empty selection on **Export** instead (#68, #73) (§3).
- Members with no control travel in the file; whether an import **adopts** them or the window keeps its own copy is
  decided in the issue text and asserted both ends by the fact (§4).
- Controls the file never fills - a scenario combo, OK's forced run shape - are never touched by `SetControls`; forced
  values are written on the complete path only (§4).
- Import fills controls only, warns about county ids the list does not hold, re-runs the window's own re-evaluation,
  and never causes a side effect; folder creation stays in the OK handler between read and commit (§5).
- Facts per window: `SettingsRoundTrip` + `SettingsRefusals`, plus `Layout` where the window had none; click handlers
  are never fact-testable - drive `TryGetOptions` instead of pressing OK (§6).
- The layout fact walks the shared harness at both sizes **and** checks the footer overlap the shared walk cannot see;
  a scrolling form is walked whole at the default size and footer-only at the minimum (§6).
- Verify: `CheckGuidelineRules.ps1 -Changed` on both repos, `TestSummary.ps1` filtered then unfiltered with every
  pre-existing fact green; land as three commits (code, regenerated API docs, facts), then the resolution comment (§7).

**Sections (rules in full, code, traps):** [guideline.md](guideline.md) - before changing code a checklist line covers, read the section it names.
