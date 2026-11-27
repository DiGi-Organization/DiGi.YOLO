# Evidence: Task prompts and their Import/Export settings

Incidents and measurements behind `Coding - Task Prompts and Settings.md`, by section number. Read when a rule there
is disputed or being changed.

## §1, §7 - The reference sweep (2026-11-26/27)

Issue #60 (match window, commits `8070af5`/`db912f6`, facts `0f84549`) was the reference; the pattern was then applied
to all 15 remaining prompt windows as one issue per window, all closed the same day:

| Issue | Window | Notable decision |
|---|---|---|
| #62 | Import orthophoto sheet index | no county list - no post-import warning |
| #63 | Update occupancy | empty scope legal both ways; empty selection exports as no scope |
| #64 | Fill TerrainPoint gaps | carry-through both ends (origin/tile); `NaN` grid size refused |
| #65 | Update TerrainPoints | same + override box |
| #66 | Update building data solar summary | nullable radius: empty box = no radius |
| #67 | Update building data | **file-driven** `Radiuses`/`Years` (a hidden member is the point of the settings) |
| #68 | Update external components area | empty scope **refused by Export** - the window shows "no scope" as all selected |
| #69 | Refresh Building2Ds | empty scope legal (unlike #68); `StartId`/`Tolerance` carry through |
| #70 | Backfill OrtoDatas acquisition dates | scope always named: imported empty scope refused by OK |
| #71 | Export solar urban-context table | folder created only in OK between read and commit; `TryGetOptions` facade has no side effect |
| #72 | Solve building heat demand | carry-through both ends; empty ceiling = empty box |
| #73 | Stamp BuildingInformation | constructor order trick: `SetControls` before the list exists (opening = select all) while an import clears |
| #74 | Predict year built | OK-forced run shape (six steps + `Resume`) on the complete path; blank scratch exports null, OK substitutes `scratch`; layout walks footer-only at minimum because the form scrolls |
| #75 | Create BuildingModels from database | empty scope legal; nonexistent report dir exports, OK refuses on read-back |
| #76 | Train YOLO detector | 220-line OK handler split in original gate order; scenario never in the file; empty step list refused on both paths (runner reads empty as "all steps") |

## §1 - Pre-existing clipping the layout facts found

Six windows had never been measured; their new `..._Layout` facts failed on captions that were clipped before any
button existed, fixed by widening (all in the issue's own commit):

| Issue | Window | Was -> now | What overflowed |
|---|---|---|---|
| #63 | Update occupancy | `MinWidth` 440 -> 500 | two check box captions + the county label, up to 45 px past the edge at minimum |
| #64 | Fill TerrainPoint gaps | 400 -> 450 | the grid-size caption inside `TextBoxControl` (404 px needed, 394 given) |
| #65 | Update TerrainPoints | 400 -> 450 | same caption/label pair as #64 |
| #68 | Update external components area | 440 -> 500 | party walls caption needed 430 px, box gave 394; footer overlap after the buttons were added |
| #69 | Refresh Building2Ds | 440 -> 550 | override caption 473 px + county label 465 px; default 560 already barely fit |
| #75 | Create BuildingModels from database | 560/440 -> 680/660 | resume caption needed 580 px - clipped **at the default width** (text right 610 px in a 544 px client) |

Symptom ordering observed: the bounds walk (`SolarRadiationOptionsWindowLayoutFailures`) reports `TextBlock lies
outside the window (x, y, w, h)` per overflowing caption; the caption walk (`OpenBuildingImportOptionsWindowCaptionFailures`)
reports `"<text>" needs N px and the <control> gives M px`. The numbers are deterministic at 96 dpi, so the fix is
computed from the failure (client width >= text right + margins), then re-run.

## §6 - Fact counts and the scroll scoping incident

- Suite: 94 passed at #60's close -> **136 passed, 0 failed, 1 skipped** (the skip pre-existing) after #62-#76; every
  pre-existing window fact (`_Construction`, `_Ok`, `_DirectoryRefusal`, `_Exclusion`, `_Resume`, `_AutomaticResumes`,
  `_Coverage`, `_CloseBeforeData`, `SolarRadiationOptionsWindows_Layout`, ...) stayed green throughout.
- #74's first layout attempt asserted "the whole form fits without scrolling at the default size" and failed:
  `the form is 488 px tall in a 468 px viewport` - the window scrolls at *both* sizes by design (its own comment says
  everything above the buttons scrolls). The rule became: full walk at default (content lies inside the window),
  footer-only at minimum, and `ExtentHeight > ViewportHeight` at minimum to prove the scroll engages - content below a
  `ScrollViewer` fold is scrolled, not clipped.
- #72's first round trip failed on `HeatDemandOptions` coming back `null`: the exporting copy had non-default
  members and the import side keeps its own copy (carry pattern A). Either open both sides with default hidden
  members or adopt the file-driven pattern of §4 - the issue text decides, and the fact must match it.

## §7 - Verification incidents

- Two builds during the sweep failed in files nobody in this work touched (`UIPostgreSQLUserCreateTask.cs`,
  `UIPostgreSQLStatisticalDataCollectionCreateTableTask.cs`) - a concurrent session's in-flight edits and one stale
  `DiGi.GIS.PostgreSQL` reference binary; rebuilding the dependency project (`dotnet build` on its csproj) fixed the
  second. Diagnosis: the failing file's *source* was already consistent, so the compiled reference was one build behind.
- `Range<int>` in #67 is `DiGi.Core.Classes.Range<T>` (members `Min`/`Max`), not `System.Range` - the fact needed
  `using DiGi.Core.Classes;`.
