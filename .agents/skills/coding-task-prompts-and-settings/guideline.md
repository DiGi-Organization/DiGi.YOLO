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

## 1. The prompt window and its two buttons
- **What it is:** `Windows\<X>OptionsWindow.xaml(.cs)`, opened from `UI<X>Task` through the dispatcher; the task hands
  its options and the county list, the window hands back a property named after the options type. `SetCounties` fills
  and sorts the list (by code, then id - pieces of a multi-part county share code and name) and applies the selection
  **by id**, never by reference (`Coding - GIS Administrative Data.md`).
- **Buttons:** in the footer - its own row, its own pinned row below a `ScrollViewer`, or column 0 of the footer grid
  beside the progress bar:
  ```xml
  <StackPanel Orientation="Horizontal" HorizontalAlignment="Left" VerticalAlignment="Center" Margin="5,5,5,5">
      <Button x:Name="Button_ImportSettings" Content="Import settings..." Width="110" Height="23" Click="Button_ImportSettings_Click"
              ToolTip="Fills the window from a settings file written by Export settings. Nothing runs until OK" />
      <Button x:Name="Button_ExportSettings" Content="Export settings..." Width="110" Height="23" Margin="8,0,0,0" Click="Button_ExportSettings_Click"
              ToolTip="Writes what the window holds now - <what> - to a settings file" />
  </StackPanel>
  ```
  Captions are constant. The Export tooltip lists what the window writes; where §4 keeps something out of the file,
  both tooltips say so ("The scenario is not part of the file and stays as chosen").
- **Footer trap:** at `MinWidth` the left panel can run under OK's panel, and captions that always fit at the default
  width can overflow the window - several prompt windows shipped clipped before any layout fact existed. The §6 fact
  is the detector; widening `Width`/`MinWidth` is part of the fix, not out of scope (six windows needed it).

## 2. The four-method split
Exact signatures, all `internal` (the facts call them) plus the two click handlers:
```csharp
internal void SetControls(TOptions options)
internal bool TryReadOptions(bool complete, out TOptions? options, out string? message)
internal bool TryGetOptions(out string? message)
internal static TOptions? TryReadSettings(string? json, out string? message)
```
- **Constructor order:** copy the caller's options first (`new TOptions(held)`, or the scenario factory
  `Create.<X>Options(scenario, path, held)` where one exists), then `SetControls(copy)`, then subscribe `ItemAdding`,
  then `SetCounties(list)`, then the window's own re-evaluations. `SetControls`' county pass is a no-op before the list
  exists, so `SetCounties` alone decides the opening selection - which is what keeps a "select all when unscoped" window
  (#68, #73) showing its national default while an import (list already present) can clear it (§3).
- **`SetControls`** fills *every* control the file carries - mirroring the constructor's substitutions exactly (blank
  shows the default the constructor showed, an empty step list reads as every step, `null` radius empties the box) -
  and re-selects counties with `SelectItems(x => ids.Contains(x.Id))`, which deselects the rest, so a file with no
  county list **clears** the selection. It never touches controls the file does not fill (§4), never writes the held
  options, and never touches the file system.
- **`TryReadOptions(complete, ...)`** reads controls into a **candidate**: `new TOptions(held) { ...controlled members... }`.
  Parse failures and un-representable text refuse on both paths with OK's exact message; range/requirement gates and
  forced run-shape values only when `complete` (§3, §4). Returns the candidate; the held options are untouched.
- **`TryGetOptions(out message)`** = `TryReadOptions(true, ...)` + writing the candidate into the held options. It is
  the **only** writer, which is what makes "a cancelled dialog changes nothing" and lets a fact drive OK without a
  `MessageBox` (which would hang it).
- **`TryReadSettings(json, out message)`**: `Core.Convert.ToDiGi<T>(json)` must yield **exactly one** object -
  `if (list is null || list.Count != 1) { message = "The file holds no <x> settings - nothing was changed."; return null; }`.
  A file of another window fails by its type name, a non-JSON file fails to parse, `[self,self]` fails the count - all
  three refuse before any control is touched.
- **`Button_OK_Click`**: `if (TryGetOptions(out var message)) { DialogResult = true; Close(); return; }
  MessageBox.Show(message ?? "The options cannot start a run.", ...)`.

## 3. What each path refuses
- **Both paths** (`complete` true and false) - what could not be written back as typed:
  - a box that will not parse as its member (`TryGetValue` false), a non-finite double (`NaN` *parses* but does not
    survive JSON - check `double.IsFinite`, not just the parse);
  - text the file stores in parsed form (the YOLO exclusion buffer/boxes), with the parser's own reason as the message;
  - a selection that cannot round-trip: **an empty scope in a window whose constructor shows "no scope" as every county
    selected** - the file would reopen as the national scope - is refused by Export with OK's county message (#68, #73);
    likewise an empty **step list** where the runner reads empty as "every step" (#67's siblings: empty update-type set
    is *representable* and exports, the unrepresentable ones are refused - decide from what the reader does with empty).
