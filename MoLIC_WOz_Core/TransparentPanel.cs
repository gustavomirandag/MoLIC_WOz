using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoLIC_WOz_Core
{
    public partial class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            InitializeComponent();
        }

        private int _opacity = 50; 

        protected override CreateParams CreateParams 
        { 
            get 
            { 
                CreateParams cp = base.CreateParams; 
                cp.ExStyle |= 0x20; // Turn on WS_EX_TRANSPARENT 
                return cp; 
            } 
        }

        public int Opacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentException("Invalid value.  Opacity must be between 0 and 100 percent.");
                }
                _opacity = value;
                this.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int newOpacity = 0;
            newOpacity = (int)(_opacity * 2.55);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(newOpacity, Color.Black)), this.ClientRectangle);
        }

        
    }
}
