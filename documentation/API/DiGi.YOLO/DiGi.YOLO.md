#### [DiGi\.YOLO](DiGi.YOLO.Overview.md 'DiGi\.YOLO\.Overview')

## DiGi\.YOLO Namespace
### Classes

<a name='DiGi.YOLO.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double)'></a>

## Create\.BoundingBox\(double, double, double, double, double, double\) Method

Creates a normalized BoundingBox based on the provided image dimensions and bounding box coordinates\.

```csharp
public static DiGi.YOLO.Classes.BoundingBox? BoundingBox(double imageWidth, double imageHeight, double topLeftX, double topLeftY, double width, double height);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).imageWidth'></a>

`imageWidth` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The total width of the image\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).imageHeight'></a>

`imageHeight` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The total height of the image\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).topLeftX'></a>

`topLeftX` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the top\-left corner of the bounding box\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).topLeftY'></a>

`topLeftY` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the top\-left corner of the bounding box\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).width'></a>

`width` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The width of the bounding box\.

<a name='DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double).height'></a>

`height` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of the bounding box\.

#### Returns
[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')  
A normalized [BoundingBox\(double, double, double, double, double, double\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBox(double,double,double,double,double,double) 'DiGi\.YOLO\.Create\.BoundingBox\(double, double, double, double, double, double\)') instance if all inputs are valid; otherwise, null\.

<a name='DiGi.YOLO.Create.BoundingBoxResult(string)'></a>

## Create\.BoundingBoxResult\(string\) Method

Parses a tab\-separated string into a [BoundingBoxResult\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBoxResult(string) 'DiGi\.YOLO\.Create\.BoundingBoxResult\(string\)') object\.

Numbers are read with [System\.Globalization\.CultureInfo\.InvariantCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture 'System\.Globalization\.CultureInfo\.InvariantCulture') because the file is written by predict.py and holds Python floats, which always use a decimal point. Reading them under the current culture rejects every line on a machine whose culture uses a comma, and the caller then sees an empty result rather than an error.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResult? BoundingBoxResult(string? text);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBoxResult(string).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The tab\-delimited string containing bounding box data \(name, label index, x, y, width, height, and confidence\)\.

#### Returns
[BoundingBoxResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResult 'DiGi\.YOLO\.Classes\.BoundingBoxResult')  
A [BoundingBoxResult\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBoxResult(string) 'DiGi\.YOLO\.Create\.BoundingBoxResult\(string\)') instance if the input is valid; otherwise, `null`\.

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(string)'></a>

## Create\.BoundingBoxResultFile\(string\) Method

Reads a file from the specified path and parses its contents into a [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') collection\.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? BoundingBoxResultFile(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the bounding box result file\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
A [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') instance containing the parsed results if the file exists and is valid; otherwise, `null`\.

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(System.Collections.Generic.IEnumerable_string_)'></a>

## Create\.BoundingBoxResultFile\(IEnumerable\<string\>\) Method

Parses lines of a bounding box result file into a [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') collection\.

Lines that do not hold a complete detection are skipped rather than rejecting the whole file. predict.py writes one such line, holding only the image name, for every image it scored and found nothing on.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? BoundingBoxResultFile(System.Collections.Generic.IEnumerable<string>? values);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(System.Collections.Generic.IEnumerable_string_).values'></a>

`values` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The lines to parse\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
A [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') instance containing the parsed results, or `null` when there are no lines to parse\.

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(thisDiGi.YOLO.Classes.YOLOPredictionResult)'></a>

## Create\.BoundingBoxResultFile\(this YOLOPredictionResult\) Method

Parses the detections a prediction run produced into a [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') collection\.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? BoundingBoxResultFile(this DiGi.YOLO.Classes.YOLOPredictionResult? yOLOPredictionResult);
```
#### Parameters

<a name='DiGi.YOLO.Create.BoundingBoxResultFile(thisDiGi.YOLO.Classes.YOLOPredictionResult).yOLOPredictionResult'></a>

