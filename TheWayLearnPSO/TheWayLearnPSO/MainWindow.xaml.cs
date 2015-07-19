using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TheWayLearnPSO.PSOAlogirthm;
using TheWayLearnPSO.Properties;

namespace TheWayLearnPSO
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Polyline line = new Polyline();
            Polyline line2 = new Polyline();
            line.VerticalAlignment = VerticalAlignment.Center;
            line.Stroke = SystemColors.WindowTextBrush;
            line.StrokeThickness = 2;

            for (int i = -200; i < 200; i++)
            {
                line.Points.Add(new Point(i, Algorithm.CalFitness(i)));
            }
                
            panel.Children.Add(line);

            Algorithm alogrithm = new Algorithm();

            for (int j = 0; j < Algorithm.MAX_CHANGE; j++)
            {
                List<Polyline> lines = alogrithm.Graph();
                for (int i = 0; i < lines.Count; i++)
                {
                    panel.Children.Add(lines[i]);
                }

                alogrithm.Running (); 
            }

            bestX.Content = alogrithm.GlobeBestX.ToString();
            bestY.Content = alogrithm.GlobleBestFitness.ToString();
        }
    }
}
