using System.Drawing;
using System.Drawing.Imaging;


namespace Erosion;

public class MorphologicalOperation
{
    public static Bitmap dilation(Bitmap b)
    {
        int[,] kernel =
        {
            { 0, 1, 0 },
            { 1, 1, 1 },
            { 0, 1, 0 }
        };

        int width = b.Width;

        int height = b.Height;
        
        Bitmap outputBitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
        BitmapData bmpData = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
        BitmapData outputData = outputBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

        unsafe
        {
              byte* mp = (byte*)bmpData.Scan0;
              
              byte* op = (byte*)outputData.Scan0;

              int stride = bmpData.Stride;

              for (int y = 1; y < height-1; y++)
              {
                  for (int x = 1; x < width-1; x++)
                  {
                      int valid = 1;
                      for (int ky = -1; ky <= 1; ky++)
                      {
                          for (int kx = -1; kx <= 1; kx++)
                          {
                              if (kernel[ky + 1, kx + 1] == 1)
                              {
                                  if (mp[(y + ky) * stride + x + kx] <30 )
                                  {
                                      valid = 0;
                                      break;
                                  }
                                  
                              }
                              
                          }
                          if (valid == 0)
                          {
                              break;
                          }
                          
                      }

                      if (valid == 0)
                      {
                          op[y * stride + x] =0;
                      }
                      
                      else if (valid ==1)
                      {
                          op[y * stride + x] = 255;

                      }
                      
                  }
              }
              
            



        }
        
        ColorPalette palette = outputBitmap.Palette;
        for (int i = 0; i < palette.Entries.Length; i++)
        {
            byte value = (byte)i;
            palette.Entries[i] = Color.FromArgb(value, value, value);
        }
        outputBitmap.Palette = palette;
        
        b.UnlockBits(bmpData);
        
        outputBitmap.UnlockBits(outputData);
        
        

        return outputBitmap;


    }
    public static Bitmap erosion(Bitmap b)
    {
        int[,] kernel =
        {
            { 0, 1, 0 },
            { 1, 1, 1 },
            { 0, 1, 0 }
        };

        int width = b.Width;

        int height = b.Height;
        
        Bitmap outputBitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
        BitmapData bmpData = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
        BitmapData outputData = outputBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

        unsafe
        {
              byte* mp = (byte*)bmpData.Scan0;
              
              byte* op = (byte*)outputData.Scan0;

              int stride = bmpData.Stride;

              for (int y = 0; y < height; y++)
              {
                  for (int x = 0; x < width; x++)
                  {
                      int valid = 1;
                      for (int ky = -1; ky <= 1; ky++)
                      {
                          for (int kx = -1; kx <= 1; kx++)
                          {
                              if (kernel[ky + 1, kx + 1] == 1)
                              {
                                  if (mp[(y + ky) * stride + x + kx] == 255)
                                  {
                                      valid = 0;
                                      break;
                                  }

                                 
                              }
                              
                          }
                          if (valid == 0)
                          {
                              break;
                          }
                          
                      }

                      if (valid == 0)
                      {
                          op[y * stride + x] =255;
                      }
                      
                      else if (valid ==1)
                      {
                          op[y * stride + x] = 0;

                      }
                      
                  }
              }

        }
        
        b.UnlockBits(bmpData);
        
        outputBitmap.UnlockBits(outputData);
        
        

        return outputBitmap;
    }

}