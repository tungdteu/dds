using System.Drawing;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;

namespace Common.ImageProcessing
{
    public class AForgeImplement
    {
        private static IFilter _whatFilterDoYouWant;

        private static Bitmap ApplyFilter(Bitmap needModify)
        {
            Bitmap bmp = _whatFilterDoYouWant.Apply(needModify);
            _whatFilterDoYouWant = null;
            return bmp;
        }

        public static Bitmap AForgeAdaptiveSmoothing(Bitmap needModify)
        {
            _whatFilterDoYouWant = new AdaptiveSmoothing();
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeBlur(Bitmap needModify)
        {
            _whatFilterDoYouWant = new Blur();
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeBrightnessCorrection(Bitmap needModify, double adjustValue)
        {
            _whatFilterDoYouWant = new BrightnessCorrection(adjustValue);
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeCanvasCrop(Bitmap needModify, int x, int y, int width, int height)
        {
            _whatFilterDoYouWant = new CanvasCrop(new Rectangle(x, y, width, height));
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeCanvasMove(Bitmap needModify, int x, int y, Color fillColorRGB)
        {
            _whatFilterDoYouWant = new CanvasMove(new Point(x, y), fillColorRGB);
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeConservativeSmoothing(Bitmap needModify)
        {
            _whatFilterDoYouWant = new ConservativeSmoothing();
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeCrop(Bitmap needModify, int x, int y, int width, int height)
        {
            _whatFilterDoYouWant = new Crop(new Rectangle(x, y, width, height));
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeGammaCorrection(Bitmap needModify, double gammar)
        {
            _whatFilterDoYouWant = new GammaCorrection(gammar);
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeMean(Bitmap needModify)
        {
            _whatFilterDoYouWant = new Mean();
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeMedian(Bitmap needModify)
        {
            _whatFilterDoYouWant = new Median();
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeMirror(Bitmap needModify, bool mirrorX, bool mirrorY)
        {
            _whatFilterDoYouWant = new Mirror(mirrorX, mirrorY);
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeResizeBicubic(Bitmap needModify, int width, int height)
        {
            _whatFilterDoYouWant = new ResizeBicubic(width, height);
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeResizeBilinear(Bitmap needModify, int width, int height)
        {
            _whatFilterDoYouWant = new ResizeBilinear(width, height);
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeRotateBicubic(Bitmap needModify, double angle, bool keepSize)
        {
            _whatFilterDoYouWant = new RotateBicubic(angle, keepSize);
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeRotateBilinear(Bitmap needModify, double angle, bool keepSize)
        {
            _whatFilterDoYouWant = new RotateBilinear(angle, keepSize);
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeSaturationCorrection(Bitmap needModify, double adjustValue)
        {
            _whatFilterDoYouWant = new SaturationCorrection(adjustValue);
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeSharpen(Bitmap needModify)
        {
            _whatFilterDoYouWant = new Sharpen();
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeTexturedFilter(Bitmap needModify)
        {
            _whatFilterDoYouWant = new TexturedFilter(new CloudsTexture(), new HueModifier(50));
            return ApplyFilter(needModify);
        }

        public static Bitmap AForgeShrink(Bitmap needModify)
        {
            _whatFilterDoYouWant = new Shrink();
            return ApplyFilter(needModify);
        }
    }
}