- **`complete` only** - OK's gate: ranges (>= 1, >= 0, >= 32 ...), required scope/directory/start weights, `Directory.Exists`
  on a typed path, relative-path refusal, resume pairings, `Is<Stall>OptionsValid`-style composite checks. Keep the
  original OK's **check order** so the first failing message is unchanged, and use OK's exact wording per box.
- **Why lenient at all:** an unfinished window must save (`Export` of an out-of-range value writes it; OK refuses it on
  read-back - the round-trip fact asserts that pair: *exports with `TryReadOptions(false)`, refused by
  `TryGetOptions`*).
- **Empty scope, the general rule:** write `null`, never an empty set; the task reads `null` as "every county" and an
  empty set as "none". Import of a `null` scope **clears** the selection through `SelectItems`. Windows where the
  *constructor* maps `null` to "select all" keep that in `SetCounties` (their opening rule) while `SetControls` clears
  on import - the constructor/list ordering of §2 is what makes both true at once, and `..._SettingsRefusals` asserts
  each half.
- **Blank boxes:** export blank as no value (`null`); if OK substitutes a default for it on read-back (`scratch`),
  the issue says so and the round-trip fact asserts the pair (box shows the default, `TryGetOptions` writes it).

## 4. Members the file does not control
- **Carry-through** (the common case): the candidate is built on `new(held)`, so members without a control ride along
  in the file untouched, and `TryGetOptions` writes **only the controlled members** - the importing window keeps the
  copy it was opened with ("carried through as they were"). The fact asserts both ends: a *carry part* exports a copy
  with those members changed, checks they are in the file, imports it, and checks the importing window's own copy is
  still its own (#64, #65, #68, #69, #71, #72, #74).
- **File-driven carry-through** - only when the issue says an import changes what the run writes (a hidden member that
  is the *point* of the settings, #67's `Radiuses`/`Years`): record what `SetControls` was given in a field, build the
  candidate on `Shown ?? held`, and write those members in `TryGetOptions`. Pick one pattern **in the issue text**; the
  fact follows whichever the acceptance says.
- **Controls the file never fills:** a scenario combo (`#76`) is never set by `SetControls` - the tooltip says the
  scenario is not in the file, and `TryGetOptions` takes it from the selection box, never from the file.
- **Forced run shape** (OK always writes certain members, #74's six step flags + `Resume`): force them when `complete`
  only, in `TryReadOptions`, and let `TryGetOptions` copy them through. Trap: the export path then writes *the copy's*
  values, so **the round-trip fact must open the exporting window with those members already as OK writes them** or the
  "same JSON twice" assertion fails. Where an *empty* selection would be forced into something the reader misreads,
  refuse the empty selection on both paths instead (§3).
- **Window-only state** (resume stashes, checkpoint information, runner path) must never become an options member; if
  the options type already excludes it, nothing to do - the fact notes it in prose, there is nothing to assert.

## 5. The handlers and the OK ordering
- **Dialogs** (`Microsoft.Win32`): `Filter = "Settings (*.json)|*.json|All files (*.*)|*.*"`, `DefaultExt = ".json"`,
  `FileName = "<Pascal_Case>_Settings.json"`, `saveFileDialog.ShowDialog(this)` / `openFileDialog.ShowDialog(this)`.
- **File IO:** write `Core.Convert.ToSystem_String(options)` as UTF-8 (`Encoding.UTF8`); a `null` conversion is an
  error MessageBox ("nothing was written"); read with `File.ReadAllText(path, Encoding.UTF8)`; both wrapped in
  `catch (Exception e) when (e is IOException or UnauthorizedAccessException)` -> MessageBox with the path and
  `e.Message`, never a throw.
- **Import order:** read file -> `TryReadSettings` (refuse before any control) -> `SetControls` -> the window's own
  re-evaluations (`EvaluateInterruptedRun()`, `SetStallInputsEnabled()`, resume tick from the file) -> the **missing
  county warning**: ids in the file not in the list, sorted, one MessageBox built with
  `string.Create(CultureInfo.CurrentCulture, $"...")`. Report it there, never leave it for OK to discover.
- **Side effects** (creating the output folder, #71): in `Button_OK_Click`, *between* a successful
  `TryReadOptions(true, ...)` and the commit - read, create, commit, close - so a folder that cannot be created leaves
  the window open with its options untouched. The fact facade `TryGetOptions` does read+commit **without** the side
  effect; nothing under `SetControls`/`TryReadOptions`/`TryGetOptions`/`TryReadSettings` may touch the file system,
  show a dialog or show a `MessageBox` - the facts call all four on a background STA thread.

## 6. The facts
In `DiGi.GIS.PostgreSQL.UI.xUnit/Facts/<X>OptionsWindow.cs` (append to the existing file), `public partial class
Facts`, windows driven through `RunSTA` with a local `Expect` collecting strings; window-fact mechanics and `FindName`
are `Coding - WPF Deferred Loading.md` §5, the fact rules `Coding - Automatic Tests.md` §4.
- **`..._SettingsRoundTrip`:** options -> window -> `TryReadOptions(false, ...)` -> `ToSystem_String` -> `TryReadSettings`
  -> a window opened **without options** -> `SetControls` -> `TryGetOptions` -> `ToSystem_String` -> `Assert.Equal(json,
  json_AfterImport)` + named asserts per member + the caller's options untouched. Two traps decide the setup: the
  members with no control must be *identical on both sides* (open both windows the same way - same scenario, no
  options - or follow §4's file-driven pattern), and OK-forced values must already be held on the exporting side.
  Include the scope both ways: a file with no county list clears a selected window and either passes OK (legal empty
  scope) or is refused by OK (required scope) - assert the one this window's issue states.
- **`..._SettingsRefusals`:** malformed box on both paths (message contains OK's box wording); out-of-range value
  exports (`TryReadOptions(false)`) and is refused by `TryGetOptions` - **assert both**; after a refused
  `TryGetOptions` the held options still hold what the window opened with; then `TryReadSettings` against `self`,
  a stock foreign options type (`PostgreSQLUpdateOccupancyOptions`), `"this is not JSON"` and `[self,self]`.
- **`..._Layout`** (only when the window has no layout fact yet): `SolarRadiationOptionsWindowLayoutFailures` +
  `OpenBuildingImportOptionsWindowCaptionFailures` from `Facts/SolarRadiationOptionsWindows.cs` at default and minimum
  size, **plus** the footer overlap the shared walk cannot see - `rect(Button_ExportSettings).Right <=
  rect(Button_OK).Left` (two controls may each lie inside the window and still run into each other). A window whose
  form scrolls (#74, #76): walk the whole content at the default size and **footer-only** at the minimum, and assert
  `ExtentHeight > ViewportHeight` there - content below a `ScrollViewer` fold is scrolled, not clipped, so flagging it
  would report the design as a defect.
- **Fixtures:** counties from `OpenBuildingImportOptionsWindowCounties(n)` (ids 1000+n) - the options in the fact use
  those ids, never database ids; an existing directory is `Path.GetTempPath().TrimEnd('\\', '/')`, a never-existing one
  a unique `C:/Temp/...` name, and "nothing was created" is `Assert.False(Directory.Exists(...))` after the round trip.
- **Never in a fact:** the click handlers (they open file dialogs) and any refusal path that shows a `MessageBox` -
  drive `TryGetOptions` and assert the message string instead.

## 7. Landing one window
- **Issue first, one per window:** title `<Window caption> window: Import/Export settings`; body sections Problem /
  Proposal / Acceptance / Tests; every premise verified against the code before writing it (`GitHub - Issues.md` §2).
  Labels: `type: enhancement`, `priority: medium`, exactly one `ai:` tier - a near-copy of a shipped window is
  `ai: light`, a county-list refactor or new harness `ai: standard`, a multi-mode window `ai: heavy` - assignee
  `ZiolkowskiJakub`.
- **Verify** (host shell, `DiGi.Maintenance/Scripts`): `CheckGuidelineRules.ps1 -Repo <R> -Changed` for both repos;
  `TestSummary.ps1 -Library <ui.csproj> -Project <xUnit>` with `-Filter "FullyQualifiedName~<Window>"` while
  iterating, **unfiltered before finishing**, with every pre-existing fact of that window green. If the build fails
  in a file you did not touch, suspect a stale reference binary from a concurrent edit: rebuild the dependency
  project first (`coding-host-dependencies`).
- **Three commits on the active version branch, explicit paths:** (1) `"<caption> window: Import settings and Export
  settings buttons (#n)"` = .xaml + .xaml.cs (+ the `Width`/`MinWidth` fix if §6 demanded it); (2) the regenerated
  `documentation/API/<Assembly>/<Assembly>.Windows.md` as its own commit
  `"<caption> window settings import and export (#n)"` (the build regenerates it); (3) the facts in DiGi.Test,
  message naming the round trip, refusals and layout.
- **Resolution comment, then close:** commits (repo, branch, SHAs), changes incl. the method split and any window-size
  fix, facts added, the check commands with their counts, the acceptance boxes ticked from the issue, and the closing
  line `**Live verification:** not run - the tray has to be deployed to the server before the buttons can be pressed
  there` - a production run is a separate issue, never part of this one (`GitHub - Issues.md` §3). Push only when
  asked.