`yOLOPredictionResult` [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult')

The result of the prediction run\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
A [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') instance containing the parsed results, or `null` when the run did not complete or produced no result file\.

<a name='DiGi.YOLO.Create.ConfigurationFile(string)'></a>

## Create\.ConfigurationFile\(string\) Method

Parses an ultralytics dataset file \(conf\.yaml\) from the specified path and creates a [ConfigurationFile\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.ConfigurationFile(string) 'DiGi\.YOLO\.Create\.ConfigurationFile\(string\)') instance\.

The file is read key by key. Blank lines, comment lines and trailing " #" comments are skipped. The label block after "names:" ends at the first line that is not an "<int>: <name>" entry, and a file without "names:" has no labels.

The "path:" value is resolved against the directory of the file rather than against the current directory: a missing value means that directory, a relative value is combined with it. When the resolved directory does not exist - typically an absolute path written on another machine - the directory of the file is used instead and [Messages](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile.Messages 'DiGi\.YOLO\.Classes\.ConfigurationFile\.Messages') says so, because the images would otherwise read as none at all with no error.

```csharp
public static DiGi.YOLO.Classes.ConfigurationFile? ConfigurationFile(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Create.ConfigurationFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the configuration file\.

#### Returns
[ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile')  
A [ConfigurationFile\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.ConfigurationFile(string) 'DiGi\.YOLO\.Create\.ConfigurationFile\(string\)') object if the file exists and is successfully parsed; otherwise, `null`\.

<a name='DiGi.YOLO.Create.LabelFile(string)'></a>

## Create\.LabelFile\(string\) Method

Parses a YOLO label file from the specified path and returns a LabelFile object containing the bounding boxes\.

```csharp
public static DiGi.YOLO.Classes.LabelFile? LabelFile(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Create.LabelFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the label file\.

#### Returns
[LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile')  
A [LabelFile\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.LabelFile(string) 'DiGi\.YOLO\.Create\.LabelFile\(string\)') instance if the file exists and contains valid data; otherwise, null\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double)'></a>

## Create\.YOLOPredictionOptions\(string, string, string, string, string, double\) Method

Builds the options for one run of the YOLO prediction script, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run\.

The [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') constructors only assign, so this is where the work belongs. It resolves first and validates afterwards, because the interpreter is usually given by name rather than by path and a name cannot be checked until it has been looked up.

The working directory is not created here. It is created by [Predict\(this YOLOPredictionOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Predict\(this DiGi\.YOLO\.Classes\.YOLOPredictionOptions, System\.Threading\.CancellationToken\)'), along with the scripts that have to sit in it.

```csharp
public static DiGi.YOLO.Classes.YOLOPredictionOptions? YOLOPredictionOptions(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, string? workingDirectory=null, double confidence=0.1);
```
#### Parameters

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained weights file to score with\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).sourceDirectory'></a>

`sourceDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory holding the images to score\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file to write\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the process runs in and the scripts are kept in\. Null uses the directory holding the output file\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double).confidence'></a>

`confidence` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The confidence threshold a detection has to reach to be reported\.

#### Returns
[YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')  
The options, or `null` when no interpreter was found, a required path is missing, or the confidence is not a value between zero and one\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int)'></a>

## Create\.YOLOPredictionOptions\(string, string, string, string, string, double, int\) Method

Builds the options for one run of the YOLO prediction script with a custom batch size, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run\.

The [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') constructors only assign, so this is where the work belongs. It resolves first and validates afterwards, because the interpreter is usually given by name rather than by path and a name cannot be checked until it has been looked up.

The working directory is not created here. It is created by [Predict\(this YOLOPredictionOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Predict\(this DiGi\.YOLO\.Classes\.YOLOPredictionOptions, System\.Threading\.CancellationToken\)'), along with the scripts that have to sit in it.

```csharp
public static DiGi.YOLO.Classes.YOLOPredictionOptions? YOLOPredictionOptions(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, string? workingDirectory, double confidence, int batchSize);
```
#### Parameters

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained weights file to score with\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).sourceDirectory'></a>

`sourceDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory holding the images to score\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file to write\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the process runs in and the scripts are kept in\. Null uses the directory holding the output file\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).confidence'></a>

`confidence` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The confidence threshold a detection has to reach to be reported\.

<a name='DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of images passed to the model in a single inference batch\.

#### Returns
[YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')  
The options, or `null` when no interpreter was found, a required path is missing, the confidence is not a value between zero and one, or the batch size is less than one\.

<a name='DiGi.YOLO.Create.YOLOTrainingOptions(string,string,string,string)'></a>

## Create\.YOLOTrainingOptions\(string, string, string, string\) Method

Builds the options for one run of the YOLO training script, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run\.

The [YOLOTrainingOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions') constructors only assign, so this is where the work belongs. It resolves first and validates afterwards, because the interpreter is usually given by name rather than by path and a name cannot be checked until it has been looked up.

The hyperparameters keep their defaults (150 epochs, patience 50, imgsz 640, batch 16, seed 0, AMP on) and are set on the returned options; [Train\(this YOLOTrainingOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Train(thisDiGi.YOLO.Classes.YOLOTrainingOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Train\(this DiGi\.YOLO\.Classes\.YOLOTrainingOptions, System\.Threading\.CancellationToken\)') rejects values that cannot make a run. [Project](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Project 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Project') is set to the "runs\detect" folder of the working directory, always absolute.

```csharp
public static DiGi.YOLO.Classes.YOLOTrainingOptions? YOLOTrainingOptions(string? pythonPath, string? modelPath, string? configurationFilePath, string? workingDirectory=null);
```
#### Parameters

<a name='DiGi.YOLO.Create.YOLOTrainingOptions(string,string,string,string).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Create.YOLOTrainingOptions(string,string,string,string).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the start weights: an existing \.pt checkpoint or \.yaml architecture definition\.

<a name='DiGi.YOLO.Create.YOLOTrainingOptions(string,string,string,string).configurationFilePath'></a>

`configurationFilePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the dataset configuration file \(conf\.yaml\)\.

<a name='DiGi.YOLO.Create.YOLOTrainingOptions(string,string,string,string).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the process runs in and the scripts are kept in\. Null uses the directory holding the configuration file\.

#### Returns
[YOLOTrainingOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions')  
The options, or `null` when no interpreter was found, the configuration file does not exist, or the start file does not exist or is neither a \.pt nor a \.yaml file\.

<a name='DiGi.YOLO.Create.YOLOValidationOptions(string,string,string,string)'></a>

## Create\.YOLOValidationOptions\(string, string, string, string\) Method

Builds the options for one run of the YOLO validation script, resolving the interpreter, normalizing the paths and then checking that the combination can actually make a run\.

The [YOLOValidationOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationOptions 'DiGi\.YOLO\.Classes\.YOLOValidationOptions') constructors only assign, so this is where the work belongs. The split, image size, batch and confidence keep their defaults (test, 640, 16, the ultralytics default) and are set on the returned options.

```csharp
public static DiGi.YOLO.Classes.YOLOValidationOptions? YOLOValidationOptions(string? pythonPath, string? modelPath, string? configurationFilePath, string? workingDirectory=null);
```
#### Parameters

<a name='DiGi.YOLO.Create.YOLOValidationOptions(string,string,string,string).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Create.YOLOValidationOptions(string,string,string,string).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the weights file to validate, an existing \.pt checkpoint\.

<a name='DiGi.YOLO.Create.YOLOValidationOptions(string,string,string,string).configurationFilePath'></a>

`configurationFilePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the dataset configuration file \(conf\.yaml\)\.

<a name='DiGi.YOLO.Create.YOLOValidationOptions(string,string,string,string).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the process runs in and the scripts are kept in\. Null uses the directory holding the configuration file\.

#### Returns
[YOLOValidationOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationOptions 'DiGi\.YOLO\.Classes\.YOLOValidationOptions')  
The options, or `null` when no interpreter was found, the configuration file does not exist, or the weights file does not exist or is not a \.pt checkpoint\.

<a name='DiGi.YOLO.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.YOLO.Modify.Append(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string)'></a>

## Modify\.Append\(this BoundingBoxResultFile, string\) Method

Appends the contents of a bounding box result file to a specified file path\.

```csharp
public static bool Append(this DiGi.YOLO.Classes.BoundingBoxResultFile? boundingBoxResultFile, string? path);
```
#### Parameters

<a name='DiGi.YOLO.Modify.Append(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string).boundingBoxResultFile'></a>

`boundingBoxResultFile` [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')

The collection of bounding box results to append\.

<a name='DiGi.YOLO.Modify.Append(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The destination file path where data will be appended\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the operation was successful; otherwise, false\.

<a name='DiGi.YOLO.Modify.ClearData(thisDiGi.YOLO.Classes.YOLOModel)'></a>

## Modify\.ClearData\(this YOLOModel\) Method

Clears the data associated with the specified YOLO model, including cache files and images/labels for various categories\.

```csharp
public static bool ClearData(this DiGi.YOLO.Classes.YOLOModel? yOLOModel);
```
#### Parameters

<a name='DiGi.YOLO.Modify.ClearData(thisDiGi.YOLO.Classes.YOLOModel).yOLOModel'></a>

`yOLOModel` [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel')

The YOLO model instance whose data should be cleared\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if any files were successfully deleted; otherwise, false\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken)'></a>

## Modify\.Predict\(string, string, string, string, int, CancellationToken\) Method

Runs the YOLO prediction script over a directory of images in a CPython process with a custom batch size and returns the detections it found\.

A convenience over [Predict\(this YOLOPredictionOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Predict\(this DiGi\.YOLO\.Classes\.YOLOPredictionOptions, System\.Threading\.CancellationToken\)') for callers that only want the detections. A run that did not complete gives `null`, with no account of why - take the other overload when that matters, which for an unattended run it does.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? Predict(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, int batchSize, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained weights file to score with\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).sourceDirectory'></a>

`sourceDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory holding the images to score\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file to write\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of images passed to the model in a single inference batch\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
The detections, or `null` when the options could not be built or the run did not complete\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken)'></a>

## Modify\.Predict\(string, string, string, string, CancellationToken\) Method

Runs the YOLO prediction script over a directory of images in a CPython process and returns the detections it found\.

A convenience over [Predict\(this YOLOPredictionOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Predict\(this DiGi\.YOLO\.Classes\.YOLOPredictionOptions, System\.Threading\.CancellationToken\)') for callers that only want the detections. A run that did not complete gives `null`, with no account of why - take the other overload when that matters, which for an unattended run it does.

```csharp
public static DiGi.YOLO.Classes.BoundingBoxResultFile? Predict(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, or the name of one on PATH\. Null searches PATH\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained weights file to score with\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).sourceDirectory'></a>

`sourceDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory holding the images to score\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file to write\.

<a name='DiGi.YOLO.Modify.Predict(string,string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')  
The detections, or `null` when the options could not be built or the run did not complete\.

<a name='DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken)'></a>

## Modify\.Predict\(this YOLOPredictionOptions, CancellationToken\) Method

Runs the YOLO prediction script over a directory of images in a CPython process and reports how the run went\.

The scripts are written into the working directory on every run, so a directory never keeps a script of an older build, a stale result file is removed so a failed run cannot be mistaken for this one, and the process is then run with its output streams captured. A source directory holding no images is answered without starting a process at all, because predict.py writes no result file in that case and the missing file would otherwise be indistinguishable from a crash.

The ultralytics settings file is isolated in the working directory: the process is started with YOLO_CONFIG_DIR pointing at the .yolo-config folder of that directory, so the run never reads or rewrites the shared machine-wide settings file another ultralytics version uses.

The run is synchronous. Cancelling it kills the interpreter and returns a result carrying a non-zero exit code rather than throwing. Only the interpreter is killed - this targets netstandard2.0, which has no overload for killing a whole process tree, so torch worker processes can outlive the cancellation.

```csharp
public static DiGi.YOLO.Classes.YOLOPredictionResult? Predict(this DiGi.YOLO.Classes.YOLOPredictionOptions? yOLOPredictionOptions, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken).yOLOPredictionOptions'></a>

`yOLOPredictionOptions` [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')

The settings for the run\.

<a name='DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult')  
The result of the run, or `null` when the options are missing the interpreter, the weights, the source directory or the output path\.

<a name='DiGi.YOLO.Modify.Read(string)'></a>

## Modify\.Read\(string\) Method

Reads a YOLO model configuration and associated image and label files from the specified path\.

Only "*.jpeg" images are enumerated - the extension the dataset builders write. The dataset directory is the "path:" of the file resolved against the file's own directory; when it does not exist the file's directory is used and [Messages](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel.Messages 'DiGi\.YOLO\.Classes\.YOLOModel\.Messages') says so (see [ConfigurationFile\(string\)](DiGi.YOLO.md#DiGi.YOLO.Create.ConfigurationFile(string) 'DiGi\.YOLO\.Create\.ConfigurationFile\(string\)')).

```csharp
public static DiGi.YOLO.Classes.YOLOModel? Read(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Modify.Read(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the configuration file\.

#### Returns
[YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel')  
A [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel') instance if the configuration is valid and found; otherwise, null\.

<a name='DiGi.YOLO.Modify.Train(thisDiGi.YOLO.Classes.YOLOTrainingOptions,System.Threading.CancellationToken)'></a>

## Modify\.Train\(this YOLOTrainingOptions, CancellationToken\) Method

Runs the YOLO training script in a CPython process and reports the identity of the weights it started from and of the weights it wrote\.

The scripts are rewritten in the working directory before every run, so a directory never trains with a train.py of an older build; the conf.yaml of a dataset in that directory is left alone. The start weights are hashed here, before the process starts, because the output streams keep only their tail. A checkpoint start file is preflighted with [YOLOEnvironmentResult\(string, string, string, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken) 'DiGi\.YOLO\.Query\.YOLOEnvironmentResult\(string, string, string, System\.Threading\.CancellationToken\)'), which rejects an ultralytics too old for it.

The run directory is created under [Project](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Project 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Project'), always passed as an absolute path. A run whose project folder lies inside a YOLO\models folder is refused, and ultralytics numbers a run name that is already taken rather than reusing its directory, so no run can replace the frozen model.pt. The ultralytics settings file is isolated in the .yolo-config folder of the working directory.

When [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set the run continues that interrupted checkpoint instead: the script is given only --resume and --device, because ultralytics restores every other argument from the checkpoint and the ceiling is fixed. The checkpoint is read first - through [YOLOCheckpointInformation\(string, string, string, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Query.YOLOCheckpointInformation(string,string,string,System.Threading.CancellationToken) 'DiGi\.YOLO\.Query\.YOLOCheckpointInformation\(string, string, string, System\.Threading\.CancellationToken\)') - so a finished checkpoint, a dataset that no longer exists or a run folder inside a YOLO\models folder is refused before a process starts. The result records [Resumed](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult.Resumed 'DiGi\.YOLO\.Classes\.YOLOTrainingResult\.Resumed') and the epoch it entered.

The weights identity is read from the success block train.py prints last and confirmed against the file on disk; a digest that does not match is dropped and the result does not succeed. ultralytics may download yolo26n.pt into the "weights" folder of the working directory for its AMP check and falls back to full precision without it - [Amp](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult.Amp 'DiGi\.YOLO\.Classes\.YOLOTrainingResult\.Amp') reports the precision actually used.

The run is synchronous and can take hours. Cancelling it, or reaching [InactivityTimeout](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.InactivityTimeout 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.InactivityTimeout') when neither output stream has produced a line for that long, ends the interpreter together with the worker processes it started and returns a result carrying a non-zero exit code rather than throwing; a run ended that way for silence is reported through [Stalled](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult.Stalled 'DiGi\.YOLO\.Classes\.YOLOTrainingResult\.Stalled').

```csharp
public static DiGi.YOLO.Classes.YOLOTrainingResult? Train(this DiGi.YOLO.Classes.YOLOTrainingOptions? yOLOTrainingOptions, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Modify.Train(thisDiGi.YOLO.Classes.YOLOTrainingOptions,System.Threading.CancellationToken).yOLOTrainingOptions'></a>

`yOLOTrainingOptions` [YOLOTrainingOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions')

The settings for the run\.

<a name='DiGi.YOLO.Modify.Train(thisDiGi.YOLO.Classes.YOLOTrainingOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[YOLOTrainingResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult 'DiGi\.YOLO\.Classes\.YOLOTrainingResult')  
The result of the run, or `null` when the options are missing the interpreter, the start weights or the configuration file\.

<a name='DiGi.YOLO.Modify.Validate(thisDiGi.YOLO.Classes.YOLOValidationOptions,System.Threading.CancellationToken)'></a>

## Modify\.Validate\(this YOLOValidationOptions, CancellationToken\) Method

Runs the YOLO validation script in a CPython process and reports the box mAP of a weights file on one split of a dataset\.

Run once per weights file on the same split to compare detectors - the frozen train8 and each training candidate on the test split, for instance. The weights are hashed before the run, so every result names exactly which file it measured. The scripts are rewritten in the working directory first, the weights are preflighted with [YOLOEnvironmentResult\(string, string, string, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken) 'DiGi\.YOLO\.Query\.YOLOEnvironmentResult\(string, string, string, System\.Threading\.CancellationToken\)'), and the ultralytics settings file is isolated in the .yolo-config folder of the working directory.

The run is synchronous. Cancelling it kills the interpreter and returns a result carrying a non-zero exit code rather than throwing.

```csharp
public static DiGi.YOLO.Classes.YOLOValidationResult? Validate(this DiGi.YOLO.Classes.YOLOValidationOptions? yOLOValidationOptions, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Modify.Validate(thisDiGi.YOLO.Classes.YOLOValidationOptions,System.Threading.CancellationToken).yOLOValidationOptions'></a>

`yOLOValidationOptions` [YOLOValidationOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationOptions 'DiGi\.YOLO\.Classes\.YOLOValidationOptions')

The settings for the run\.

<a name='DiGi.YOLO.Modify.Validate(thisDiGi.YOLO.Classes.YOLOValidationOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[YOLOValidationResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationResult 'DiGi\.YOLO\.Classes\.YOLOValidationResult')  
The result of the run, or `null` when the options are missing the interpreter, the weights or the configuration file\.

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string)'></a>

## Modify\.Write\(this BoundingBoxResultFile, string\) Method

Writes the contents of a bounding box result file to the specified file path\.

```csharp
public static bool Write(this DiGi.YOLO.Classes.BoundingBoxResultFile? boundingBoxResultFile, string? path);
```
#### Parameters

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string).boundingBoxResultFile'></a>

`boundingBoxResultFile` [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile')

The collection of bounding box results to write\.

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.BoundingBoxResultFile,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The destination file path where the results will be saved\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the file was written successfully; otherwise, false\.

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.YOLOModel)'></a>

## Modify\.Write\(this YOLOModel\) Method

Writes the YOLO model data, including configuration files, images, and labels, to the filesystem\.

The runner scripts are written first and the dataset's conf.yaml after them. The scripts include a template conf.yaml; [WriteScripts\(string\)](DiGi.YOLO.md#DiGi.YOLO.Modify.WriteScripts(string) 'DiGi\.YOLO\.Modify\.WriteScripts\(string\)') no longer replaces an existing one, and writing the dataset's file last keeps it the file that counts either way.

The "path:" of conf.yaml is written absolute, so ultralytics finds the images whatever directory it is started from rather than resolving the value against its own datasets directory.

```csharp
public static bool Write(this DiGi.YOLO.Classes.YOLOModel? yOLOModel);
```
#### Parameters

<a name='DiGi.YOLO.Modify.Write(thisDiGi.YOLO.Classes.YOLOModel).yOLOModel'></a>

`yOLOModel` [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel')

The YOLO model instance containing the data to be written\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the writing process was successful; otherwise, false\.

<a name='DiGi.YOLO.Modify.WriteScripts(string)'></a>

## Modify\.WriteScripts\(string\) Method

Writes the YOLO Python runner scripts and configuration files into the specified directory\.

The scripts ship inside this assembly, so this works in any host that loads it. A YOLO folder sitting beside the assembly is used in preference, which lets a script be edited in a build output and tried without rebuilding.

predict.py, train.py and export.py import utils.py, and Python resolves that against the directory the script sits in, so the files are only useful written together.

The scripts are always rewritten, so a directory never keeps running a script of an older build. The template conf.yaml is the exception: it is data rather than a script, so it is written only when the directory has none and never replaces the conf.yaml of a dataset written there.

```csharp
public static bool WriteScripts(string? directory);
```
#### Parameters

<a name='DiGi.YOLO.Modify.WriteScripts(string).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The target directory path where scripts will be written\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if every script file was written; otherwise, false\.

<a name='DiGi.YOLO.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.YOLO.Query.CheckJsonLine(System.Collections.Generic.List_string_)'></a>

## Query\.CheckJsonLine\(List\<string\>\) Method

Finds the JSON payload line of a check\.py run in its captured stdout\.

The payload is the first non-empty line between the [CheckJsonBegin](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Marker.CheckJsonBegin 'DiGi\.YOLO\.Constants\.Marker\.CheckJsonBegin') and [CheckJsonEnd](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Marker.CheckJsonEnd 'DiGi\.YOLO\.Constants\.Marker\.CheckJsonEnd') markers, so the result does not depend on what the interpreter or ultralytics print before or after it - a settings notice included.

```csharp
public static string? CheckJsonLine(System.Collections.Generic.List<string> standardOutput);
```
#### Parameters

<a name='DiGi.YOLO.Query.CheckJsonLine(System.Collections.Generic.List_string_).standardOutput'></a>

`standardOutput` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

The captured stdout lines of the run\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The JSON payload line, or `null` when the markers or the payload between them are absent\.

<a name='DiGi.YOLO.Query.CheckJsonLine(System.Collections.Generic.List_string_,string,string)'></a>

## Query\.CheckJsonLine\(List\<string\>, string, string\) Method

Finds the JSON payload line a YOLO script writes between a pair of marker lines in its captured stdout\.

The payload is the first non-empty line between the begin and end markers, so the result does not depend on what the interpreter, ultralytics or the script print before or after it - a settings notice included. check.py and checkpoint.py share this contract with different marker pairs.

```csharp
public static string? CheckJsonLine(System.Collections.Generic.List<string> standardOutput, string beginMarker, string endMarker);
```
#### Parameters

<a name='DiGi.YOLO.Query.CheckJsonLine(System.Collections.Generic.List_string_,string,string).standardOutput'></a>

`standardOutput` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

The captured stdout lines of the run\.

<a name='DiGi.YOLO.Query.CheckJsonLine(System.Collections.Generic.List_string_,string,string).beginMarker'></a>

`beginMarker` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The marker line the script prints immediately before its JSON payload\.

<a name='DiGi.YOLO.Query.CheckJsonLine(System.Collections.Generic.List_string_,string,string).endMarker'></a>

`endMarker` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The marker line the script prints immediately after its JSON payload\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The JSON payload line, or `null` when the markers or the payload between them are absent\.

<a name='DiGi.YOLO.Query.ConfigEnvironmentVariables(string)'></a>

## Query\.ConfigEnvironmentVariables\(string\) Method

Returns the environment variables a run in the given working directory gets, pointing ultralytics at the settings directory of that working directory\.

The YOLO_CONFIG_DIR variable is set to the .yolo-config folder inside the working directory (created when missing), so the settings file an ultralytics version reads and writes lives in the working directory instead of the shared machine-wide one. Without it, whichever version runs after the other rewrites the file it does not expect, prints a settings notice on stdout and loses the custom values the other version had stored.

```csharp
public static System.Collections.Generic.Dictionary<string,string> ConfigEnvironmentVariables(string workingDirectory);
```
#### Parameters

<a name='DiGi.YOLO.Query.ConfigEnvironmentVariables(string).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The working directory of the run\.

#### Returns
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')  
The environment variables to set on the process the run starts\.

<a name='DiGi.YOLO.Query.Decode(string)'></a>

## Query\.Decode\(string\) Method

Decodes a YAML path value of an ultralytics dataset file: surrounding single or double quotes are removed, URL\-encoded spaces written by earlier versions become spaces, and forward slashes become backslashes\.

```csharp
public static string? Decode(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.Decode(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The encoded path string to be decoded\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The decoded path string, or an empty string if the provided path is null or whitespace\.

<a name='DiGi.YOLO.Query.DirectoryName(thisDiGi.YOLO.Enums.Category)'></a>

## Query\.DirectoryName\(this Category\) Method

Returns the directory name associated with the specified category\.

```csharp
public static string? DirectoryName(this DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Query.DirectoryName(thisDiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category for which to retrieve the directory name\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string representing the directory name \(e\.g\., "val", "train", "test"\), or `null` if no mapping is found\.

<a name='DiGi.YOLO.Query.Encode(string)'></a>

## Query\.Encode\(string\) Method

Encodes a path as a YAML value of an ultralytics dataset file: backslashes become forward slashes, and the value is single\-quoted when YAML would otherwise read part of it as a comment or a mapping\.

Spaces are kept as they are. ultralytics hands the value to the file system unchanged, so a "%20" written here would name a directory that does not exist - every path under "user files" did. [Decode\(string\)](DiGi.YOLO.md#DiGi.YOLO.Query.Decode(string) 'DiGi\.YOLO\.Query\.Decode\(string\)') still reads "%20" in files written before this change.

```csharp
public static string Encode(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.Encode(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path string to be encoded\. This value can be null\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
An encoded version of the path, or an empty string if the provided path is null or whitespace\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken)'></a>

## Query\.ExecuteProcess\(string, string, string, Dictionary\<string,string\>, Nullable\<TimeSpan\>, CancellationToken\) Method

Executes a process with captured standard output and standard error streams, additional environment variables, cancellation support, and an inactivity limit that ends a process which stops producing output\.

Launches the process without creating a window, using UTF-8 encodings for both streams. Reading both streams asynchronously prevents deadlocks when process output buffers fill up. Cancelling or reaching the limit ends the process together with every process it started.

```csharp
public static (int ExitCode,System.Collections.Generic.List<string> StandardOutput,System.Collections.Generic.List<string> StandardError,bool Stalled) ExecuteProcess(string executablePath, string arguments, string workingDirectory, System.Collections.Generic.Dictionary<string,string>? environmentVariables, System.Nullable<System.TimeSpan> inactivityTimeout, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).executablePath'></a>

`executablePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the executable process to run\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).arguments'></a>

`arguments` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The command line arguments passed to the process\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The working directory context for the process execution\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).environmentVariables'></a>

`environmentVariables` [System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

The environment variables set on the process on top of the inherited environment, or `null`\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).inactivityTimeout'></a>

`inactivityTimeout` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The span without a line on either output stream after which the process is ended, or `null` for no limit\. A value that is not positive disables the limit as well\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels process execution\.

#### Returns
[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
A tuple containing the process exit code \(\-1 when the process was cancelled or ended for inactivity\), standard output lines, standard error lines, and whether the process was ended for inactivity\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Threading.CancellationToken)'></a>

## Query\.ExecuteProcess\(string, string, string, Dictionary\<string,string\>, CancellationToken\) Method

Executes a process with captured standard output and standard error streams, additional environment variables and cancellation support\.

Same contract as [ExecuteProcess\(string, string, string, Dictionary&lt;string,string&gt;, Nullable&lt;TimeSpan&gt;, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken) 'DiGi\.YOLO\.Query\.ExecuteProcess\(string, string, string, System\.Collections\.Generic\.Dictionary\<string,string\>, System\.Nullable\<System\.TimeSpan\>, System\.Threading\.CancellationToken\)'), without an inactivity limit.

```csharp
public static (int ExitCode,System.Collections.Generic.List<string> StandardOutput,System.Collections.Generic.List<string> StandardError) ExecuteProcess(string executablePath, string arguments, string workingDirectory, System.Collections.Generic.Dictionary<string,string>? environmentVariables, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Threading.CancellationToken).executablePath'></a>

`executablePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the executable process to run\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Threading.CancellationToken).arguments'></a>

`arguments` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The command line arguments passed to the process\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Threading.CancellationToken).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The working directory context for the process execution\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Threading.CancellationToken).environmentVariables'></a>

`environmentVariables` [System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

The environment variables set on the process on top of the inherited environment, or `null`\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels process execution\.

#### Returns
[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
A tuple containing the process exit code, standard output lines, and standard error lines\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken)'></a>

## Query\.ExecuteProcess\(string, string, string, CancellationToken\) Method

Executes a process with captured standard output and standard error streams while supporting cancellation\.

Launches the process without creating a window, using UTF-8 encodings for both streams. Reading both streams asynchronously prevents deadlocks when process output buffers fill up.

```csharp
public static (int ExitCode,System.Collections.Generic.List<string> StandardOutput,System.Collections.Generic.List<string> StandardError) ExecuteProcess(string executablePath, string arguments, string workingDirectory, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken).executablePath'></a>

`executablePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the executable process to run\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken).arguments'></a>

`arguments` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The command line arguments passed to the process\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The working directory context for the process execution\.

<a name='DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels process execution\.

#### Returns
[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
A tuple containing the process exit code, standard output lines, and standard error lines\.

<a name='DiGi.YOLO.Query.FileSHA256(string)'></a>

## Query\.FileSHA256\(string\) Method

Computes the SHA\-256 digest of a file as lowercase hexadecimal \- the form train\.py and export\.py print and the README provenance tables record\.

```csharp
public static string? FileSHA256(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.FileSHA256(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the file to hash\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The 64\-character lowercase hexadecimal digest, or `null` when the path is empty, the file does not exist or cannot be read\.

<a name='DiGi.YOLO.Query.IsInsideModelsDirectory(string)'></a>

## Query\.IsInsideModelsDirectory\(string\) Method

Checks whether a path is a YOLO\\models folder or lies anywhere inside one \- the place the frozen weights live, which no training run may write into\.

The path is made absolute first and compared with a trailing separator, case-insensitively, so "...\YOLO\models" itself and "...\yolo\MODELS\run" both count while a sibling such as "...\YOLO\models_old" does not. The folder names are [YOLO](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.DirectoryName.YOLO 'DiGi\.YOLO\.Constants\.DirectoryName\.YOLO') and [Models](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.DirectoryName.Models 'DiGi\.YOLO\.Constants\.DirectoryName\.Models').

A relative path is resolved against the current directory of the calling process, so a caller handing the path to another process resolves it the way that process will before asking.

A null, blank or unformable path returns `false`: it names no folder, and every caller refuses such a path for its own, more specific reason.

```csharp
public static bool IsInsideModelsDirectory(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.IsInsideModelsDirectory(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory path to check\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when the path is, or lies inside, a YOLO\\models folder; otherwise `false`\.

<a name='DiGi.YOLO.Query.ModelKind(string)'></a>

## Query\.ModelKind\(string\) Method

Gets the kind of start file a training run would read from its extension: \.pt is a checkpoint, \.yaml or \.yml an architecture definition\.

The same rule train.py applies, so the runner rejects a start file the script would reject before an interpreter is started.

```csharp
public static DiGi.YOLO.Enums.ModelKind ModelKind(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.ModelKind(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the start file\. The file does not have to exist\.

#### Returns
[ModelKind](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.ModelKind 'DiGi\.YOLO\.Enums\.ModelKind')  
The kind of the file, or [Undefined](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.ModelKind.Undefined 'DiGi\.YOLO\.Enums\.ModelKind\.Undefined') when the path is empty or has another extension\.

<a name='DiGi.YOLO.Query.NormalizedPath(string)'></a>

## Query\.NormalizedPath\(string\) Method

Returns the full form of a path with any trailing directory separator removed\.

The separator matters because these paths are handed to a process on its command line. On Windows a backslash immediately before a closing quote escapes that quote, so a directory written as "C:\scratch\" swallows the argument that follows it and the process sees something entirely different from what was intended.

A root such as "C:\" keeps its separator, because removing it would leave a drive letter that names the current directory of that drive rather than its root.

```csharp
public static string? NormalizedPath(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.NormalizedPath(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to normalize\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The normalized path, or `null` when the path is null, empty, or cannot be resolved to a full path\.

<a name='DiGi.YOLO.Query.PredictArguments(thisDiGi.YOLO.Classes.YOLOPredictionOptions)'></a>

## Query\.PredictArguments\(this YOLOPredictionOptions\) Method

Builds the command line arguments that run predict\.py for the given options: the script path followed by its flags\.

The paths are taken as given, so pass options whose paths are already resolved - [Predict\(this YOLOPredictionOptions, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Modify.Predict(thisDiGi.YOLO.Classes.YOLOPredictionOptions,System.Threading.CancellationToken) 'DiGi\.YOLO\.Modify\.Predict\(this DiGi\.YOLO\.Classes\.YOLOPredictionOptions, System\.Threading\.CancellationToken\)') does. Numbers are written in the invariant culture, because argparse parses them with float() and int(), which read a decimal point and nothing else.

The settings that change the detections are passed only when asked for: --imgsz only for a positive multiple of 32, --half only when on. Without them the model is called exactly as earlier builds called it (DiGi-Organization/DiGi.YOLO#24). --workers is always passed, a negative value as 0, because it changes only the time a run takes. A batch size below one is passed as 32, the script's own default.

```csharp
public static string? PredictArguments(this DiGi.YOLO.Classes.YOLOPredictionOptions? yOLOPredictionOptions);
```
#### Parameters

<a name='DiGi.YOLO.Query.PredictArguments(thisDiGi.YOLO.Classes.YOLOPredictionOptions).yOLOPredictionOptions'></a>

`yOLOPredictionOptions` [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')

The options of the run\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The arguments, or `null` when the options are missing the weights, the source directory, the output path or the working directory\.

<a name='DiGi.YOLO.Query.PythonPath(string)'></a>

## Query\.PythonPath\(string\) Method

Resolves the CPython interpreter that runs the YOLO scripts\.

A path that names an existing file is taken as given. Anything else, including `null`, is looked for on PATH, trying "python" and then "python3", in PATH order.

A Windows app execution alias is accepted like any other match even though it is a zero byte reparse point, because it is a working interpreter whenever its app is installed. When the app is not installed the alias opens the Microsoft Store instead and the run fails; that failure is reported through the result's standard error rather than avoided by guessing.

The interpreter has to be CPython with ultralytics and torch installed. The IronPython engine in DiGi.Scripting.Python cannot host either of them, so it is not an alternative to this.

```csharp
public static string? PythonPath(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Query.PythonPath(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of an interpreter, the name of one on PATH, or `null` to search for one\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The full path of the interpreter, or `null` when none was found\.

<a name='DiGi.YOLO.Query.PythonPaths(string)'></a>

## Query\.PythonPaths\(string\) Method

Resolves all potential CPython interpreter candidate paths on PATH\.

If [path](DiGi.YOLO.md#DiGi.YOLO.Query.PythonPaths(string).path 'DiGi\.YOLO\.Query\.PythonPaths\(string\)\.path') names an existing file, it is returned as the single candidate. Otherwise, PATH is searched for [path](DiGi.YOLO.md#DiGi.YOLO.Query.PythonPaths(string).path 'DiGi\.YOLO\.Query\.PythonPaths\(string\)\.path') (if provided), "python", and "python3" in order, returning all distinct existing candidates found.

```csharp
public static System.Collections.Generic.List<string> PythonPaths(string? path=null);
```
#### Parameters

<a name='DiGi.YOLO.Query.PythonPaths(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of an interpreter, the command name of one on PATH, or `null` to search PATH\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of distinct resolved interpreter paths in search order\.

<a name='DiGi.YOLO.Query.YOLOCheckpointInformation(string,string,string,System.Threading.CancellationToken)'></a>

## Query\.YOLOCheckpointInformation\(string, string, string, CancellationToken\) Method

Reads what an ultralytics training checkpoint holds \- the epoch it completed, whether it can still be resumed, the dataset and run folder it records, and the raw arguments it was trained with \- by running checkpoint\.py with the configured interpreter\.

The script ships inside this assembly and is written into the working directory before it runs, with the ultralytics settings isolated in that directory's .yolo-config folder exactly as a training run isolates them, so nothing depends on what the machine-wide settings hold. The JSON payload is read from between the script's marker lines.

Returns `null` for a missing or unreadable file, an interpreter that does not exist or cannot read the checkpoint, and a payload that is absent or malformed. The caller that refuses a resume names the reason from the properties - a finished checkpoint, a dataset file that no longer exists - rather than from a diagnostic string.

```csharp
public static DiGi.YOLO.Classes.YOLOCheckpointInformation? YOLOCheckpointInformation(string? path, string? pythonPath=null, string? workingDirectory=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Query.YOLOCheckpointInformation(string,string,string,System.Threading.CancellationToken).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the checkpoint \(\.pt\) file to read\.

<a name='DiGi.YOLO.Query.YOLOCheckpointInformation(string,string,string,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, a command name on PATH, or `null` to search PATH\.

<a name='DiGi.YOLO.Query.YOLOCheckpointInformation(string,string,string,System.Threading.CancellationToken).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the script is written to and run in, or `null` to use temporary storage\.

<a name='DiGi.YOLO.Query.YOLOCheckpointInformation(string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the read\.

#### Returns
[YOLOCheckpointInformation](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation')  
The information the checkpoint holds, or `null` when it cannot be read\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken)'></a>

## Query\.YOLOEnvironmentResult\(string, string, string, CancellationToken\) Method

Probes Python interpreter candidates in a specified working directory context to detect whether the machine can execute YOLO workloads\.

The ultralytics settings file is isolated in the working directory: the probe points YOLO_CONFIG_DIR at its .yolo-config folder, and reads the JSON payload of check.py from between the script's marker lines.

```csharp
public static DiGi.YOLO.Classes.YOLOEnvironmentResult YOLOEnvironmentResult(string? pythonPath, string? modelPath, string? workingDirectory, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, a command name on PATH, or `null` to search PATH\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained model file to probe for compatibility, or `null`\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory where scripts are written and executed, or `null` to use temporary storage\. The ultralytics settings file of the probe is isolated in this directory\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels probing\.

#### Returns
[YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult')  
The result of the environment preflight check\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,System.Threading.CancellationToken)'></a>

## Query\.YOLOEnvironmentResult\(string, string, CancellationToken\) Method

Probes Python interpreter candidates to detect whether the machine can execute YOLO workloads, returning environment details and dependency versions\.

Checks candidate interpreters on PATH in order and reports the first interpreter that is runnable. Never throws an exception; probe failures or invalid interpreters are returned with [Runnable](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Runnable 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Runnable') set to `false` and diagnostic reasons in [Messages](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Messages 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Messages'). Non-fatal findings are returned in [Warnings](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Warnings 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Warnings') and do not affect [Runnable](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Runnable 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Runnable').

The probe isolates the ultralytics settings file in its working directory through YOLO_CONFIG_DIR, so switching ultralytics versions between probes no longer rewrites or loses the other's settings, and it reads the JSON payload of check.py from between the script's marker lines rather than from whatever line happens to start with a brace.

```csharp
public static DiGi.YOLO.Classes.YOLOEnvironmentResult YOLOEnvironmentResult(string? pythonPath, string? modelPath, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, a command name on PATH, or `null` to search PATH\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,System.Threading.CancellationToken).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the trained model file to probe for compatibility, or `null`\.

<a name='DiGi.YOLO.Query.YOLOEnvironmentResult(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels probing\.

#### Returns
[YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult')  
The result of the environment preflight check\.

<a name='DiGi.YOLO.Query.YOLOTrainingOutput(System.Collections.Generic.IEnumerable_string_)'></a>

## Query\.YOLOTrainingOutput\(IEnumerable\<string\>\) Method

Reads the success block train\.py prints at the end of a run \- the path, size and SHA\-256 digest of the best weights, the automatic mixed precision actually used, and, for a resumed run, the epoch it entered and the ceiling it restored \- from its standard output\.

The output is scanned from the end and the last line under each prefix wins. That is where the block is, and [ExecuteProcess\(string, string, string, Dictionary&lt;string,string&gt;, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Query.ExecuteProcess(string,string,string,System.Collections.Generic.Dictionary_string,string_,System.Threading.CancellationToken) 'DiGi\.YOLO\.Query\.ExecuteProcess\(string, string, string, System\.Collections\.Generic\.Dictionary\<string,string\>, System\.Threading\.CancellationToken\)') keeps only the tail of a stream, which a long run fills with training progress. A resumed run prints its resume values both before training and again in this block, because a value printed only at the start would not survive in the tail. Numbers are read with the invariant culture, the only form the script writes.

```csharp
public static (string? WeightsPath,System.Nullable<long> Bytes,string? SHA256,System.Nullable<bool> Amp,System.Nullable<int> ResumedFromEpoch,System.Nullable<int> ResumedEpochs) YOLOTrainingOutput(System.Collections.Generic.IEnumerable<string>? standardOutput);
```
#### Parameters

<a name='DiGi.YOLO.Query.YOLOTrainingOutput(System.Collections.Generic.IEnumerable_string_).standardOutput'></a>

`standardOutput` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The lines train\.py wrote to standard output\.

#### Returns
[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
The weights path, the size in bytes, the lowercase hexadecimal digest, the precision, and the 1\-based resumed epoch and its ceiling; each is `null` when its line is missing or cannot be read\.

<a name='DiGi.YOLO.Query.YOLOValidationOutput(System.Collections.Generic.IEnumerable_string_)'></a>

## Query\.YOLOValidationOutput\(IEnumerable\<string\>\) Method

Reads the box mAP values val\.py prints at the end of a run from its standard output\.

The output is scanned from the end and the last line under each prefix wins. Values are read with the invariant culture - Python prints a decimal point whatever the machine's culture - and a value outside [0, 1] is rejected.

```csharp
public static (System.Nullable<double> MAP50,System.Nullable<double> MAP50_95) YOLOValidationOutput(System.Collections.Generic.IEnumerable<string>? standardOutput);
```
#### Parameters

<a name='DiGi.YOLO.Query.YOLOValidationOutput(System.Collections.Generic.IEnumerable_string_).standardOutput'></a>

`standardOutput` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The lines val\.py wrote to standard output\.

#### Returns
[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')  
The mAP at IoU 0\.5 and the mAP averaged over IoU 0\.5 to 0\.95; each is `null` when its line is missing or cannot be read\.