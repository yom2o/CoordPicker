using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoordPicker {
    public partial class CoordPicker : Form {
        CoordBox coordBox;
        private bool hasRect = false;
        private bool isDrawing = false;
        private Point startPoint;
        private Point endPoint;
        private Pen movingPen = new Pen(Color.Red, 1);
        private Pen fixedPen = new Pen(Color.Red, 2);

        public CoordPicker() {
            InitializeComponent();
            coordBox = new CoordBox(coordBox1);
        }
        private void button_open_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                Debug.WriteLine(ofd.FileName);
                ShowImage(ofd.FileName);
            }
        }
        Image img = null;
        private void ShowImage(string filename) {
            img = Image.FromFile(filename);
            pictureBox1.BackgroundImage = img;
            Bitmap canvas = new Bitmap(img.Width, img.Height);
            pictureBox1.Image = canvas;
            fnameBox1.Text = filename;
            sizeBox1.Text = img.Width + "x" + img.Height;
            hasRect = false;
            isDrawing = false;
        }
        //
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && img != null) {
                isDrawing = true;
                hasRect = false;
                startPoint = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (isDrawing) {
                endPoint = e.Location;
                pictureBox1.Invalidate();
                coordBox.SetPoint(startPoint, endPoint);
            } else if (!hasRect) {
                coordBox.SetPoint(e.Location);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            if (isDrawing) {
                endPoint = e.Location;
                isDrawing = false;
                if (endPoint.Equals(startPoint)) {
                    hasRect = false;
                    pictureBox1.Invalidate();
                    coordBox.SetPoint(endPoint);
                } else {
                    hasRect = true;
                    pictureBox1.Invalidate();
                    coordBox.SetPoint(startPoint, endPoint);
                    //
                    var builder = new StringBuilder();
                    builder.Append(Math.Min(startPoint.X, endPoint.X) + "\t");
                    builder.Append(Math.Min(startPoint.Y, endPoint.Y) + "\t");
                    builder.Append(Math.Max(startPoint.X, endPoint.X) + "\t");
                    builder.Append(Math.Max(startPoint.Y, endPoint.Y));
                    builder.AppendLine();
                    Clipboard.SetText(builder.ToString());
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            if (isDrawing) {
                var activeRect = Points2Rectangle(startPoint, endPoint);
                e.Graphics.DrawRectangle(movingPen, activeRect);
            } else if (hasRect) {
                e.Graphics.DrawRectangle(fixedPen, Points2Rectangle(startPoint, endPoint));
            }
        }

        static public Rectangle Points2Rectangle(Point p0, Point p1) {
            Rectangle rect = new Rectangle();
            rect.X = Math.Min(p0.X, p1.X);
            rect.Y = Math.Min(p0.Y, p1.Y);
            rect.Width = Math.Abs(p0.X - p1.X);
            rect.Height = Math.Abs(p0.Y - p1.Y);
            return rect;
        }
    }

    public class CoordBox {
        TextBox coordBox;
        public CoordBox(TextBox cb) {
            this.coordBox = cb;
        }
        public void SetPoint(Point p) {
            this.coordBox.Text = "(" + p.X + ", " + p.Y + ")";
        }
        public void SetPoint(Point p1, Point p2) {
            this.coordBox.Text = "(" + p1.X + ", " + p1.Y + ") - (" + p2.X + ", " + p2.Y + ")";
        }
    }
}
