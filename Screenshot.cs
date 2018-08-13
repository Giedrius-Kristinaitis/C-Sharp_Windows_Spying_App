using System.Drawing;

namespace IDK {

    /// <summary>
    /// Screenshot class to take screenshots of the screen
    /// </summary>
    class Screenshot {

        private Bitmap bitmap;      // screenshot pixel data 
        private Graphics graphics;  // graphics to get the screenshot
        private Size size;          // size of the screenshot

        /// <summary>
        /// Class constructor. Initializes required variables
        /// </summary>
        /// <param name="width">width of the screenshot</param>
        /// <param name="height">height of the screenshot</param>
        public Screenshot(int width, int height) {
            bitmap = new Bitmap(width, height);
            size = new Size(width, height);
            graphics = Graphics.FromImage(bitmap);
        }

        /// <summary>
        /// Takes a screenshot
        /// </summary>
        /// <returns>reference to the Bitmap with pixel data</returns>
        public Bitmap Take() {
            graphics.CopyFromScreen(0, 0, 0, 0, size);
            return bitmap;
        }
    }
}
