using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gamificationlibrary
{
  public class GraphicProgressView
    {
        /// <summary>
        /// draw graph apply Winform
        /// </summary>
        /// <param name="control"></param>
        /// <param name="pointGraph"></param>
        /// <param name="colorLine"></param>
        /// <param name="sizeLine"></param>
        
        public static void drawLine(Control control, Point[] pointGraph, Color colorLine, float sizeLine ) {  
            Pen graphPen = new Pen(colorLine, sizeLine);         
            control.CreateGraphics().DrawLines(graphPen, pointGraph);
        }

       

    }
}
