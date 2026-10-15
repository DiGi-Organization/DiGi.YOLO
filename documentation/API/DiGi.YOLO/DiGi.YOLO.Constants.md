#### [DiGi\.YOLO](DiGi.YOLO.Overview.md 'DiGi\.YOLO\.Overview')

## DiGi\.YOLO\.Constants Namespace
### Classes

<a name='DiGi.YOLO.Constants.DirectoryName'></a>

## DirectoryName Class

Provides constant values for standard directory names used in YOLO dataset structures\.

```csharp
public static class DirectoryName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DirectoryName
### Fields

<a name='DiGi.YOLO.Constants.DirectoryName.Images'></a>

## DirectoryName\.Images Field

The name of the directory containing image files\.

```csharp
public const string Images = "images";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.DirectoryName.Labels'></a>

## DirectoryName\.Labels Field

The name of the directory containing label files\.

```csharp
public const string Labels = "labels";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.DirectoryName.Models'></a>

## DirectoryName\.Models Field

The name of the directory, directly inside a [YOLO](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.DirectoryName.YOLO 'DiGi\.YOLO\.Constants\.DirectoryName\.YOLO') folder, holding the frozen weights \(model\.pt and the pretrained base checkpoints\)\.

No training run may write into it; see [IsInsideModelsDirectory\(string\)](DiGi.YOLO.md#DiGi.YOLO.Query.IsInsideModelsDirectory(string) 'DiGi\.YOLO\.Query\.IsInsideModelsDirectory\(string\)').

```csharp
public const string Models = "models";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.DirectoryName.YOLO'></a>

## DirectoryName\.YOLO Field

The name of the directory containing YOLO deployment scripts and configuration files\.

```csharp
public const string YOLO = "YOLO";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.DirectoryName.YoloConfig'></a>

## DirectoryName\.YoloConfig Field

The name of the directory holding the ultralytics settings isolated to the working directory a run executes in\.

Each run points the YOLO_CONFIG_DIR environment variable at this folder, so the settings file an ultralytics version reads and writes lives in the working directory instead of the shared machine-wide one. Without it, switching ultralytics versions between runs rewrites the other's settings, prints a settings notice on stdout and loses custom values such as runs_dir.

```csharp
public const string YoloConfig = ".yolo-config";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileExtension'></a>

## FileExtension Class

Provides constant values for file extensions used across the application\.

```csharp
public static class FileExtension
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FileExtension
### Fields

<a name='DiGi.YOLO.Constants.FileExtension.BoundingBoxResultFile'></a>

## FileExtension\.BoundingBoxResultFile Field

The file extension associated with bounding box result files\.

```csharp
public const string BoundingBoxResultFile = "bbrf";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName'></a>

## FileName Class

Provides constant values for file names used in YOLO runner scripts and configuration files\.

```csharp
public static class FileName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FileName
### Fields

<a name='DiGi.YOLO.Constants.FileName.Check'></a>

## FileName\.Check Field

The file name of the preflight check script\.

```csharp
public const string Check = "check.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Checkpoint'></a>

## FileName\.Checkpoint Field

The file name of the checkpoint information script\.

```csharp
public const string Checkpoint = "checkpoint.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Conf'></a>

## FileName\.Conf Field

The file name of the dataset configuration YAML file\.

```csharp
public const string Conf = "conf.yaml";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Export'></a>

## FileName\.Export Field

The file name of the ONNX export script\.

```csharp
public const string Export = "export.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Predict'></a>

## FileName\.Predict Field

The file name of the prediction runner script\.

```csharp
public const string Predict = "predict.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Requirements'></a>

## FileName\.Requirements Field

The file name of the Python dependencies requirements file\.

```csharp
public const string Requirements = "requirements.txt";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Train'></a>

## FileName\.Train Field

The file name of the training runner script\.

```csharp
public const string Train = "train.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Utils'></a>

## FileName\.Utils Field

The file name of the utility script\.

```csharp
public const string Utils = "utils.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.FileName.Validate'></a>

## FileName\.Validate Field

The file name of the validation runner script\.

```csharp
public const string Validate = "val.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.Marker'></a>

## Marker Class

Provides constant values for the stdout contract of the preflight check script\.

```csharp
public static class Marker
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Marker
### Fields

<a name='DiGi.YOLO.Constants.Marker.CheckJsonBegin'></a>

## Marker\.CheckJsonBegin Field

The line check\.py prints immediately before its JSON payload\.

The payload is the first non-empty line between this marker and [CheckJsonEnd](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Marker.CheckJsonEnd 'DiGi\.YOLO\.Constants\.Marker\.CheckJsonEnd'), so a caller finds it without depending on what the interpreter or ultralytics print first - a settings notice included. The markers and their use are stated in check.py in files/YOLO.

```csharp
public const string CheckJsonBegin = "YOLO_CHECK_JSON_BEGIN";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.Marker.CheckJsonEnd'></a>

