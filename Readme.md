# Morphological Image Processing (C# Console App)

This C# console application performs basic morphological operations — **erosion** and **dilation** — on a binary 8-bit grayscale image using a defined 3x3 cross-shaped kernel.

## Features

- Erosion and dilation operations implemented from scratch
- Processes 8-bit binary images using `System.Drawing`
- Applies operations using unsafe code for performance
- Saves the output as separate images

## Project Structure

- `Program.cs`  
  Loads the binary image, applies morphological operations, and saves the output.

- `MorphologicalOperation.cs`  
  Contains static methods for `erosion` and `dilation` using a 3x3 kernel:
  ```
  { 0, 1, 0 }
  { 1, 1, 1 }
  { 0, 1, 0 }
  ```

## How to Run

1. Open the project in Visual Studio or any C# IDE.
2. Ensure the input file path in `Program.cs` is updated correctly:
   ```csharp
   string filePath = "path_to_your_image.bmp";
   ```
3. Build and run the project.
4. The program will generate:
   - `erosion.png`
   - `dilation.png`
   in the application directory.

## Notes

- Only 8-bit binary (black & white) images are supported (`PixelFormat.Format8bppIndexed`).
- Operations assume white (255) as foreground and black (0) as background.
- The kernel and pixel thresholds can be adjusted for more complex behavior.
