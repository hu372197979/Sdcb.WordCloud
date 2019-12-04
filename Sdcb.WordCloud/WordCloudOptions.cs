using SharpDX;
using SharpDX.DirectWrite;
using System.Collections.Generic;

namespace Sdcb.WordCloud
{
    public class WordCloudOptions
    {
        public WordCloudOptions(List<WordFrequencyDefinition> list, WordCloudShapes shapes)
        {
            this.List = list;
            this.ShapeFunction = shapes.ToShapeFunction();
        }

        public List<WordFrequencyDefinition> List { get; }

        public string FontFamily { get; set; } = "Consolas";

        public FontWeight FontWeight { get; set; } = FontWeight.Normal;

        public Color? WordColor { get; set; }

        public int MinSize { get; set; } = 0;

        public int WeightFactor { get; set; } = 1;

        public bool ClearCanvas { get; set; } = true;

        public Color BackgroundColor { get; set; } = Color.Black;




        public int GridSize { get; set; } = 8;

        public bool DrawOutOfBound { get; set; } = false;

        public bool ShrinkToFit { get; set; } = false;

        public Point? Origin { get; set; }




        public bool DrawMask { get; set; } = false;

        public Color MaskColor { get; set; } = new Color(1f, 0f, 0f, 0.3f);

        public float MaskGapWidth { get; set; } = 0.3f;





        public int Wait { get; set; } = 0;

        public int? AboutThreshold { get; set; }




        public float MinRotation { get; set; } = -MathUtil.PiOverTwo;

        public float MaxRotation { get; set; } = MathUtil.PiOverTwo;

        public float RotationSteps { get; set; } = 0;




        public bool Shuffle { get; set; } = true;

        public float RotateRadio { get; set; } = 0.1f;

        public ShapeFunction ShapeFunction { get; }

        public float Ellipticity { get; set; } = 0.65f;
    }

    public delegate float ShapeFunction(float θ);
}
