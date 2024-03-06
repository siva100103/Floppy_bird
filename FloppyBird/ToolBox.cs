using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svg;
namespace FloppyBird
{
    public partial class ToolBox : Form
    {
        //for PictureBoxes
        List<Picturebox> pictureBoxes = new List<Picturebox>();
        private Point currentLocation=new Point(0,0);
        private Size PictureBoxSize;
        public Point CurrentLocation
        {
            get { return currentLocation; }
            set
            {
                if (currentLocation.X + PictureBoxSize.Width >= SVGContainer.Width)
                    currentLocation = new Point(0, currentLocation.Y + PictureBoxSize.Height);
                else
                    currentLocation = new Point(currentLocation.X + PictureBoxSize.Width, currentLocation.Y);
            }
        }

        //In ContentArea
        private List<PictureBox> SVGS = new List<PictureBox>();
        PictureBox Controllable = null;
        PictureBox current = null;
    //    Graphics g;

        //for resize
        private bool isDragging = false;
        private Point lastMousePosition;
        private bool ResizeState = false;

        //for Brush
        Stack<Points> points = new Stack<Points>();
        private bool IsDown = false;
        private bool IsBrushOn = false;

        //for Undo and Redo
        Stack<Points> RedoPaintStack = new Stack<Points>();

        Stack<Operation> UndoOperations = new Stack<Operation>();
        Stack<Operation> RedoOPerations = new Stack<Operation>();

        Stack<PictureBox> AddOp = new Stack<PictureBox>();
        Stack<PictureBox> ResizeOp = new Stack<PictureBox>();
        Stack<PictureBox> DeleteOp = new Stack<PictureBox>();
        Stack<PictureBox> FlipOp = new Stack<PictureBox>();
        Stack<PictureBox> FlipHelperOp = new Stack<PictureBox>();
        //Enum

       

