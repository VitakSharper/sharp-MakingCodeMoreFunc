namespace DomainLogicSequences
{
    public class PaintingTask<TPainter> where TPainter : IPainter
    {
        public TPainter Painter { get; }
        public double SquareMeters { get; }

        public PaintingTask(TPainter painter, double squareMeters)
        {
            Painter = painter;
            SquareMeters = squareMeters;
        }
    }
}