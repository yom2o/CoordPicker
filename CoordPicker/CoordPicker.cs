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
        Rectangle selectedRectangle; // rectangle in source image coordinate system.

        public CoordPicker() {
            InitializeComponent();
            coordBox = new CoordBox(coordBox1);
            updateScale();
        }
        private void button_open_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                Debug.WriteLine(ofd.FileName);
                ReadImageFile(ofd.FileName);
            }
        }

        /// 
        /// Show Image
        ///
        private void ReadImageFile(string filename) {
            var img = Image.FromFile(filename);
            ShowNewImage(img);
            fnameBox1.Text = filename;
            sizeBox1.Text = img.Width + "x" + img.Height;
            hasRect = false;
            isDrawing = false;
        }
        Image currentImage = null;
        private void ShowNewImage(Image img) {
            if (currentImage != null) {
                currentImage.Dispose();
            }
            currentImage = img;
            ShowImage();
        }
        private void ShowImage() {
            var img = currentImage;
            int scale = currentScale();
            Size size = new Size(img.Size.Width * scale / 100, img.Size.Height * scale / 100);
            pictureBox1.Size = size;
            if (pictureBox1.BackgroundImage != null) {
                pictureBox1.BackgroundImage.Dispose();
            }
            pictureBox1.BackgroundImage = new Bitmap(img, size);
            if (pictureBox1.Image != null) {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = new Bitmap(size.Width, size.Height);
        }

        //
        // Draw Rectangle
        //
        private Point startPoint;
        private Point endPoint;
        private Pen movingPen = new Pen(Color.Red, 1);
        private Pen fixedPen = new Pen(Color.Red, 2);

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && currentImage != null) {
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
                    selectedRectangle = Transform.Screen2Picture(Points2Rectangle(startPoint, endPoint), currentScale());
                    //
                    var builder = new StringBuilder();
                    builder.Append(selectedRectangle.Left + "\t");
                    builder.Append(selectedRectangle.Top + "\t");
                    builder.Append(selectedRectangle.Right + "\t");
                    builder.Append(selectedRectangle.Bottom);
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
                //e.Graphics.DrawRectangle(fixedPen, Points2Rectangle(startPoint, endPoint));
                e.Graphics.DrawRectangle(fixedPen, Transform.Picture2Screen(selectedRectangle, currentScale()));
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

        //
        // scale controls
        //
        int scaleIndex = 2;
        int[] scaleList = new int[] { 25, 50, 100, 200 };
        private int currentScale() {
            return scaleList[scaleIndex];
        }

        private void button_minus_Click(object sender, EventArgs e) {
            if (scaleIndex > 0) {
                --scaleIndex;
                updateScale();
            }
        }

        private void button_plus_Click(object sender, EventArgs e) {
            if (scaleIndex < scaleList.Length - 1) {
                ++scaleIndex;
                updateScale();
            }
        }
        private void updateScale() {
            coordBox.SetScale(currentScale());
            scaleBox1.Text = currentScale() + "% ";
            isDrawing = false;
            if (currentImage != null) {
                ShowImage();
                pictureBox1.Invalidate();
            }
        }
    }

    public class Transform {
        public static Point Screen2Picture(Point src, int scale) {
            return new Point(src.X * 100 / scale, src.Y * 100 / scale);
        }
        public static Rectangle Screen2Picture(Rectangle src, int scale) {
            return new Rectangle(src.X * 100 / scale, src.Y * 100 / scale,
                src.Width * 100 / scale, src.Height * 100 / scale);
        }
        public static Point Picture2Screen(Point src, int scale) {
            return new Point(src.X * scale / 100, src.Y * scale / 100);
        }
        public static Rectangle Picture2Screen(Rectangle src, int scale) {
            return new Rectangle(src.X * scale / 100, src.Y * scale / 100,
                src.Width * scale / 100, src.Height * scale / 100);
        }
    }

    public class CoordBox {
        TextBox coordBox;
        int currentScale;
        public CoordBox(TextBox cb) {
            this.coordBox = cb;
            this.currentScale = 100;
        }
        public void SetScale(int scale) {
            currentScale = scale;
        }
        public void SetPoint(Point p) {
            p = Transform.Screen2Picture(p, currentScale);
            this.coordBox.Text = "(" + p.X + ", " + p.Y + ")";
        }
        public void SetPoint(Point p1, Point p2) {
            p1 = Transform.Screen2Picture(p1, currentScale);
            p2 = Transform.Screen2Picture(p2, currentScale);
            this.coordBox.Text = "(" + p1.X + ", " + p1.Y + ") - (" + p2.X + ", " + p2.Y + ")";
        }
    }
}
