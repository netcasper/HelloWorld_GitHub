using System.Windows.Forms;

namespace WWStock.UI
{
    class UDTextBox : TextBox
    {
        public UDTextBox()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down)
            {
                return false;
            }
            return base.IsInputKey(keyData);
        }
    }
}