        public ToolBox()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, ContentPanel, new object[] { true });
          //  DoubleBuffered = true;
            PictureBoxSize = new Size(SVGContainer.Width / 3, SVGContainer.Height / 10);
            ContentPanel.MouseClick += SVGAdder;
            ContentPanel.MouseMove += DrawLine;
            ContentPanel.MouseDown += DrawPanelDown;
            ContentPanel.MouseUp += DrawPanelUp;
            //  g = ContentPanel.CreateGraphics();
        }

        private void abc(object sender, DateTime e)
        {
            ColorButton.Text = e.ToString();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            TopPanel.Height = (Height / 7);
            OptionPanel.Width = (Width / 11);
            button1.Height = button2.Height = button3.Height = button4.Height = button5.Height = button6.Height = button7.Height = button8.Height = (OptionPanel.Height / 8);
           // WillDraw = true;
            ContentPanel.Refresh();
        }

        private void ColorButtonClick(object sender,EventArgs e)
        {
            ResizeState = false;
            IsBrushOn = false;
            ColorDialog colordialog = new ColorDialog();
            DialogResult result = colordialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color selectedColor = colordialog.Color;
                ColorButton.BackColor = selectedColor;
            }
        }

        private void SvgPanelShower(object sender,EventArgs e)
        {
            ResizeState = false;
            IsBrushOn = false;
            SVGContainer.Visible = !SVGContainer.Visible;
          //  WillDraw = true;
            ContentPanel.Refresh();
        }

        private void SVGUpLoader(object sender,EventArgs e)
        {
            ResizeState = false;
            IsBrushOn = false;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.svg) | *.svg";
            DialogResult result = open.ShowDialog();
            if (result == DialogResult.OK)
            {
                string name = open.FileName;
                Picturebox pictureBox = new Picturebox(name, currentLocation, PictureBoxSize);
                CurrentLocation= new Point(CurrentLocation.X+PictureBoxSize.Width,CurrentLocation.Y);
                PictureBox pic = pictureBox.PictureBox;
                SVGContainer.Controls.Add(pic);
                pic.MouseClick += SVGClicked;
            }
        }
        
        private void SVGClicked(object sender, EventArgs e)
        {
            IsBrushOn = false;
            PictureBox pic = sender as PictureBox;
            current = new PictureBox
            {
                Size = pic.Size,
                Image = new Bitmap(pic.Image),
                Cursor=Cursors.Hand,
                SizeMode=pic.SizeMode,
            };
        }

        private void SVGAdder(object sender,MouseEventArgs e)
        {
            if(current != null)
            {
                current.Location = new Point(e.X, e.Y);
                PictureBox pic = new PictureBox
                {
                    Location = current.Location,
                    Size = current.Size,
                    SizeMode=current.SizeMode,
                    Cursor = current.Cursor,
                    Image=new Bitmap(current.Image)
                };
                ContentPanel.Controls.Add(pic);
                pic.MouseDown += TrueChanger;
                pic.MouseUp += FalseChanger;
                pic.MouseMove += SVGResizer;
                SVGS.Add(pic);
                UndoOperations.Push(Operation.ObjectAdd);
                AddOp.Push(pic);
                current = null;
            }
        }
        
        private void SVGResizer(object sender, MouseEventArgs e)
        {
            IsBrushOn = false;
            if (isDragging && ResizeState)
            {
                int dx = e.X - lastMousePosition.X;
                int dy = e.Y - lastMousePosition.Y;
                Controllable.Left += dx;
                Controllable.Top += dy;
                lastMousePosition = e.Location;
                //  ContentPanelDraw();
                ContentPanel.Refresh();
            }
        }

        private void FalseChanger(object sender, MouseEventArgs e)
        {
            isDragging = false;            
        }

        private void TrueChanger(object sender, MouseEventArgs e)
        {
            if(Controllable!=null) Controllable.BackColor = ContentPanel.BackColor;
            Controllable = sender as PictureBox;
            Controllable.BackColor = Color.DodgerBlue;
            isDragging = true;
            if (ResizeState)
            {
                UndoOperations.Push(Operation.ObjectResize);
                ResizeOp.Push(Controllable);
            }
            lastMousePosition = e.Location;
        }

        private void SVGDeleter(object sender, MouseEventArgs e)
        {
            ResizeState = false;
            IsBrushOn = false;
            if (Controllable != null)
            {
                SVGS.Remove(Controllable);
                UndoOperations.Push(Operation.ObjectDelete);
                DeleteOp.Push(Controllable);
                ContentPanel.Controls.Remove(Controllable);
                Controllable = null;
            }
        }

        private void RightFlipper(object sender,MouseEventArgs e)
        {
            ResizeState = false;
            IsBrushOn = false;
            if(Controllable != null)
            {
                UndoOperations.Push(Operation.ObjectFlip);
                Image im = Controllable.Image;
                im.RotateFlip(RotateFlipType.Rotate90FlipNone);
                Controllable.Image = new Bitmap(im);
            }
        }

        private void LeftFlipper(object sender,MouseEventArgs e)
        {
            ResizeState = false;
            IsBrushOn = false;
            if (Controllable != null)
            {
                UndoOperations.Push(Operation.ObjectFlip);
                FlipOp.Push(Controllable);
                Image im = Controllable.Image;
                im.RotateFlip(RotateFlipType.Rotate270FlipNone);
                Controllable.Image = im;
            }
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            ResizeState = !ResizeState;
        }

       
        private void ContentPanelDraw()
        {
            Graphics g = ContentPanel.CreateGraphics();
            foreach(var a in points)
            {
                if (a.Pointss.Count > 1)
                {
                    g.DrawLines(new Pen(a.Colour,3),a.Pointss.ToArray());
                }
            }
        }
        private void StateChanger(object sender,MouseEventArgs e)
        {
            IsBrushOn = !IsBrushOn;
        }
        private void DrawPanelDown(object sender,MouseEventArgs e)
        {
            if(Controllable!=null) Controllable.BackColor = ContentPanel.BackColor;
            Controllable = null;

            if (IsBrushOn)
            {
                IsDown = true;
                Points p = new Points();
                p.Colour = ColorButton.BackColor;
                p.Pointss.Add(new Point(e.X,e.Y));
                points.Push(p);
                UndoOperations.Push(Operation.paint);
            }
        }
        private void DrawPanelUp(object sender,MouseEventArgs e)
        {
            IsDown = false;
        }
        private void DrawLine(object sender,MouseEventArgs e)
        {
            //g = ContentPanel.CreateGraphics();
            if (IsDown && IsBrushOn)
            {
                points.Peek().Pointss.Add(new Point(e.X, e.Y));
                //ContentPanelDraw();
                //WillDraw = true;
                ContentPanel.Refresh();
            }    
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //dataGridView1.UserAddedRow = true;
            DataTable d = new DataTable();
            d.Columns.Add("Id" , typeof(int));
            d.Columns.Add("Idd" , typeof(Image));
            d.Columns.Add("Iddd" , typeof(string));
            d.Columns.Add("Iddccd" , typeof(Clock));

            Image img = Properties.Resources.icons8_add_50;
            d.Rows.Add(1, img, "abc" , new Clock());
            dataGridView1.DataSource = d;

            DataGridViewCell r= dataGridView1.Rows[0].Cells[1];
            MessageBox.Show(r.Value.ToString());
        }
        private void Undo(object sender,MouseEventArgs e)
        {
            if (UndoOperations.Count > 0)
            {
                if (UndoOperations.Peek() == Operation.paint)
                {                
                    if (points.Count > 0)
                    {
                        RedoOPerations.Push(UndoOperations.Pop());
                        RedoPaintStack.Push(points.Pop());
                       // WillDraw = true;
                        ContentPanel.Refresh();
                    }
                }
                else
                {
                    Operation op = UndoOperations.Peek();
                    switch (op)
                    {
                        case Operation.ObjectAdd:
                            PictureBox del = AddOp.Peek();
                            ContentPanel.Controls.Remove(del);
                            RedoOPerations.Push(Operation.ObjectDelete);
                            DeleteOp.Push(AddOp.Pop());
                            break;
                        case Operation.ObjectDelete:
                            PictureBox Add = DeleteOp.Peek();
                            ContentPanel.Controls.Add(Add);
                            RedoOPerations.Push(Operation.ObjectAdd);
                            AddOp.Push(DeleteOp.Pop());
                            break;
                        default:
                            break;
                    }
                    UndoOperations.Pop();
                }
            }
        }
        private void Redo(object sender,MouseEventArgs e)
        {
             if (RedoOPerations.Count > 0)
            {
                if (RedoOPerations.Peek() == Operation.paint)
                {
                    if (RedoPaintStack.Count != 0)
                    {
                        UndoOperations.Push(RedoOPerations.Pop());
                        points.Push(RedoPaintStack.Pop());
                      //  WillDraw = true;
                        ContentPanel.Refresh();
                    }
                }
                else
                {
                    Operation op = RedoOPerations.Peek();
                    switch (op)
                    {
                        case Operation.ObjectAdd:
                            PictureBox del = AddOp.Peek();
                            ContentPanel.Controls.Remove(del);
                            UndoOperations.Push(Operation.ObjectDelete);
                            DeleteOp.Push(AddOp.Pop());
                            break;
                        case Operation.ObjectDelete:
                            PictureBox Add = DeleteOp.Peek();
                            ContentPanel.Controls.Add(Add);
                            UndoOperations.Push(Operation.ObjectAdd);
                            AddOp.Push(DeleteOp.Pop());
                            break;
                        default:
                            break;
                    }
                    RedoOPerations.Pop();
                }
            }
        }

        private bool WillDraw = false;
        private void SavePanel(object sender,MouseEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter="(*.png)|*.png|(.*jpg)|*.jpg";
            DialogResult result = save.ShowDialog();
            if(result == DialogResult.OK)
            {
                string name = save.FileName;
                WillDraw = true;
                ContentPanel.Refresh();
                Bitmap bmp = new Bitmap(ContentPanel.Width, ContentPanel.Height);
                ContentPanel.DrawToBitmap(bmp,new Rectangle(0,TopPanel.Height,ContentPanel.Width,ContentPanel.Height));
                bmp.Save(name);
            }
        }
        private void ContentPanelPaint(object sender,PaintEventArgs e)
        {
            
                foreach(var a in points)
                {
                    if (a.Pointss.Count > 1) e.Graphics.DrawLines(new Pen(a.Colour,3),a.Pointss.ToArray());
                }
            
        }
    }

    enum Operation
    {
        paint, ObjectAdd,ObjectDelete,ObjectResize,ObjectFlip
    }
    class Picturebox
    {
        public Point PLocation;
        public Size Psize;
        public string PName;
        public PictureBox PictureBox;
        private bool isClicked = false;
        public Picturebox(string name,Point location,Size size)
        {
            PName = name;
            Psize = size;
            PLocation = location;
            SvgDocument doc = SvgDocument.Open(PName);
            Bitmap bitmap = doc.Draw();
            PictureBox= new PictureBox
            {
                Image = bitmap,
                Location = PLocation,
                Size = Psize,
                Cursor = Cursors.Hand,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox.MouseHover += MouseHovered;
            PictureBox.MouseLeave += MouseLeaved;
            PictureBox.MouseClick += MouseClicked;
        }

        private void MouseLeaved(object sender, EventArgs e)
        {
            if (!isClicked)
            {
                PictureBox pic = sender as PictureBox;
                pic.BorderStyle = BorderStyle.None;
            }
        }

        private void MouseHovered(object sender, EventArgs e)
        {
            if (!isClicked)
            {
                PictureBox pic = sender as PictureBox;
                pic.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void MouseClicked(object sender,EventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            if (isClicked) pic.BorderStyle = BorderStyle.None;
            else pic.BorderStyle = BorderStyle.FixedSingle;

            isClicked = !isClicked;
        }
    }

    class Points
    {
        public List<Point> Pointss = new List<Point>();
        public Color Colour { get; set; } = Color.Gray;
    }

    
}
