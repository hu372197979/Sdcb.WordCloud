using System;
using static Sdcb.WordCloud.WordCloudShapes;

namespace Sdcb.WordCloud
{
    public enum WordCloudShapes
    {
        Circle,
        Cardioid,
        Diamond,
        Square,
        TriangleForward,
        TriangleUpright,
        Pentagon,
        Star,
    }

    public static class ShapeExtensions
    {
        public static ShapeFunction ToShapeFunction(this WordCloudShapes shape) => shape switch
        {
            Circle => new ShapeFunction(θ => 1.0f),
            Cardioid => new ShapeFunction(θ => 1 - MathF.Sin(θ)),
            Square => new ShapeFunction(θ =>
            {
                return MathF.Min(
                    1 / MathF.Abs(MathF.Cos(θ)),
                    1 / MathF.Abs(MathF.Sin(θ))
                    );
            }),
            TriangleForward => new ShapeFunction(θ =>
            {
                float θ1 = θ % (2 * MathF.PI / 3);
                return 1 / (MathF.Cos(θ1) + MathF.Sqrt(3) * MathF.Sin(θ1));
            }),
            TriangleUpright => new ShapeFunction(θ =>
            {
                float θ1 = (θ + MathF.PI * 3 / 2) % (2 * MathF.PI / 3);
                return 1 / (MathF.Cos(θ1) + MathF.Sqrt(3) * MathF.Sin(θ1));
            }),
            Pentagon => new ShapeFunction(θ =>
            {
                float θ1 = (θ + 0.955f) % (2 * MathF.PI / 5);
                return 1 / (MathF.Cos(θ1) + 0.726543f * MathF.Sin(θ1));
            }), 
            Star => new ShapeFunction(θ =>
            {
                float θ1 = (θ + 0.955f) % (2 * MathF.PI / 10);
                return ((θ + 0.955f) % (2 * MathF.PI / 5) - (2 * MathF.PI / 10) >= 0) switch
                {
                    true => 1 / (MathF.Cos((2 * MathF.PI / 10) - θ1) + 3.07768f * MathF.Sin((2 * MathF.PI / 10) - θ1)), 
                    false => 1 / (MathF.Cos(θ1) + 3.07768f * MathF.Sin(θ1)), 
                };
            }), 
            _ => throw new ArgumentOutOfRangeException(nameof(shape))
        };
    }
}
