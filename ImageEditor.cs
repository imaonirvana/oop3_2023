using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
namespace oop_lab3;

public class ImageEditor
{
    private readonly string _imagePath;
    private Image<Rgba64> _image;
    
    public ImageEditor(string imagePath)
    {
        _imagePath = imagePath;
        Load();
    }

    private void Load()
    {
        _image = Image.Load<Rgba64>(_imagePath);
    }

    public void Reverse()
    {
        _image.ProcessPixelRows(accessor =>
        {
            for (int y = 0; y < accessor.Height; y++)
            {
                var pixelRow = accessor.GetRowSpan(y);
                
                for (int x = 0; x < pixelRow.Length; x++)
                {
                    ref var pixel = ref pixelRow[x];

                    pixel.R = (ushort) (255 - pixel.R);
                    pixel.G = (ushort) (255 - pixel.G);
                    pixel.B = (ushort) (255 - pixel.B);
                }
            }
        });
    }

    public void ApplyChanges()
    {
        _image.Save(_imagePath);
    }
}