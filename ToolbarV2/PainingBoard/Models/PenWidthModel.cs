namespace PainingBoard.Models
{
    public class PenWidthModel
    {
        #region FullProperty StrokeThickness
        private float _strokeThickness;

        public float StrokeThickness
        {
            get { return _strokeThickness; }
            set { _strokeThickness = value; }
        }
        #endregion	FullProperty StrokeThickness

        #region FullProperty ShowRadius
        private float _showRadius;

        public float ShowRadius
        {
            get { return _showRadius; }
            set { _showRadius = value; }
        }
        #endregion	FullProperty ShowRadius

        #region FullProperty Index
        private string _index;

        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }
        #endregion	FullProperty Index

        #region FullProperty WidthString
        private string _widthString;

        public string WidthString
        {
            get { return _widthString; }
            set { _widthString = value; }
        }
        #endregion	FullProperty WidthString
    }
}
