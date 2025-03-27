
using System.Drawing;
using System.Drawing.Imaging;


namespace Erosion;
class Program
{
    static void Main()
    {
        string filePath = "/home/basil/Desktop/C# ahsdksjhd/8bit_binary.bmp";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("The specified file does not exist.");
            return;
        }
        Bitmap bmp = (Bitmap)Image.FromFile(filePath);

        Bitmap ebm = MorphologicalOperation.erosion(bmp);
        
        Bitmap dbm = MorphologicalOperation.dilation(bmp);
        
        string outputImageFileNameErosion = "erosion.png";
        string outputImageFileNameDilation = "dilation.png";
        string outputImagePathErosion = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, outputImageFileNameErosion);
        string outputImagePathDilation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, outputImageFileNameDilation);
        ebm.Save(outputImagePathErosion, ImageFormat.Png);
        dbm.Save(outputImagePathDilation, ImageFormat.Png);
    }

    
}
