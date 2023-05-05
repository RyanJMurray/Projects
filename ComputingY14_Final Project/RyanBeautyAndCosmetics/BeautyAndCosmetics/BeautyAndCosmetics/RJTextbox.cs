using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace BeautyAndCosmetics
{
    [DefaultEvent("_TextChanged")]
    public partial class RJTextbox : UserControl
    {
        //Field
        private Color bordercolour = Color.MediumSeaGreen;
        private int bordersize = 2;
        private bool underlinedstyle = false;
        private Color borderfocuscolour = Color.HotPink;
        private bool isfocused = false;
        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;


        public RJTextbox()
        {
            InitializeComponent();
        }


        public event EventHandler _TextChanged;





        [Category("RJ Code Advance")]

        public Color Bordercolour
        {
            get
            {
                return bordercolour;
            }

            set
            {
                bordercolour = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]

        public int Bordersize
        {
            get
            {
                return bordersize;
            }

            set
            {
                bordersize = value;
                this.Invalidate();

            }
        }
        [Category("RJ Code Advance")]

        public bool Underlinedstyle
        {
            get
            {
                return underlinedstyle;
            }

            set
            {
                underlinedstyle = value;
                this.Invalidate();

            }
        }
        [Category("RJ Code Advance")]

        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                if (!isPlaceholder)
                    textBox1.UseSystemPasswordChar = value;
            }
        }


        [Category("RJ Code Advance")]

        public bool mutliline
        { get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; } }
        [Category("RJ Code Advance")]

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }
        [Category("RJ Code Advance")]

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }
        [Category("RJ Code Advance")]

        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("RJ Code Advance")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        [Category("RJ Code Advance")]
        public Color PlaceHolderColour
        {
            get { return placeholderColor; }
            set { placeholderColor = value;
                if (isPasswordChar)
                    textBox1.ForeColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public string PlaceHolderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }



        [Category("RJ Code Advance")]
        public Color Borderfocuscolour
        {
            get
            {
                return borderfocuscolour;
            }

            set
            {
                borderfocuscolour = value;
            }
        }

   


    

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1) // Rounded TextBox  
            {
                // - Fields
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -bordersize, -bordersize);
                int smoothSize = bordersize > 0 ? bordersize : 1;
                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - bordersize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(bordercolour, bordersize))
                {
                    // - Drawing
                    this.Region = new Region(pathBorderSmooth); // Set the rounded region of UserControl 
                    if (borderRadius > 15) SetTextRoundedRegion(); // Set the rounded region of TextBox component   
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isfocused) penBorder.Color = borderfocuscolour;
                    if (underlinedstyle) // Line Style 
                    {
                        // Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        // Draw border
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else // Normal Style
                    {
                        // Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        // Draw border
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else // Square / Normal TextBox
            {

                using (Pen penborder = new Pen(bordercolour, bordersize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penborder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    if (!isfocused)
                    {
                        if (underlinedstyle)
                            graph.DrawLine(penborder, 0, this.Height - 1, this.Width, this.Height - 1);

                        else
                            graph.DrawRectangle(penborder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);

                    }
                    else
                    {

                        penborder.Color = borderfocuscolour;
                        if (underlinedstyle)
                            graph.DrawLine(penborder, 0, this.Height - 1, this.Width, this.Height - 1);

                        else
                            graph.DrawRectangle(penborder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                    }


                }

            }
            
        }

           private void SetTextRoundedRegion()
        {
            GraphicsPath pathtxt;
            if (mutliline)
            {
                pathtxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - bordersize);
                textBox1.Region = new Region(pathtxt);
            }
            else
            {
                pathtxt = GetFigurePath(textBox1.ClientRectangle, bordersize * 2);
                textBox1.Region = new Region(pathtxt);
            }

            pathtxt.Dispose();

        }


        private void SetPlaceholder()
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText!= "" ) 
               {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = false;
               }
        }



        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText!= "" ) 
              {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }

       

        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(this.DesignMode)
            UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if(textBox1.Multiline == false)
            {
                int txtheight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtheight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(_TextChanged !=null)
                _TextChanged.Invoke(sender, e);

            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
          
        }

        

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);

        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isfocused = true;
            this.Invalidate();
            RemovePlaceholder();

        }



        private void textBox1_Leave(object sender, EventArgs e)
        {
            isfocused = false;
            this.Invalidate();
            SetPlaceholder();
                
        }

        public void Clear(bool searchRecursively = true)
        {
            Action<Control.ControlCollection, bool> clearTextBoxes = null;
            clearTextBoxes = (controls, searchChildren) =>
            {
                foreach (Control c in controls)
                {
                    TextBox txt = c as TextBox;
                    txt?.Clear();
                    if (searchChildren && c.HasChildren)
                        clearTextBoxes(c.Controls, true);
                }
            };

            clearTextBoxes(this.Controls, searchRecursively);
        }

      

        private void RJTextbox_Load(object sender, EventArgs e)
        {

        }
    }
}