## Marker\.CheckJsonEnd Field

The line check\.py prints immediately after its JSON payload\.

Paired with [CheckJsonBegin](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Marker.CheckJsonBegin 'DiGi\.YOLO\.Constants\.Marker\.CheckJsonBegin'); see check.py in files/YOLO.

```csharp
public const string CheckJsonEnd = "YOLO_CHECK_JSON_END";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.Marker.CheckpointJsonBegin'></a>

## Marker\.CheckpointJsonBegin Field

The line checkpoint\.py prints immediately before its JSON payload\.

The payload is the first non-empty line between this marker and [CheckpointJsonEnd](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Marker.CheckpointJsonEnd 'DiGi\.YOLO\.Constants\.Marker\.CheckpointJsonEnd'), the same contract [CheckJsonBegin](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Marker.CheckJsonBegin 'DiGi\.YOLO\.Constants\.Marker\.CheckJsonBegin') establishes for check.py, so a settings notice or any other line printed before it is never picked up. The markers and their use are stated in checkpoint.py in files/YOLO.

```csharp
public const string CheckpointJsonBegin = "YOLO_CHECKPOINT_JSON_BEGIN";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.Marker.CheckpointJsonEnd'></a>

## Marker\.CheckpointJsonEnd Field

The line checkpoint\.py prints immediately after its JSON payload\.

Paired with [CheckpointJsonBegin](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Marker.CheckpointJsonBegin 'DiGi\.YOLO\.Constants\.Marker\.CheckpointJsonBegin'); see checkpoint.py in files/YOLO.

```csharp
public const string CheckpointJsonEnd = "YOLO_CHECKPOINT_JSON_END";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix'></a>

## OutputPrefix Class

Provides the line prefixes the training and validation scripts print their results under, shared by the scripts' output contract and the parsers that read it back\.

```csharp
public static class OutputPrefix
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → OutputPrefix
### Fields

<a name='DiGi.YOLO.Constants.OutputPrefix.AMP'></a>

## OutputPrefix\.AMP Field

The prefix of the line train\.py prints the automatic mixed precision actually used under, True or False\.

```csharp
public const string AMP = "AMP:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.Bytes'></a>

## OutputPrefix\.Bytes Field

The prefix of the line train\.py and export\.py print the size of the written file under, in bytes\.

```csharp
public const string Bytes = "Bytes:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.MAP50'></a>

## OutputPrefix\.MAP50 Field

The prefix of the line val\.py prints the box mAP at IoU 0\.5 under\.

```csharp
public const string MAP50 = "mAP50:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.MAP50_95'></a>

## OutputPrefix\.MAP50\_95 Field

The prefix of the line val\.py prints the box mAP averaged over IoU 0\.5 to 0\.95 under\.

```csharp
public const string MAP50_95 = "mAP50-95:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.ResumeEpoch'></a>

## OutputPrefix\.ResumeEpoch Field

The prefix of the line train\.py prints, before a resumed run and again in its success block, the 1\-based epoch training resumes into under\.

Printed in both places because the start of a long run is evicted from the tail [DiGi\.Python\.Query\.ExecuteProcess\(System\.String,System\.String,System\.String,System\.Collections\.Generic\.Dictionary\{System\.String,System\.String\},System\.Threading\.CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/digi.python.query.executeprocess#digi-python-query-executeprocess(system-string-system-string-system-string-system-collections-generic-dictionary{system-string-system-string}-system-threading-cancellationtoken) 'DiGi\.Python\.Query\.ExecuteProcess\(System\.String,System\.String,System\.String,System\.Collections\.Generic\.Dictionary\{System\.String,System\.String\},System\.Threading\.CancellationToken\)') keeps, so only the success block copy survives for the parser.

```csharp
public const string ResumeEpoch = "Resume epoch:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.ResumeEpochs'></a>

## OutputPrefix\.ResumeEpochs Field

The prefix of the line train\.py prints, before a resumed run and again in its success block, the epoch ceiling restored from the checkpoint under\.

The ceiling is fixed by the checkpoint; a different one is a new run, not a resume.

```csharp
public const string ResumeEpochs = "Resume epochs:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.SHA256'></a>

## OutputPrefix\.SHA256 Field

The prefix of the line train\.py and export\.py print the lowercase hexadecimal SHA\-256 digest of the written file under\.

```csharp
public const string SHA256 = "SHA256:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Constants.OutputPrefix.Weights'></a>

## OutputPrefix\.Weights Field

The prefix of the line train\.py prints the path of the best weights file under\.

```csharp
public const string Weights = "Weights:";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')