using System.Windows;

namespace RecordLib.Controls
{
    public class RecordButton : ImageButton
    {

        #region DependencyProperty IsRecording

        public bool IsRecording
        {
            get { return (bool)GetValue(IsRecordingProperty); }
            set { SetValue(IsRecordingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsRecording.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRecordingProperty =
            DependencyProperty.Register("IsRecording", typeof(bool), typeof(RecordButton), new PropertyMetadata(default(bool)));


        #endregion
    }
}
